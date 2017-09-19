namespace EventGrid.Writer
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Character.");
            ConsoleKeyInfo val;

            while ((val = Console.ReadKey()) != null)
            {
                Console.WriteLine($"{Environment.NewLine}Sending '{val.KeyChar}' to Event Grid.");

                var evnt = new CharacterEvent
                {
                    Topic = "console/msg/pump",
                    Subject = "",
                    Data = new JObject(val),
                };

                //Pass Event to Grid

                Console.WriteLine("Enter new character.");
            }
        }
    }

    public class CharacterEvent
    {
        [JsonProperty(PropertyName = "topic")]
        public string Topic { get; set; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "data")]
        public JObject Data { get; set; }
    }
}