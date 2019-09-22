using StrategyGame.Warriors.Abstractions;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Bowman : CombatUnit
    {
        public Bowman() : base(10, 6, CombatUnitType.Range)
        {
        }
    }
}
