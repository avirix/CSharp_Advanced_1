using System;
using System.Collections.Generic;
using static ITEA_Collections.Common.Extensions;
using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    public class DictionaryUsing : IBaseCollectionUsing
    {
        public Dictionary<int, string> Dictionary { get; set; }

        public DictionaryUsing()
        {
            Dictionary = new Dictionary<int, string>();
        }

        public void Add(object ts)
        {
            int MaxKey = 0;
            foreach (KeyValuePair<int, string> keyValue in Dictionary)
            {
                if (keyValue.Key > MaxKey)
                {
                    MaxKey = keyValue.Key;
                }
            }
            MaxKey = ++MaxKey;
            Dictionary.Add(MaxKey, ts.ToString());
        }

        public void AddMany(object[] ts)
        {
            int MaxKey = 0;
            foreach (KeyValuePair<int, string> keyValue in Dictionary)
            {
                if (keyValue.Key > MaxKey)
                {
                    MaxKey = keyValue.Key;
                }
            }
            if (ts is null)
                ToConsole($"Array is null!", ConsoleColor.Red);
            else
            {
                for (int i = 0; i < ts.Length; i++)
                {
                    MaxKey = ++MaxKey;
                    Dictionary.Add(MaxKey, ts[i].ToString());
                }
            }
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public object[] GetAll()
        {
            List<object> list = new List<object>();
            foreach (KeyValuePair<int, string> keyValue in Dictionary)
            {
                list.Add(keyValue.Key);
                list.Add(keyValue.Value);
            }
            object[] listobject = new object[list.Count];
            for (int i = 0; i < listobject.Length; i++)
            {
                listobject[i] = list[i];
            }
            return listobject;
        }


        public object GetByID(int key)
        {
            try
            {
                string a = "";
                foreach (KeyValuePair<int, string> keyValue in Dictionary)
                {
                    if (keyValue.Key == key)
                    {
                        a = keyValue.Value;
                    }
                }
                return a;
            }
            catch (Exception ex)
            {
                ToConsole(ex.GetType().Name + ex.Message);
                ToConsole($"No element with key: {key}", ConsoleColor.Red);
                return null;
            }

        }

        public void RemoveByID(int key)
        {
            try
            {
                Dictionary.Remove(key);
                ToConsole($"Successfully removed #{key}", ConsoleColor.DarkYellow);
            }
            catch (ArgumentOutOfRangeException)
            {
                ToConsole($"No element with index: {key}", ConsoleColor.Red);
            }

        }

        public void ShowAll()
        {
            foreach (KeyValuePair<int, string> keyValue in Dictionary)
            {
                ToConsole($"Key: { keyValue.Key}; Value: { keyValue.Value}", ConsoleColor.DarkRed);
            }
        }
    }
}
