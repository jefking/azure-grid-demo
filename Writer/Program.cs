namespace EventGrid.Writer
{
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

                //Pass Event to Grid

                Console.WriteLine("Enter new character.");
            }
        }
    }
}