using StrategyGame.Buildings.Intrefaces;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;
using System;
using System.Collections.Generic;
using System.Text;
using static ITEA_Collections.Common.Extensions;
namespace StrategyGame.Actions
{
    public class CavalryAttack<T> : Battle<Knight, T> where T : CombatUnit, IRangeUnit, new()
    {
        protected CavalryAttack() { }

        public CavalryAttack(IEnumerable<Knight> army1, IEnumerable<T> army2)
        {
            this.army1 = army1;
            this.army2 = army2;
        }
        protected override int CountPoints(IEnumerable<CombatUnit> army)
        {
            int total = 0;
            int count = 0;
            foreach (var item in army)
            {
                count++;
                total += item.Health + (int)(item.Strength * (item.UnitType == CombatUnitType.Melee ? 2 : 1.5));
            }
            ToConsole($"Total army count: {count}", ConsoleColor.DarkYellow);
            ToConsole($"Total army strength: {total}", ConsoleColor.DarkYellow);
            return total;
        }
    }
}
