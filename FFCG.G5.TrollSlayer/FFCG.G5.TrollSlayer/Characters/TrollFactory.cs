using FFCG.G5.TrollSlayer.Interfaces;
using FFCG.G5.TrollSlayer.Rules;

namespace FFCG.G5.TrollSlayer.Characters
{
    public class TrollFactory : ITrollFactory
    {
        private readonly IDice _dice;
        private readonly int _healthChangePerInstance;
        private readonly ILogger _logger;
        private readonly int _strengthChangePerInstance;
        private int _baseHealth;
        private int _baseStrength;

        public TrollFactory(ITrollStartupRule trollStartupRule, ITrollStatsChangeRule trollStatsChangeRule, IDice dice,
            ILogger logger)
        {
            _dice = dice;
            _logger = logger;
            _baseHealth = trollStartupRule.StartHealth;
            _baseStrength = trollStartupRule.StartStrength;
            _healthChangePerInstance = trollStatsChangeRule.BaseHealthChangePerInstance;
            _strengthChangePerInstance = trollStatsChangeRule.BaseStrengthChangePerInstance;
        }

        public ITroll GetTroll()
        {
            var troll = new Troll(_dice.Roll(_baseStrength), _dice.Roll(_baseHealth), _logger);
            _baseHealth += _healthChangePerInstance;
            _baseStrength += _strengthChangePerInstance;
            return troll;
        }
    }
}