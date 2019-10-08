using System;
using IteaDelegates.IteaMessanger;

namespace IteaDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("Harry");
            Group group = new Group(a1, "GROUP");
            SpyNotifications spy = new SpyNotifications(group);
            Account a2 = new Account("Ron");
            a2.Subscribe(group, GroupNotification.AUTHORNAME);
            group.GroupMessage(a1.CreateGroupMessage("I'm Alex, from Kyiv", group));
            group.GroupMessage(a2.CreateGroupMessage("Hi, Alex! I'm from Lviv", group));
            group.ShowDialog("GROUP");

            //a1.Send(a1.CreateMessage("Hi, Ann! How are you?", a2));
            //a1.Send(a1.CreateMessage("I'm Alex, from Kyiv", a2));
             a2.Send(a2.CreateMessage("Hi, Alex! I'm from Lviv", a1));
            //a1.ShowDialog(a2.Username);
        }
    }
}
