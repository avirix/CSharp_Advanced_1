using System;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    internal class GenericListUsing : IBaseCollectionUsing
    {
        public List<string> List { get; set; }

        public GenericListUsing()
        {
            List = new List<string>();
        }

        public void Add(object ts)
        {
            List.Add(ts.ToString());
        }

        public void AddMany(object[] ts)
        {
            if (ts is null)
                Extensions.ToConsole($"Array is null!", ConsoleColor.Red);
            else
            {
                string[] vs = Array.ConvertAll(ts, x => x.ToString());
                List.AddRange(vs);
            }
        }

        public void Clear()
        {
            List.Clear();
        }

        public object[] GetAll()
        {
            return List.GetRange(0, List.Count).ToArray(); //CHECK IT!!!!!!!!!!!!!!
        }

        public object GetByID(int index)
        {
            try
            {
                return List[index];
            }
            catch (Exception ex)
            {
                Extensions.ToConsole(ex.GetType().Name + ex.Message);
                Extensions.ToConsole($"No element with index: {index}", ConsoleColor.Red);
                return null;
            }
        }

        public void RemoveByID(int index)
        {
            try
            {
                List.RemoveAt(index);
                Extensions.ToConsole($"Successfully removed #{index}", ConsoleColor.DarkYellow);
            }
            catch (ArgumentOutOfRangeException)
            {
                Extensions.ToConsole($"No element with index: {index}", ConsoleColor.Red);
            }
        }

        public void ShowAll()
        {
            foreach (var item in GetAll())
                Extensions.ToConsole($"{List.IndexOf((string)item)}: {item}, type - {item.GetType().Name}", ConsoleColor.Cyan);
        }
    }
}
