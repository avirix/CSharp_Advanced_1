using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Buildings
{
    class KnightBarrack : Barrack 
    {
        public KnightBarrack(string n) : base(n)
        {

        }
        public override CombatUnit CreateUnit()
        {
            return new Knight();
        }
    }
}
