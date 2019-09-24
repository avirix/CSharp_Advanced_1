using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Buildings
{
    class BowmanBarrack : Barrack
    {
        public BowmanBarrack(string n) : base(n)
        {

        }
        public override CombatUnit CreateUnit()
        {
            return new Bowman();
        }
    }
}
