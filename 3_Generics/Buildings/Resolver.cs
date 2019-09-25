using StrategyGame.Base.Interfaces;
using StrategyGame.Warriors.Abstractions;
using StrategyGame.Warriors.Models.Infantry;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Buildings
{
    public class Resolver
    {
        private Barrack barrackBow = new BowmanBarrack("Bowmen");
        private Barrack barrackGunner = new GunnerBarrack("Gunners");
        private Barrack barrackPike = new PikemanBarrack("Pikemen");
        private Barrack barrackKnight = new KnightBarrack("Knights");
        public Resolver() { }
        public CombatUnit Get(string unitName)
        {
            switch (unitName)
            {
                case "Bowman":
                    return barrackBow.CreateUnit();
                case "Gunner":
                    return barrackGunner.CreateUnit();
                case "Pikeman":
                    return barrackPike.CreateUnit();
                case "Knight":
                    return barrackKnight.CreateUnit();
            }
            return null;
        }
    }
}
