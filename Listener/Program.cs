namespace EventGrid.Listener
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var filter = args[0];
            Console.WriteLine($"Listening to: {filter}");
        }
    }
}