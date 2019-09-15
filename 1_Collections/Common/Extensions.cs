using System;

namespace ITEA_Collections.Common
{
    internal static class Extensions
    {
        public static void ToConsole(object obj, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(obj);
            Console.ResetColor();
        }
    }
}
