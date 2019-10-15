using StrategyGame.Base.Interfaces;

namespace StrategyGame.Warriors.Abstractions
{
    public enum CombatUnitType
    {
        Melee,
        Range
    }

    public abstract class CombatUnit : IUnit
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public CombatUnitType UnitType { get; set; }

        protected CombatUnit(int hp, int strength, CombatUnitType unitType)
        {
            Health = hp;
            Strength = strength;
            UnitType = unitType;
        }

        public abstract void MeleeAttack(IUnit unit);

        public virtual string Unnamed() => "Chaaaarge!";
    }
}
