using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using static ITEA_Collections.Common.Extensions;

namespace IteaSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            ReadFromFile("example.txt");
            WriteToFile("example1.txt", "Some data");
            AppendToFile("example1.txt", "1");
            ToConsole(ReadFromFile("example.txt", ""));
            Person person = new Person("Alex", Gender.Man, 21, "alexs98@gmail.com");
#else
            /*List<Person> people = new List<Person>
            {
                new Person("Pol", Gender.Man, 37, "pol@gmail.com"),
                new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"),
                new Person("Alex", Gender.Man, 21, "alex@gmail.com"),
                new Person("Harry", Gender.Man, 58, "harry@yahoo.com"),
                new Person("Germiona", Gender.Woman, 18, "germiona@gmail.com"),
                new Person("Ron", Gender.Man, 24, "ron@yahoo.com"),
                new Person("Etc1", Gender.etc, 42, "etc1@yahoo.com"),
                new Person("Etc2", Gender.etc, 42, "etc2@gmail.com"),
            };

            Company microsoft = new Company("Microsoft");
            Company apple = new Company("Apple");

            people.ForEach(x => {
                if (x.Age < people.Average(a => a.Age))
                    x.SetCompany(microsoft);
                else
                    x.SetCompany(apple);
            }) ;

            //XmlSerialize("exampleXml", person);
            JsonSerialize("microsoftJson", microsoft);
            JsonSerialize("appleJson", apple);
            Company appleFromFile = JsonDeserialize("appleJson");
            ToConsole(appleFromFile.Id == apple.Id &&
                appleFromFile.People.Count == apple.People.Count);*/


            Company rogaandkopyta = new Company("Roga & Kopyta");
            Division porogam = rogaandkopyta.AddDivision("Po Rogam");
            Division pokoptyam = rogaandkopyta.AddDivision("Po Kopytam");
            Division finance = rogaandkopyta.AddDivision("Finance");
            Division support = rogaandkopyta.AddDivision("Support", porogam);
            rogaandkopyta.AddEmployee(new Person("Pol", Gender.Man, 37, "pol@gmail.com"));
            rogaandkopyta.AddEmployee(new Person("Bertie", Gender.Man, 37, "bert@gmail.com"), porogam);
            rogaandkopyta.AddEmployee(new Person("Alex", Gender.Man, 21, "alex@gmail.com"), porogam);
            rogaandkopyta.AddEmployee(new Person("Reginald", Gender.Man, 50, "reginald@gmail.com"), porogam);
            rogaandkopyta.AddEmployee(new Person("Tomm", Gender.Man, 32, "tomm@gmail.com"), pokoptyam);
            rogaandkopyta.AddEmployee(new Person("Harry", Gender.Man, 27, "harry@gmail.com"), pokoptyam);
            rogaandkopyta.AddEmployee(new Person("Ron", Gender.Man, 24, "ron@yahoo.com"), pokoptyam);
            rogaandkopyta.AddEmployee(new Person("Leslie", Gender.Woman, 35, "leslie@gmail.com"), finance);
            rogaandkopyta.AddEmployee(new Person("Galya", Gender.Woman, 48, "galya@gmail.com"), finance);
            rogaandkopyta.AddEmployee(new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"), support);
            rogaandkopyta.AddEmployee(new Person("Germiona", Gender.Woman, 18, "germiona@gmail.com"), support);
            JsonSerialize("hw7_sidorenko", rogaandkopyta);
            ToConsole("Deserializing object", ConsoleColor.Blue);
            Company rogafromfile = JsonDeserialize("hw7_sidorenko");
            if (rogaandkopyta.Equals(rogafromfile)) { ToConsole("Companies are equal", ConsoleColor.Yellow); }
            else { ToConsole("Companies are different", ConsoleColor.Yellow); }


            

#endif
        }

        #region Serialization
        public static void XmlSerialize<T>(string path, T obj) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream($"{path}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }

            using (var stringwriter = new StringWriter())
            {
                formatter.Serialize(stringwriter, obj);
                ToConsole(stringwriter.ToString());
            }
        }

        public static void JsonSerialize<T>(string path, T obj) where T : class
        {
            using (var fs = new FileStream($"{path}.json", FileMode.OpenOrCreate))
            {
                string strObj = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                byte[] data = strObj
                    .Select(x => (byte)x)
                    .ToArray();
                fs.Write(data, 0, data.Length);
                strObj
                    .Split(",")
                    .ToList()
                    .ForEach(x => ToConsole($"{x},", ConsoleColor.Green));
            }
        }

        public static Company JsonDeserialize(string path)
        {
            using (var streamReader = new StreamReader($"{path}.json"))
            {
                //var startMemory = GC.GetTotalMemory(true);
                string dataStr = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Company>(dataStr, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                //var endMemory = GC.GetTotalMemory(true);
                //Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }
        }
        #endregion
        #region System.IO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void ReadFromFile(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                var startMemory = GC.GetTotalMemory(true);
                streamReader
                    .ReadToEnd()
                    .Split(';')
                    .ShowAll(separator: ";")
                    .Select(x => long.TryParse(x, out long l) ? l : (long?)null)
                    .Where(x => x != null)
                    .ShowAll(separator: ";");
                var endMemory = GC.GetTotalMemory(true);
                Console.WriteLine($"Total memory: {endMemory - startMemory}");
            }
        }

        public static void WriteToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }

            //{
            //    FileStream fileWriter = new FileStream(path, FileMode.OpenOrCreate);
            //    try
            //    {
            //        byte[] array = data.Select(x => (byte)x).ToArray();
            //        fileWriter.Write(array, 0, array.Length);
            //    }
            //    finally
            //    {
            //        fileWriter?.Dispose();
            //    }
            //}

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(data);
            }
        }

        public static void AppendToFile(string path, string data)
        {
            using (var fileWriter = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                long fileDataLength = fileWriter.Length;
                fileWriter.Seek(fileDataLength, SeekOrigin.Begin);
                //fileWriter.Seek(0, SeekOrigin.End);
                fileWriter.Write(array, 0, array.Length);
            }
            using (var fileWriter = new FileStream(path, FileMode.Append))
            {
                byte[] array = data.Select(x => (byte)x).ToArray();
                fileWriter.Write(array, 0, array.Length);
            }
        }

        public static string ReadFromFile(string path, string notExistingEx)
        {
            notExistingEx = string.IsNullOrEmpty(notExistingEx)
                ? "Create file!"
                : notExistingEx;
            try
            {
                using (var fileReader = new FileStream(path, FileMode.Open))
                {
                    byte[] data = new byte[fileReader.Length];
                    fileReader.Read(data, 0, (int)fileReader.Length);
                    //return string.Concat(data.Select(x => (char)x));
                    return Encoding.Default.GetString(data);
                }
            }
            catch (FileNotFoundException)
            {
                ToConsole(notExistingEx, ConsoleColor.Red);
                return "Error";
            }
        }
        #endregion
    }
}
