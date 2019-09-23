using System;
using System.Collections.Generic;

using ITEA_Collections.Common;
using static ITEA_Collections.Common.Extensions;
using System.Linq;

namespace ITEA_Collections.Usings
{
    public class DictionaryUsing : IBaseCollectionUsing
    {
        public Dictionary<int, string> Dictionary { get; set; }

        public DictionaryUsing()
        {
            Dictionary = new Dictionary<int, string>();
        }

        public void Add(object ts) {
            Add(ts.ToString());
        }
        public void Add(string ts)
        {
            int id = GetLastID() +1;
            try { Dictionary.Add(id, ts); }
            catch (Exception ex)
            {
                ToConsole(ex.GetType().Name + ex.Message);
                ToConsole($"Cannot add element {ts} with {id}", ConsoleColor.Red);
            }
        }

        public void AddMany(object[] ts)
        {
            foreach (object element in ts) {
                Add(element.ToString());
            }
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public object[] GetAll()
        {
            return Dictionary.Cast<object>().ToArray();
        }

        public object GetByID(int index)
        {
            try
            {
                return Dictionary[index];
            }
            catch 
            {
               return null;
            }
        }

        public void RemoveByID(int index)
        {
            if (!Dictionary.Remove(index)) { ToConsole($"Cannot remove element with id: {index}", ConsoleColor.Red); }
            else { ToConsole($"Successfully removed #{index}", ConsoleColor.DarkYellow); }
   
        }

        public int GetLastID() {
            int id =-1;
            if (Dictionary.Count > 0) {
                id = Dictionary.Keys.Max();
            }
            return id;
        }

        public void ShowAll()
        {
            foreach (KeyValuePair<int, string> element in Dictionary)
            {
                Console.WriteLine("Key:- {0} and Value:- {1} ",
                                   element.Key, element.Value);
            }
        }
    }
}
