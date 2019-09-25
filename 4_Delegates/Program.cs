using System;
using IteaDelegates.IteaMessanger;

namespace IteaDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a1 = new Account("Harry");
            Account a2 = new Account("Ron");
            SpyNotifications spy = new SpyNotifications(a2);
            a1.Send(a1.CreateMessage("Hi, Ann! How are you?", a2));
            a1.Send(a1.CreateMessage("I'm Alex, from Kyiv", a2));
            a2.Send(a2.CreateMessage("Hi, Alex! I'm from Lviv", a1));
            a1.ShowDialog(a2.Username);
        }
    }
}
