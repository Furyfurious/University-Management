using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    internal static class DisplayRead
    {
        public static int ReadInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input, please enter a number: ");
            }
            return result;
        }



        public static string ReadNonEmptyString(string prompt)
        {
            string result;
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(result = input))
            {
                Console.Write("Input cannot be empty, try again: ");
            }
            return result;
        }
    }
}
