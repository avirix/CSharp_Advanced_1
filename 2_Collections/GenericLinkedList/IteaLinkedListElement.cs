namespace ITEA_Collections.GenericLinkedList
{
    public class IteaLinkedListElement<T>
    {
        public T Content { get; set; }
        public IteaLinkedListElement<T> Previous { get; set; }
        public IteaLinkedListElement<T> Next { get; set; }

        public IteaLinkedListElement(T element)
        {
            Content = element;
        }
    }
}
