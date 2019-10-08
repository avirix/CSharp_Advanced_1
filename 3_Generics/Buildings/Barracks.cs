using System;
using System.Collections.Generic;

using StrategyGame.Warriors.Models.Infantry;

namespace StrategyGame.Buildings
{

    public class Barracks
    {
        public readonly Dictionary<Type, int> warriorsCost = new Dictionary<Type, int>
        {
             {typeof(Pikeman), 11},
             {typeof(Bowman), 8},
             {typeof(Gunner), 15}
        };

        protected Barracks() { }
    }
}
