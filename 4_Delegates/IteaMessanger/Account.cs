using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public delegate void OnMessage(Message message);
    public delegate void OnSend(object sender, OnSendEventArgs e);
    public enum GroupNotification
    {
        AUTHORNAME,
        GROUPNAME
    }

    public class Account
    {
        public string Username { get; private set; }
        public List<Message> Messages { get; set; }

        public event OnSend OnSend;

        public OnMessage NewMessage { get; set; } = delegate (Message message)  // (message)  =>
        {
            if (message.Send)
                ToConsole($"{message.To.Username}, new message from {message.From.Username}:\n  {message.Preview}", ConsoleColor.Green);
        };

        public Account(string username)
        {
            Username = username;
            Messages = new List<Message>();
            //NewMessage += OnNewMessage;
        }
        public Message CreateGroupMessage(string text, Group group)
        {
            var message = new Message(group, this, text);
            group.messages.Add(message);
            //Messages.Add(message);
            return message;
        }
        public Message CreateMessage(string text, Account to)
        {
            var message = new Message(this, to, text);
            Messages.Add(message);
            return message;
        }
        public void Subscribe(Group group, GroupNotification groupNotification)
        {
            if(groupNotification == GroupNotification.AUTHORNAME)
            {
                group.groupMessage += GroupMessage;
                group.members.Add(this);
            }
            else
            {
                group.groupMessage += AnonGroupMessage;
                group.members.Add(this);
            }
        }
        public void GroupMessage(object sender, OnSendEventArgs e)
        {
            ToConsole($"Group message from ({e.From}) - {e.Text}:\n ", ConsoleColor.Green);
        }
        public void AnonGroupMessage(object sender, OnSendEventArgs e)
        {
            ToConsole($"Group message: {e.Text}:\n ", ConsoleColor.Green);
        }
        public void Send(Message message)
        {
            message.Send = true;
            message.To.Messages.Add(message);
            message.To.NewMessage(message);
            if(OnSend != null)
                OnSend(this, new OnSendEventArgs(message.ReadMessage(this), message.From.Username, message.To.Username));
        }

        public void OnNewMessage(Message message)
        {
            if (message.Send)
                ToConsole($"OnNewMessage: {message.From.Username}: {message.Preview}", ConsoleColor.DarkYellow);
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
    }
}
