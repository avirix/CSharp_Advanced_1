using StrategyGame.Base.Interfaces;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Interfaces;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Bowman : CombatUnit, IRangeUnit
    {
        public int Range { get; set; }

        public Bowman() : base(10, 6, CombatUnitType.Range)
        {
        }

        public void RangeAttack(IUnit enemy)
        {
        }

        public override void MeleeAttack(IUnit unit)
        {
            throw new System.NotImplementedException();
        }
    }
}
