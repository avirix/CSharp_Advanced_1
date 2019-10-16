using System;
using System.Collections.Generic;
using System.Text;
using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public enum NotifyType { None, Simple, Full }
    public delegate void Notification(object sender, OnSendEventArgs e);
    public class Group : Participant
    {
        public List<Account> Admins { get; private set; }
        public List<Account> Members { get; private set; }
        private Dictionary<Account, NotifyType> Notifications { get; set; }
        public event Notification Notify;
        public Group(string username, Account account) : base(username)
        {
            Notifications = new Dictionary<Account, NotifyType>();
            Admins = new List<Account>() { account };
            Members = new List<Account>() { account };
            Notifications.Add(account, NotifyType.Full);

        }
        public void AddMember(Account admin,Account newmember)
        {
            if (Admins.Contains(admin)) {
                if (!Members.Contains(newmember)) { Members.Add(newmember); Notify += DisplayFullNotification; }
                else { ToConsole($"User {newmember} is already a member of group", ConsoleColor.Red); }
            }
            else { ToConsole($"User {admin} is not a member of group administrator", ConsoleColor.Red); }
        }

        public void RemoveMember(Account admin, Account removemember)
        {
            if (Admins.Contains(admin)) { }
        }

        public void ChangeNotifyType(Account account, NotifyType notifytype) {
            if (Members.Contains(account)) { Notify -= DisplayFullNotification;}
            if (notifytype == NotifyType.Simple) { Notify += DisplaySimpleNotification; }
        }

        public void Send(Message message)
        {
            if (Members.Contains(message.From))
            {
                message.Send = true;
                message.To.Messages.Add(message);
                Notify?.Invoke(this, new OnSendEventArgs(message.ReadMessage(message.From), message.From.Username,Username));
            }
        }
        public void DisplayFullNotification(object sender,  OnSendEventArgs e)
        {
           ToConsole($"Group {sender.ToString()} have a new message from {e.From} with Text: {e.Text}", ConsoleColor.Blue);
        }
        public void DisplaySimpleNotification(object sender, OnSendEventArgs e)
        {
            ToConsole($"Group {sender.ToString()} have a new message from {e.From}", ConsoleColor.Yellow);
        }
        public override string ToString()
        {
            return Username;
        }

    }
}
