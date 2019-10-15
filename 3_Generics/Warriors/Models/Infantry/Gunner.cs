using StrategyGame.Base.Interfaces;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Interfaces;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Gunner : CombatUnit, IRangeUnit
    {
        public int Range { get; set; }

        public Gunner() : base(7, 12, CombatUnitType.Range)
        {
        }

        public void RangeAttack(IUnit enemy)
        {
            enemy.Health -= this.Strength;
        }

        public override void MeleeAttack(IUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public override string Unnamed() => "Fire!";
    }
}
