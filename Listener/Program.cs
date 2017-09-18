namespace EventGrid.Listener
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Character.");

            var val = Console.ReadKey();
            var filter = val.KeyChar;

            Console.WriteLine($"{Environment.NewLine}Listening to: {filter}");

            //Listen to Event Grid events
        }
    }
}