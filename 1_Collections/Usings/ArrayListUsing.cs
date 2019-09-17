using System;
using System.Collections;

using ITEA_Collections.Common;

using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections.Usings
{
    internal class ArrayListUsing : IBaseCollectionUsing
    {
        public ArrayList List { get; set; }

        public ArrayListUsing()
        {
            List = new ArrayList();
        }

        public void Add(object ts)
        {
            List.Add(ts);
        }

        public void AddMany(object[] ts)
        {
            if (ts is null)
                ToConsole($"Array is null!", ConsoleColor.Red);
            else
                List.AddRange(ts);

        }

        public void Clear()
        {
            List.Clear();
        }

        public object GetByID(int index)
        {
            try
            {
                return List[index];
            }
            catch (Exception ex)
            {
                ToConsole(ex.GetType().Name + ex.Message);
                ToConsole($"No element with index: {index}", ConsoleColor.Red);
                return null;
            }
        }

        public void RemoveByID(int index)
        {
            try
            {
                List.RemoveAt(index);
                ToConsole($"Successfully removed #{index}", ConsoleColor.DarkYellow);
            }
            catch (ArgumentOutOfRangeException)
            {
                ToConsole($"No element with index: {index}", ConsoleColor.Red);
            }
        }

        public object[] GetAll()
        {
            return List.GetRange(0, List.Count).ToArray();
        }

        public void ShowAll()
        {
            foreach (var item in GetAll())
                ToConsole($"{List.IndexOf(item)}: {item}, type - {item.GetType().Name}", ConsoleColor.Cyan);
        }
    }
}
