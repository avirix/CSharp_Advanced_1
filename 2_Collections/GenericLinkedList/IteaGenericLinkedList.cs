using System;

namespace ITEA_Collections.GenericLinkedList
{
    internal class IteaGenericLinkedList<T>
    {
        public int Count { get; private set; } = 0;
        IteaLinkedListElement<T> Head { get; set; }

        protected IteaGenericLinkedList() { }

        public IteaGenericLinkedList(T element)
        {
            Count = 1;
            Head = new IteaLinkedListElement<T>(element);
        }

        public T this[int index]
        {
            get
            {
                int i = 0;
                IteaLinkedListElement<T> current = Head;
                while (i < index && current.Next != null)
                {
                    i++;
                    current = current.Next;
                }
                return current.Content;
            }
        }

        private  IteaLinkedListElement<T> IteaGoogle(int index)
        {
            int i = 0;
            IteaLinkedListElement<T> current = Head;
            while (i < index && current.Next != null)
            {
                i++;
                current = current.Next;
            }
            return current;
        }

        private IteaLinkedListElement<T> GetLast()
        {
            if (Head == null)
                throw new Exception("Head is null");
            else
            {
                IteaLinkedListElement<T> last = Head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                return last;
            }
        }

        public void Add(T el)
        {
            IteaLinkedListElement<T> newElement = new IteaLinkedListElement<T>(el);
            Count++;
            if (Head == null)
                Head = newElement;
            else
            {
                IteaLinkedListElement<T> last = Head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = newElement;
                newElement.Previous = last;
            }
        }

        public void InsertByIndex(int index, T element)
        {
            if (index < 1 && index > Count)
                throw new IndexOutOfRangeException();

            Count++;
            IteaLinkedListElement<T> itemToReplace = IteaGoogle(index);
            IteaLinkedListElement<T> newItem = new IteaLinkedListElement<T>(element);
            IteaLinkedListElement<T> previousItem = itemToReplace.Previous;

            previousItem.Next = newItem;
            newItem.Previous = previousItem;

            newItem.Next = itemToReplace;
            itemToReplace.Previous = newItem;
        }

        public T RemoveLast()
        {
            IteaLinkedListElement<T> last = GetLast();
            Count--;
            if (last != Head)
            {
                last.Previous.Next = null;
            }
            return last.Content;
        }

        public override string ToString()
        {
            string str = $"{Head.Content}; ";
            IteaLinkedListElement<T> current = Head;
            while (current?.Next != null)
            {
                str += $"{current.Next.Content}; ";
                current = current.Next;
            }
            return str;
        }
    }
}
