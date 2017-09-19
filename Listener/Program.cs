namespace EventGrid.Listener
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Description;
    using Microsoft.Azure.WebJobs.Extensions.EventGrid;
    using Microsoft.Azure.WebJobs.Host.Config;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Character.");

            var val = Console.ReadKey();
            var filter = val.KeyChar;

            var request = CreateDispatchRequest("TestEventGrid", new EventGridEvent
            {
                Subject = "One",
                Data = JObject.FromObject(new CharacterEvent
                {
                    Data = filter.ToString()
                })
            });

            Console.WriteLine($"{Environment.NewLine}Listening to: {filter}");

            //Listen to Event Grid events

            var ext = new EventGridExtensionConfig();

            var host = NewHost(ext);
            host.StartAsync().Wait(); // add listener 

            IAsyncConverter<HttpRequestMessage, HttpResponseMessage> handler = ext;
            var response = handler.ConvertAsync(request, CancellationToken.None).Result;

        }
        static HttpRequestMessage CreateDispatchRequest(string funcName, params EventGridEvent[] items)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/?functionName=" + funcName);
            request.Headers.Add("aeg-event-type", "Notification");
            request.Content = new StringContent(
                JsonConvert.SerializeObject(items),
                Encoding.UTF8,
                "application/json");
            return request;
        }

        public static JobHost NewHost(EventGridExtensionConfig ext)
        {
            var config = new JobHostConfiguration
            {
                HostId = Guid.NewGuid().ToString("n"),
                StorageConnectionString = null,
                DashboardConnectionString = null
            };

            config.AddExtension(ext);
            config.AddExtension(new EVExtensionConfig());

            return new JobHost(config);
        }
    }
    public class CharacterEvent
    {
        public string Data { get; set; }
    }

    [Binding]
    public class BindingDataAttribute : Attribute
    {
        public BindingDataAttribute(string toBeAutoResolve)
        {
            ToBeAutoResolve = toBeAutoResolve;
        }

        [AutoResolve]
        public string ToBeAutoResolve { get; set; }
    }

    public class EVExtensionConfig : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.
                AddBindingRule<BindingDataAttribute>().
                BindToInput<string>(attr => attr.ToBeAutoResolve);
        }
    }
}