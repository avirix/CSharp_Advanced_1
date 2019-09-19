using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    public class DictionaryUsing : IBaseCollectionUsing
    {
        public Dictionary<int, string> Dictionary { get; set; }
        private int FirstId { get; set; }
        public DictionaryUsing(int id)
        {
            Dictionary = new Dictionary<int, string>();
            FirstId = id;
        }

        public void Add(object ts)
        {
            if (Dictionary.Count == 0)
            {
                Dictionary.Add(FirstId, ts.ToString());
            }
            else
            {
                int key = Dictionary.Keys.ToArray().Max();
                Dictionary.Add(++key, ts.ToString());
            }
        }

        public void AddMany(object[] ts)
        {
            if (Dictionary.Count == 0)
            {
                Dictionary.Add(FirstId, ts[0].ToString());
                for (int i = 1; i < ts.Length; i++)
                {
                    Dictionary.Add(++FirstId, ts[i].ToString());
                }           
            }
            else
            {
                int key = Dictionary.Keys.ToArray().Max();
                for(int i = 0; i < ts.Length; i++)
                {
                    Dictionary.Add(++key, ts[i].ToString());
                }
            }
        }
        public void Clear()
        {
            Dictionary.Clear();
        }

        public object[] GetAll()
        {
            if (Dictionary.Count == 0)
            {
                Extensions.ToConsole($"Dictionary is empty!", ConsoleColor.Red);
                return Dictionary.Values.Cast<object>().ToArray();
            }
            else
            {
                return Dictionary.Values.Cast<object>().ToArray();
            }
            //return Dictionary..GetRange(0, List.Count).ToArray();
            //throw new NotImplementedException();
        }

        public object GetByID(int index)
        {
            try
            {
                return Dictionary[index];
            }
            catch(Exception)
            {
                Extensions.ToConsole($"Invalid Key!", ConsoleColor.Red);
                return null;
            }
        }
        public void RemoveByID(int index)
        {
            try
            {
                if(Dictionary.Remove(index) == false)
                {
                    Extensions.ToConsole($"Invalid Key: {index}!", ConsoleColor.Red);
                }
                else
                {
                    Extensions.ToConsole($"Key removed: {index}!");
                }
            }
            catch (Exception)
            {
                Extensions.ToConsole($"Invalid Key: {index}!", ConsoleColor.Red);
            }
        }
        public void ShowAll()
        {
            if (Dictionary.Count == 0)
            {
                Extensions.ToConsole($"Dictionary is empty!", ConsoleColor.Red);
            }
            else
            {
                foreach (var kol in Dictionary)
                {
                    Extensions.ToConsole($"Key: {kol.Key} - Value: {kol.Value}");
                }
            }
        }
    }
}
