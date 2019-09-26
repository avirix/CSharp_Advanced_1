using StrategyGame.Base.Interfaces;
using StrategyGame.Warriors.Abstractions;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Pikeman : CombatUnit
    {
        public Pikeman() : base(14, 8, CombatUnitType.Melee)
        {
        }

        public override void MeleeAttack(IUnit unit)
        {
            throw new System.NotImplementedException();
        }
    }
}
