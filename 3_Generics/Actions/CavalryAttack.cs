using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Interfaces;
using StrategyGame.Warriors.Models.Cavalry;
using System;
using System.Collections.Generic;
using static ITEA_Collections.Common.Extensions;
using System.Text;

namespace StrategyGame.Actions
{
    class CavalryAttack<T> : Battle<Knight, T> where T:CombatUnit,IRangeUnit, new()

    {
        private CavalryAttack() { }

        public CavalryAttack(IEnumerable<Knight> army1, IEnumerable<T> army2) : base(army1, army2)
        {

        }
        protected virtual int CountPoints(IEnumerable<T> army)
        {
            int total = 0;
            int count = 0;
            foreach (T item in army)
            {
                count++;
                total += item.Health + (int)(item.Strength * (item.UnitType == CombatUnitType.Melee ? 1 : 2));
            }
            ToConsole($"Total army count: {count}", ConsoleColor.DarkYellow);
            ToConsole($"Total army strength: {total}", ConsoleColor.DarkYellow);
            return total;
        }
    }
}
