using System;
using System.Linq;

namespace IteaDelegates.IteaMessanger
{
    public class Message
    {
        readonly string text;

        public Account From { get; set; }
        public Participant To { get; set; }
        public bool Read { get; set; }
        public bool Send { get; set; }
        public DateTime Created { get; private set; } 

        public string Preview
        {
            get
            {
                int[] pview = { 10, text.Length };
                return $"{text.Substring(0, pview.Min())}...";
            }
        }

        public Message(Account from, Participant to, string text)
        {
            From = from;
            To = to;
            this.text = text;
            Read = false; //?
            Created = DateTime.Now;
        }

        public string ReadMessage(Account account)
        {
            Read = true;
            return (To == account || From == account) ? text : string.Empty;
        }
    }
}
