using System;

namespace ArberLisaj.Calculator.Helpers
{
    public static class ConsoleHelper
    {

        public static double LexoNumrin(string prompt)
        {
            Console.Write(prompt);
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a valid number: ");
            }
            return value;
        }

        public static double LexoNumrin(string prompt, double min, double max)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= min && value <= max)
                    {
                        break;
                    }
                }
                Console.WriteLine($"Please enter a valid number between {min} and {max}.");
            }
            return value;
        }
    }
}