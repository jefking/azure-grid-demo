namespace EventGrid.Writer
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var uri = "https://vanazure.westus2-1.eventgrid.azure.net/api/events";
            var key = "CMSK2KX2F+Ork15T/cXDOGQ87e6G+2ewidGue+YfIxM=";

            var data = new DisplayData
            {
                Topic = "/subscriptions/15be36e2-6246-4377-b9ab-b4b90362cd07/resourceGroups/vademo/providers/microsoft.eventgrid/topics/vanazure",
                Subject = "echo/hello/van/azure",
                Data = "{\"raw\":\"f456d7s8iuyhgvrt5ghwjuiqsudfygtfydeuwjhnb\"}"
            };

            var json = JsonConvert.SerializeObject(data);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("aeg-sas-key", key);
            client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

            Console.WriteLine("Refresh Paste Bin like a boss!");
        }
    }

    public class DisplayData
    {
        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
    }
}