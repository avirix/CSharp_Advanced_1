using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using IteaLinqToSql.Models.Entities;

using Newtonsoft.Json;

using static ITEA_Collections.Common.Extensions;

namespace IteaThreads
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static int counter = 0;
        static readonly object locker = new object();

        public struct MyStruct
        {
            public int From;
            public int To;
        }

        static void Main(string[] args)
        {
            Task<string> usersString = GetUserAsync();

            Process current = Process.GetCurrentProcess();
            ToConsole($"Process name: {current.ProcessName}");

            //ToConsoleLine("Kill Chrome? (Y - yes, else - no)", ConsoleColor.Red);
            //if (Console.ReadKey().Key == ConsoleKey.Y)
            //    Process
            //        .GetProcessesByName("chrome")
            //        .Once(() => ToConsole(""))
            //        .ToList()
            //        .ForEach(x =>
            //        {
            //            ToConsole($"{x.ProcessName}/{x.Id}");
            //            x.Kill();
            //        });
            //else ToConsole("\nOkay");

            Thread.CurrentThread.Name = "Main";
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            ThreadStart threadStart1 = Write;

            Thread thread1 = new Thread(threadStart1)
            {
                Name = "Write1"
            };

            thread1.Start();

            Thread thread2 = new Thread(new ThreadStart(Write))
            {
                Priority = ThreadPriority.Lowest,
                Name = "Write2"
            };

            thread2.Start();

            new Thread(new ParameterizedThreadStart(WriteFromTo)) // new Thread(WriteFromTo)
            {
                Priority = ThreadPriority.AboveNormal,
                Name = "WriteFromTo"
            }.Start(new MyStruct { From = 0, To = 2 });

            Write();

            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersString.Result);
            ToConsole(JsonConvert.SerializeObject(users, Formatting.Indented), ConsoleColor.Cyan);
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
                //Thread.Sleep(500);
            }
        }
        public static async Task<string> GetUserAsync()
        {
            try
            {
                using (var usersAsync = await client.GetAsync("http://localhost:5000/api/user"))
                {
                    ToConsole($"\nget usersAsync...\n", ConsoleColor.Green);
                    return await usersAsync.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                ToConsole($"\n{ex.Message}\n", ConsoleColor.Red);
                return "";
            }
        }
    }
}
