using System;
using System.Collections.Generic;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;

namespace StrategyGame.Buildings
{
    public abstract class Barrack
    {
        public string Name { get; set; }
        public Barrack(string n)
        {
            Name = n;
        }
        abstract public CombatUnit CreateUnit();

    }
}
