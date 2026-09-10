using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public static class Highlight
    {
        public static void Error(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
