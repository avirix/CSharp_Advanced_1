using System;
using System.Collections.Generic;
using StrategyGame.Actions;
using StrategyGame.Buildings;
using StrategyGame.Warriors.Models.Infantry;
using static ITEA_Collections.Common.Extensions;


namespace StrategyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Resolver resolver = new Resolver();
            
            List<Gunner> gunners = new List<Gunner>();
            for (int i = 0; i < 15; i++)
                gunners.Add((Gunner)resolver.Get("Gunner"));

            List<Pikeman> pikemen = new List<Pikeman>();
            for (int i = 0; i < 16; i++)
                pikemen.Add((Pikeman)resolver.Get("Pikeman"));

            List<Bowman> bowmen = new List<Bowman>();
            for (int i = 0; i < 18; i++)
                bowmen.Add((Bowman)resolver.Get("Bowman"));

            List<Knight> knights = new List<Knight>();
            for (int i = 0; i < 18; i++)
                knights.Add((Knight)resolver.Get("Knight"));

            var battle1 = new Battle<Gunner, Pikeman>(gunners, pikemen);
            ToConsole(battle1.CountResults(), ConsoleColor.Green);

            var battle2 = new Battle<Pikeman, Bowman>(pikemen, bowmen);
            ToConsole(battle2.CountResults(), ConsoleColor.Green);

            var battle3 = new RangeBattle(gunners, bowmen);
            ToConsole(battle3.CountResults(), ConsoleColor.Green);

            var battle4 = new CavalryAttack<Gunner>(knights, gunners);
            ToConsole(battle4.CountResults(), ConsoleColor.Green);
        }
    }
}
