using StrategyGame.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Buildings.Intrefaces
{
    public interface IRangeUnit
    {
        int Range { get; set; }
        void RangeAttack(IUnit enemy);
    }
}
