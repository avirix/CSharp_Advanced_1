using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public delegate void OnMessage(Message message);
    public delegate void OnSend(object sender, OnSendEventArgs e);

    public class Account:Participant
    {
        //public string Username { get; private set; }
        //public List<Message> Messages { get; set; }
        public event OnSend OnSend;



        public Account(string username):base(username)
        {
            //Username = username;
            //Messages = new List<Message>();
            //NewMessage += OnNewMessage;
        }

        public Group CreateGroup(string groupname) {
            Group group = new Group(groupname, this);
            return group;
        }

        public Message CreateMessage(string text, Participant to)
        {
            var message = new Message(this, to, text);
            Messages.Add(message);
            return message;
        }

        public void Send(Message message)
        {
            switch (message.To)
            {
                case Account acc:
                    {
                        message.Send = true;
                        message.To.Messages.Add(message);
                        //message.To.NewMessage(message);
                        OnSend?.Invoke(this, new OnSendEventArgs(message.ReadMessage(this), message.From.Username, message.To.Username));
                        break;
                    }
                case Group grp: { grp.Send(message); break; }
            }
        }
        public void ShowDialog(string username)
        {
            List<Message> messageDialog = Messages
                .Where(x => x.To.Username.Equals(username) || x.From.Username.Equals(username))
                .Where(x => x.Send)
                .OrderBy(x => x.Created)
                .ToList();
            string str = $"Dialog with {username}";
            ToConsole($"---{str}---");
            foreach (Message message in messageDialog)
            {
                ToConsole($"{(message.From.Username.Equals(username) ? username : Username)}: {message.ReadMessage(this)}",
                    message.From.Username.Equals(username) ? ConsoleColor.Cyan : ConsoleColor.DarkYellow);
            }
            ToConsole($"---{string.Concat(str.Select(x => "-"))}---");
        }
        public override string ToString()
        {
            return Username;
        }

    }
}
