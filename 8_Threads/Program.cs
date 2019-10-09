using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using static ITEA_Collections.Common.Extensions;

namespace IteaThreads
{
    class Program
    {
        static int counter = 0;
        static object locker = new object();
        public struct MyStruct
        {
            public int From;
            public int To;
        }
        static void Main(string[] args)
        {
            Process current = Process.GetCurrentProcess();
            ToConsole($"Process name: {current.ProcessName}");

            ToConsoleLine("Kill Chrome? (Y - yes, else - no)", ConsoleColor.Red);
            if (Console.ReadKey().Key == ConsoleKey.Y)
                Process
                    .GetProcessesByName("chrome")
                    .ToList()
                    .ForEach(x => x.Kill());
            else ToConsole("\nOkay");

            new Thread(Write)
            {
                Priority = ThreadPriority.Lowest,
                Name = "Write1"
            }.Start();
            new Thread(Write)
            {
                Priority = ThreadPriority.Highest,
                Name = "Write2"
            }.Start();
            new Thread(new ParameterizedThreadStart(WriteFromTo))
            {
                Priority = ThreadPriority.Normal,
                Name = "WriteFromTo"
            }.Start(new MyStruct
            {
                From = 0,
                To = 2
            }
            );
            Write();
        }


        public static void Write()
        {
            lock (locker)
            {
                Thread thread = Thread.CurrentThread;
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    ToConsole($"{thread.Name}: {i}, counter: {counter}");
                }
            }
        }

        public static void WriteFromTo(object param)
        {
            Thread thread = Thread.CurrentThread;
            MyStruct @struct = (MyStruct)param;
            for (int i = @struct.From; i < @struct.To; i++)
            {
                counter++;
                ToConsole($"{thread.Name}: {i}, counter: {counter}");
                Thread.Sleep(500);
            }
        }
    }
}
