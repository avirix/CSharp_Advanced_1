using System;
using System.Collections.Generic;
using System.Text;
using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public abstract class Participant
    {
        public string Username { get; }
        public List<Message> Messages { get; set; }
        public Participant(string username)
        {
            Username = username;
            Messages = new List<Message>();
        }

        public void OnNewMessage(Message message)
        {
            if (message.Send)
                ToConsole($"OnNewMessage: {message.From.Username}: {message.Preview}", ConsoleColor.DarkYellow);
        }

        public OnMessage NewMessage { get; set; } = delegate (Message message)  // (message)  =>
        {
            if (message.Send)
                ToConsole($"{message.To.Username}, new message from {message.From.Username}:\n  {message.Preview}", ConsoleColor.Green);
        };
    }
}
