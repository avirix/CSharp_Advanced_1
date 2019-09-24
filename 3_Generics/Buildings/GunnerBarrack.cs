using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Buildings
{
    class GunnerBarrack : Barrack
    {
        public GunnerBarrack(string n) : base(n)
        {

        }
        public override CombatUnit CreateUnit()
        {
            return new Gunner();
        }
    }
}
