using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Collections.Base
{
    internal class IteaLinkedList
    {
        Message Head { get; set; }

        protected IteaLinkedList() { }

        public IteaLinkedList(Message message)
        {
            Head = message;
        }

        private Message GetLast()
        {
            if (Head == null)
                throw new Exception("Head is null");
            else
            {
                Message last = Head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                return last;
            }
        }

        public void Add(Message message)
        {
            if (Head == null)
                Head = message;
            else
            {
                Message last = Head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = message;
                message.Previous = last;
            }
        }

        public Message RemoveLast()
        {
            Message last = GetLast();
            if(last != Head)
            {
                last.Previous.Next = null;
            }
            return null;
        }

        public override string ToString()
        {
            string str = $"{Head?.Content}; ";
            Message current = Head;
            while(current?.Next != null)
            {
                str += $"{current.Next.Content}; ";
                current = current.Next;
            }
            return str;
        }
    }
}
