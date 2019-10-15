using StrategyGame.Base.Interfaces;

namespace StrategyGame.Warriors.Interfaces
{
    public interface IRangeUnit
    {
        int Range { get; set; }
        void RangeAttack(IUnit enemy);
    }
}
