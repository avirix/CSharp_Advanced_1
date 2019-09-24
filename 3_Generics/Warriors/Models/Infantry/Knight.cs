using StrategyGame.Warriors.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Knight : CombatUnit
    {
        public Knight() : base(12, 17, CombatUnitType.Melee)
        {
        }
    }
}
