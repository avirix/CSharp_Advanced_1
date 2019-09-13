using System;
using System.Collections;

namespace ITEA_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push("two");
            stack.Push(new { name = "Three" });
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.Push(4);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());


            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue("two");
            queue.Enqueue(new { name = "Three" });
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            queue.Enqueue(4);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
