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
            Account a3 = new Account("Ozzy");
            //SpyNotifications spy = new SpyNotifications(a2);
            //a1.Send(a1.CreateMessage("Hi, Ann! How are you?", a2));
            //a1.Send(a1.CreateMessage("I'm Alex, from Kyiv", a2));
            //a2.Send(a2.CreateMessage("Hi, Alex! I'm from Lviv", a1));
            //a1.ShowDialog(a2.Username);
            Group g1= a1.CreateGroup("Concert");
            g1.AddMember(a1, a2);
            g1.AddMember(a1, a3);
            //g1.Send(a2.CreateMessage("Welcome all", g1));
            //g1.Send(a2.CreateMessage("Welcome all", g1))
            a2.Send(a2.CreateMessage("Welcome all", g1));
            g1.ChangeNotifyType(a3, NotifyType.Simple);
            a3.Send(a3.CreateMessage($"Hi my name is {a3}", g1));
        }
    }
}
