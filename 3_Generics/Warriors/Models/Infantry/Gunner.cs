using StrategyGame.Warriors.Abstractions;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Gunner : CombatUnit
    {
        public Gunner() : base(7, 12, CombatUnitType.Range)
        {
        }
    }
}
