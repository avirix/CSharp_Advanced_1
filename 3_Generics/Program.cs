using System;
using System.Collections.Generic;
using StrategyGame.Actions;
using StrategyGame.Warriors.Models.Infantry;
using static ITEA_Collections.Common.Extensions;


namespace StrategyGame
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Gunner> gunners = new List<Gunner>();
            for (int i = 0; i < 15; i++)
                gunners.Add(new Gunner());

            List<Pikeman> pikemen = new List<Pikeman>();
            for (int i = 0; i < 16; i++)
                pikemen.Add(new Pikeman());

            List<Bowman> bowmen = new List<Bowman>();
            for (int i = 0; i < 18; i++)
                bowmen.Add(new Bowman());

            var battle1 = new Battle<Gunner, Pikeman>(gunners, pikemen);
            ToConsole(battle1.CountResults(), ConsoleColor.Green);

            var battle2 = new Battle<Pikeman, Bowman>(pikemen, bowmen);
            ToConsole(battle2.CountResults(), ConsoleColor.Green);

            var battle3 = new RangeBattle(gunners, bowmen);
            ToConsole(battle3.CountResults(), ConsoleColor.Green);
        }
    }
}
