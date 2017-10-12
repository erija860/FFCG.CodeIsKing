using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Characters
{
    public class Player : IPlayer
    {
        private readonly ICharacterCriticalStrikeRule _characterCriticalStrikeRule;
        private readonly ILogger _logger;

        public Player(ILogger logger, ICharacterCriticalStrikeRule characterCriticalStrikeRule)
        {
            _logger = logger;
            _characterCriticalStrikeRule = characterCriticalStrikeRule;
        }

        public int HealthPoints { get; private set; }
        public int Strength { get; private set; }

        public void DecreaseHealth(int amountDecreased)
        {
            _logger.Log($"Player lost {amountDecreased} health.");
            HealthPoints -= amountDecreased;
            if (HealthPoints > 0)
                _logger.Log($"Total {HealthPoints} health.");
        }

        public int GetHitStrength(IDice dice)
        {
            var hitStrength = dice.Roll(Strength);

            if (hitStrength % _characterCriticalStrikeRule.DevidedByGivesCriticalHit == 0)
                hitStrength = hitStrength * _characterCriticalStrikeRule.CriticalHitPower;

            _logger.Log($"Player hits with {hitStrength} hitstrength.");

            return hitStrength;
        }

        public void IncreaseHealth(int amountIncreased)
        {
            _logger.Log($"Player gained {amountIncreased} health.");
            HealthPoints += amountIncreased;
            _logger.Log($"Total {HealthPoints} health.");
        }

        public void IncreaseStrength(int amountIncreased)
        {
            _logger.Log($"Player gained {amountIncreased} strength.");
            Strength += amountIncreased;
            _logger.Log($"Total {Strength} strength.");
        }

        public int WalkedMeters { get; private set; }

        public void Walk(int meters)
        {
            _logger.Log($"Player walked {meters} meters.");
            WalkedMeters += meters;
            if (WalkedMeters < 1000)
                _logger.Log($"Total walked {WalkedMeters} meters.");
        }
    }
}