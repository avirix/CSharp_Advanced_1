using System;
using System.Collections.Generic;
using System.Linq;

namespace ITEA_Collections.Common
{
    public static class Extensions
    {
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

        public static IEnumerable<T> ShowAll<T>(this IEnumerable<T> ts) where T : class
        {
            ts.ToList().ForEach(x => ToConsole($"  {x.ToString()}", ConsoleColor.Cyan));
            return ts;
        }
    }
}
