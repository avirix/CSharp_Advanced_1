using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ITEA_Collections.Common.Extensions;
namespace IteaDelegates.IteaMessanger
{
    public class Group
    {
        public string GroupName { get; private set; }
        public List<Account> members = new List<Account>();
        public List<Message> messages = new List<Message>();
        public event OnSend groupMessage;
        private Group()
        {

        }
        public Group(Account creator, string name)
        {
            members.Add(creator);
            GroupName = name;
            groupMessage += creator.GroupMessage;
        }
        public void GroupMessage(Message message)
        {
            OnSendEventArgs onSendEventArgs = new OnSendEventArgs(message.Preview, message.From.Username, message.Group.GroupName);
            groupMessage(this, onSendEventArgs);
        }
        public void ShowDialog(string group)
        {
            List<Message> messageDialog = messages
                .OrderBy(x => x.Created)
                .ToList();
            string str = $"Dialog Group - {group}";
            ToConsole($"---{str}---");
            foreach (Message message in messageDialog)
            {
                ToConsole($"{(message.From.Username)}: {message.ReadMessage(this)}",
                    message.From.Username.Equals(group) ? ConsoleColor.Cyan : ConsoleColor.DarkYellow);
            }
            ToConsole($"---{string.Concat(str.Select(x => "-"))}---");
        }
    }
}
