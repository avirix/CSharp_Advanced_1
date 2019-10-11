using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ITEA_Collections.Common
{
    public static class Extensions
    {
        public static void ToConsole()
        {
            Console.WriteLine();
            Console.ResetColor();
        }

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

        public static IEnumerable<T> ShowAll<T>(this IEnumerable<T> ts, string separator = "\n")
        {
            ts.ToList().ForEach(x => ToConsoleLine($"  {x.ToString()}{separator}", ConsoleColor.Cyan));
            ToConsoleLine("\n");
            return ts;
        }

        public static IEnumerable<T> Once<T>(this IEnumerable<T> ts, Action exp)
        {
            exp.Invoke();
            return ts;
        }
    }
}
