using System.Collections.Generic;
using System.Linq;

using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Interfaces;

namespace StrategyGame.Actions
{
    public class Union<A1, A2> where A1 : CombatUnit, IRangeUnit, new()
                               where A2 : CombatUnit, IRangeUnit, new()
    {
        public IEnumerable<A1> First { get; private set; }
        public IEnumerable<A2> Second { get; private set; }

        public Union(IEnumerable<A1> first, IEnumerable<A2> second)
        {
            First = first;
            Second = second;
        }

        public IEnumerable<CombatUnit> Simple()
        {
            foreach (A1 item in First)
            {
                yield return item;
            }
            foreach (A2 item in Second)
            {
                yield return item;
            }

        }

        public IEnumerable<T> ToType<T>() where T : CombatUnit, IRangeUnit, new()
        {
            int count = First.ToList().Count + Second.ToList().Count;
            for (int i = 0; i < count; i++)
            {
                yield return new T();
            }
        }
    }
}
