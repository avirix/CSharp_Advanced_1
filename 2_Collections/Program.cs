﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using ITEA_Collections.CustomCollections;
using ITEA_Collections.GenericLinkedList;
using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lesson
            string[] numbers = new string[] { "1", "2", "3" };
            UseCollection(numbers);
            UseList(numbers);
            UseWeirdYield();
            
            UseEnumerator(numbers);
            UseObservable();
            UseWeirdYield();
            
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 1; i < 11; i++)
            {
                dict.Add(i, i.ToString());
            }
            Console.WriteLine();
            foreach (var item in dict)
            {
                ToConsoleLine($"{item.Value}; ");
            }
            Console.WriteLine();
            foreach (var item in dict)
            {
                if(item.Key % 2 == 0)
                    ToConsoleLine($"{item.Value}; ");
            }
            Console.WriteLine();
            foreach (var item in dict)
            {
                if (item.Key % 2 == 1)
                    ToConsoleLine($"{item.Value}; ");
            }
            #endregion
            IteaGenericLinkedList<string> iteaGeneric = new IteaGenericLinkedList<string>("First");
            Console.WriteLine(iteaGeneric[0]);
            iteaGeneric.Add("Second");
            iteaGeneric.InsertByIndex(1, "Third");
            ToConsole(iteaGeneric.ToString());
        }

        static void UseCollection(object[] objects)
        {
            IteaCollection iteaCollection = new IteaCollection();
            iteaCollection.AddMany(objects);
            ToConsoleLine("IteaCollection/foreach: ", ConsoleColor.Green);
            foreach (var item in iteaCollection)
            {
                ToConsoleLine($"{item}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
            ToConsoleLine("IteaCollection/while: ", ConsoleColor.Green);
            var enumerator = iteaCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ToConsoleLine($"{enumerator.Current}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
        }

        static void UseEnumerator(object[] objects)
        {
            IteaEnumerator iteaEnumerator = new IteaEnumerator(objects);
            ToConsoleLine("IteaEnumerator/foreach: ", ConsoleColor.Green);
            foreach (var item in iteaEnumerator)
            {
                ToConsoleLine($"{item}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
            iteaEnumerator.Reset();
            ToConsoleLine("IteaEnumerator/while: ", ConsoleColor.Green);
            while (iteaEnumerator.MoveNext())
            {
                ToConsoleLine($"{iteaEnumerator.Current}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
        }

        static void UseList(string[] objects)
        {
            List<string> list = new List<string>();
            list.AddRange(objects);
            ToConsoleLine("List/foreach: ", ConsoleColor.Green);
            foreach (var item in list)
            {
                ToConsoleLine($"{item}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
            //list.GetEnumerator().Reset();
            var listEnumerator = list.GetEnumerator();
            //listEnumerator.MoveNext();
            ToConsoleLine("List/while: ", ConsoleColor.Green);
            int counter = 0;
            while (listEnumerator.MoveNext() && counter < 1000)
            {
                ToConsoleLine($"{listEnumerator.Current}; ", ConsoleColor.Cyan);
                counter++;
            }
            Console.WriteLine();
        }

        static void UseObservable()
        {
            ToConsole("Observable collection", ConsoleColor.DarkYellow);
            ObservableCollection<string> people = new ObservableCollection<string> { "Ann", "Tom", "Kate" };

            people.CollectionChanged += CollectionChanged;

            people.Add("Bob");
            people.RemoveAt(1);
            people[0] = "Jimmy";

            foreach (string person in people)
            {
                ToConsoleLine($"{person}; ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
            ToConsole("---------------------", ConsoleColor.DarkYellow);
        }

        private static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    string personNew = e.NewItems[0] as string;
                    ToConsole($"Add: {personNew}", ConsoleColor.Green);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    string personDelete = e.OldItems[0] as string;
                    ToConsole($"Remove: {personDelete}", ConsoleColor.Red);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    string replacedPerson = e.OldItems[0] as string;
                    string replacingRerson = e.NewItems[0] as string;
                    ToConsole($"{replacedPerson} replaced by {replacingRerson}", ConsoleColor.Yellow);
                    break;
            }
        }

        private class Number
        {
            private static int n = 0;
            public int N { get => ++n; } // такое делать НЕЛЬЗЯ!!!!111 (в настоящих проектах)
        }

        static void UseWeirdYield()
        {
            Number i = new Number();
            IEnumerable<int> myEn = CreateIntEnumerable(i);//.ToList();
            foreach (var item in myEn)
                ToConsole($"{item}; ", ConsoleColor.Cyan);
            Console.WriteLine();
            foreach (var item in myEn)
                ToConsole($"{item}; ", ConsoleColor.Cyan);
        }

        private static IEnumerable<int> CreateIntEnumerable(Number k)
        {
            for (int i = 0; i < 10; i++)
            {
                //ToConsole($"Console: {k.N}", ConsoleColor.White);
                yield return k.N;
            }
        }

        private static List<int> CreateIntEnumerableList(Number k)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                //ToConsole($"Console: {k.N}", ConsoleColor.White);
                list.Add(k.N);
            }
            return list;
        }
    }
}
