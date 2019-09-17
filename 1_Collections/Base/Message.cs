namespace ITEA_Collections.Base
{
    public class Message
    {
        public string Content { get; set; }
        public Message Previous { get; set; }
        public Message Next { get; set; }

        public Message(string content)
        {
            Content = content;
        }
    }
}
