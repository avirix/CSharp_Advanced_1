using System;
using System.Collections;
using System.Collections.Generic;

using ITEA_Collections.Common;
using ITEA_Collections.Testing;
using ITEA_Collections.Usings;

namespace ITEA_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Homework
            IBaseCollectionUsing collectionUsing = new ArrayListUsing();
            BaseUsingTest.Execute(ref collectionUsing);
            #endregion
        }

        static void BaseExamples()
        {
            #region Stack
            Console.WriteLine("------------- Stack --------------");
            Stack stack = new Stack();
            stack.Push(1);
            Console.WriteLine("Push: " + stack.Peek());
            stack.Push("two");
            Console.WriteLine("Push: " + stack.Peek());
            stack.Push(new { name = "Three" });
            Console.WriteLine("Push: " + stack.Peek());
            Console.WriteLine("Pop: " + stack.Pop());
            stack.Push(4);
            Console.WriteLine("Peek: " + stack.Peek());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("----------------------------------");
            #endregion Stack
            #region Queue
            Console.WriteLine("------------- Queue --------------");
            Queue queue = new Queue();
            queue.Enqueue(1);
            Console.WriteLine("Enqueue: " + queue.Peek());
            queue.Enqueue("two");
            Console.WriteLine("Enqueue: two");
            queue.Enqueue(new { name = "Three" });
            Console.WriteLine(@"Enqueue: { name = ""Three"" }");
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            queue.Enqueue(4);
            Console.WriteLine("Enqueue: 4");
            Console.WriteLine("Peek: " + queue.Peek());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("----------------------------------");
            #endregion Queue
            #region ArrayList
            Console.WriteLine("------------ArrayList-------------");
            ArrayList arrayList = new ArrayList(120);
            arrayList.Add(1);
            arrayList.AddRange(new[] { (object)2, "three", new { name = "four" } });
            Console.WriteLine($"Count: {arrayList.Count}");
            Console.WriteLine($"Capacity: {arrayList.Capacity}");
            Console.WriteLine(
                $@"Index of ""{{ name = ""four"" }}"": {arrayList.IndexOf(new { name = "four" })}");
            Console.WriteLine("-- Show all --");
            foreach (var item in arrayList)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            arrayList.Insert(1, "insert");
            arrayList.InsertRange(2, new[] { 42, 42, 42 });
            Console.WriteLine("-- Show all --");
            foreach (var item in arrayList)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            Console.WriteLine($@"Index of 42: {arrayList.IndexOf(42)}");
            Console.WriteLine($@"Last index of 42: {arrayList.LastIndexOf(42)}");
            arrayList.Remove(1);
            Console.WriteLine("-- Show all --");
            foreach (var item in arrayList)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            arrayList.RemoveAt(1);
            Console.WriteLine("-- Show all --");
            foreach (var item in arrayList)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            Console.WriteLine("----------------------------------");
            #endregion ArrayList
            #region List
            Console.WriteLine("--------------List----------------");
            List<string> list = new List<string>();
            list.Add("1");
            list.AddRange(new[] { 2.ToString(), "three", "four" });
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Capacity: {list.Capacity}");
            Console.WriteLine(
                $@"Index of ""four"": {list.IndexOf("four")}");
            Console.WriteLine("-- Show all --");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            list.Insert(1, "insert");
            list.InsertRange(2, new[] { "42", "42", "42" });
            Console.WriteLine("-- Show all --");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            Console.WriteLine($@"Index of 42: {list.IndexOf("42")}");
            Console.WriteLine($@"Last index of 42: {list.LastIndexOf("42")}");
            list.Remove("1");
            Console.WriteLine("-- Show all --");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            list.RemoveAt(1);
            Console.WriteLine("-- Show all --");
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine("--------------");
            Console.WriteLine("----------------------------------");
            #endregion List
            #region Hashtable
            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", "First");
            hashtable.Add("2", "Second");
            hashtable.Add("3", "Third");
            Console.WriteLine(hashtable["1"]);
            hashtable.Remove("1");
            foreach (DictionaryEntry element in hashtable)
            {
                Console.WriteLine("Key:- {0} and Value:- {1} ",
                                   element.Key, element.Value);
            }
            #endregion
            #region Dictionary
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("1", "First");
            dictionary.Add("2", "Second");
            dictionary.Add("3", "Third");
            Console.WriteLine(dictionary["1"]);
            dictionary.Remove("1");
            foreach (KeyValuePair<string, string> element in dictionary)
            {
                Console.WriteLine("Key:- {0} and Value:- {1} ",
                                   element.Key, element.Value);
            }
            #endregion
        }
    }
}
