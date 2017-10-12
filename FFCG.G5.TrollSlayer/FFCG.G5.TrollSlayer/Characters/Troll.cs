using System;
using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Characters
{
    public class Troll : ITroll
    {
        private readonly Action<string> _log;

        public Troll(int strength, int health, ILogger logger)
        {
            _log = logger.Log;
            HealthPoints = health;
            Strength = strength;
        }

        public int HealthPoints { get; private set; }
        public int Strength { get; }

        public void DecreaseHealth(int amountDecreased)
        {
            _log($"Troll lost {amountDecreased} health.");
            HealthPoints -= amountDecreased;
            if (HealthPoints > 0)
                _log($"Total {HealthPoints} health.");
        }

        public int GetHitStrength(IDice dice)
        {
            var hitstrength = dice.Roll(Strength);
            _log($"Troll hits with {hitstrength} hitstrength.");
            return hitstrength;
        }
    }
}