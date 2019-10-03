using System;
using System.Collections.Generic;
using System.Text;
using IteaDelegates.IteaMessanger;

namespace IteaLinq
{
   public class HwHelper
    {
        public HwHelper()
        {

        }
        public List<Account> CreateAccounts(int count)
        {
            List<Account> accounts = new List<Account>();
            for(int i = 0; i < count; i++)
                accounts.Add(new Account("Harryyyyyyyyyyyyyyyyyyyyyyyyyyy" + i.ToString()));
            return accounts;
        }
        public List<Group> CreateGroups(List<Account> accsForGroup, int countGroups, int countAccInGroup)
        {
            List<Group> groups = new List<Group>();
            for(int i = 0; i < countGroups; i++)
            {
                groups.Add(new Group(accsForGroup[i], "GROUP" + i.ToString()));
                for(int j = 1; j < countAccInGroup; j++)
                {
                    accsForGroup[j].Subscribe(groups[i], 1);
                }
            }
            return groups;
        }
        public void SendGroupMessages(List<Group> groups)
        {
            groups.ForEach(g => g.members.ForEach(m => m.CreateGroupMessage($"{m.Username}", g)));
            groups[0].members[0].CreateGroupMessage($"{groups[0].members[0].Username}", groups[0]);
            groups[0].members[1].CreateGroupMessage($"{groups[0].members[1].Username}", groups[0]);
            groups[0].members[2].CreateGroupMessage($"{groups[0].members[2].Username}", groups[0]);
        }
        public void SendMessagesToAccs(List<Account> accounts)
        {
            for(int i = 0; i < 3; i++)
            {
                accounts.ForEach(a => accounts[i].Send(accounts[i].CreateMessage($"Testttttttttttttttttttttttttttttt {a.Username}", a)));
                accounts[0].Send(accounts[0].CreateMessage("Alohaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accounts[1])); //Чтобы у одного аккаунта было явно больше сообщений
            }      
        }
    }
}
