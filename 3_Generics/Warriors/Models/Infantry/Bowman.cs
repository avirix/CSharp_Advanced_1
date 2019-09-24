using StrategyGame.Base.Interfaces;
using StrategyGame.Buildings.Intrefaces;
using StrategyGame.Warriors.Abstractions;

namespace StrategyGame.Warriors.Models.Infantry
{
    public sealed class Bowman : CombatUnit, IRangeUnit
    {
        public Bowman() : base(10, 6, CombatUnitType.Range)
        {
        }

        public int Range { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void RangeAttack(IUnit enemy)
        {
            throw new System.NotImplementedException();
        }
    }
}
