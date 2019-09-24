using System;
using System.Collections.Generic;
using static ITEA_Collections.Common.Extensions;
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
            List<string> st = new List<string>();
            for (int k = 0; k < ts.Length; k++)
            {
                st.Add(ts[k].ToString());
            }
            List.AddRange(st);
        }

        public void Clear()
        {
            List.Clear();
        }

        public object[] GetAll()
        {
            return List.GetRange(0, List.Count).ToArray();
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

        public void ShowAll()
        {
            foreach (string item in GetAll())
                ToConsole($"{List.IndexOf(item.ToString())}: {item}, type - {item.GetType().Name}", ConsoleColor.Cyan);
        }
    }
}
