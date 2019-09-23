using System;

namespace ITEA_Collections.Common
{
    public class Extensions
    {
        public int I { get; set; }

        public static void ToConsole(object obj, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj);
            Console.ResetColor();
        }

        public static void ToConsoleLine(object obj, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(obj);
            Console.ResetColor();
        }
    }
}
