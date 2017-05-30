using System;

namespace FFCG.G5.TrollSlayer
{
    public class TrollSlayerStoryGame
    {
        private readonly IDice _dice;
        private readonly ITrollFactory _trollFactory;
        private readonly Action<string> _log;

        public TrollSlayerStoryGame(ILogger logger, IDice dice, ITrollFactory trollFactory)
        {
            _log = logger.Log;
            _dice = dice;
            _trollFactory = trollFactory;
        }

        public void RunNewRound(IPlayer player)
        {
            PlayerWakesUp(player);
            WalkUntilDeathOrEndOfTunnel(player);
        }

        private void PlayerWakesUp(IPlayableCharacter player)
        {
            _log("Player wakes up...");
            player.Walk(_dice.Roll(50));

            _log("Player found some weapons and clothes.");

            player.WalkWithChanceOfStrengthIncrease(_dice, 50);
        }

        private void WalkUntilDeathOrEndOfTunnel<T>(T player) where T : IPlayableCharacter, IFighter
        {
            while (player.HealthPoints > 0)
            {
                var troll = new TrollLogWrapper(_trollFactory.GetTroll(), _log);

                _log($"You encounter a troll!!! It has HP:{troll.HealthPoints}, Str:{troll.Strength}");

                var battle = new Battle(player, troll, _dice);
                var winner = battle.GetWinner();

                if (winner is IPlayableCharacter)
                {
                    _log("Troll died...");
                    player.EatTrollsEar(_dice, _log);
                }
                else
                {
                    _log($"Player died after {player.WalkedMeters} meters");
                    break;
                }

                player.WalkWithChanceOfStrengthIncrease(_dice, 50);
                if (player.WalkedMeters >= 1000)
                {
                    _log(
                        $"Player survived!! It exited the cave with {player.HealthPoints}hp and {player.Strength}strength");
                    break;
                }
            }
        }
    }

    public interface ITrollFactory
    {
        ITroll GetTroll();
    }

    public class TrollFactory : ITrollFactory
    {
        private readonly IDice _dice;
        private int _baseHealth;
        private int _baseStrength;
        private readonly int _healthChangePerInstance;
        private readonly int _strengthChangePerInstance;

        public TrollFactory(ITrollStartupRule trollStartupRule, ITrollStatsChangeRule trollStatsChangeRule, IDice dice)
        {
            _dice = dice;
            _baseHealth = trollStartupRule.StartHealth;
            _baseStrength = trollStartupRule.StartStrength;
            _healthChangePerInstance = trollStatsChangeRule.BaseHealthChangePerInstance;
            _strengthChangePerInstance = trollStatsChangeRule.BaseStrengthChangePerInstance;
        }

        public ITroll GetTroll()
        {
            var troll = new Troll(_dice.Roll(_baseStrength), _dice.Roll(_baseHealth));
            _baseHealth += _healthChangePerInstance;
            _baseStrength += _strengthChangePerInstance;
            return troll;
        }
    }

    public interface ITrollStatsChangeRule
    {
        int BaseHealthChangePerInstance { get; }
        int BaseStrengthChangePerInstance { get; }
    }

    public class TrollStatsChangeRule : ITrollStatsChangeRule
    {
        public int BaseHealthChangePerInstance => 2;
        public int BaseStrengthChangePerInstance => 1;
    }

    public interface ITrollStartupRule : ICharacterStartupRule
    {
    }

    public class TrollStartupRule : ITrollStartupRule
    {
        public int StartStrength => 19;
        public int StartHealth => 20;
    }

    public static class PlayableCharacterExtensions
    {
        public static void WalkWithChanceOfStrengthIncrease(this IPlayableCharacter player, IDice dice, int sides)
        {
            var meters = dice.Roll(sides);
            player.Walk(meters);

            if (meters % 3 == 0)
                player.IncreaseStrength(dice.Roll(5));
        }

        public static void EatTrollsEar(this IPlayableCharacter player, IDice dice, Action<string> log)
        {
            var newHp = dice.Roll(20);
            log("Player eats the trolls ear.");
            player.IncreaseHealth(newHp);
        }
    }

    public class Battle
    {
        private readonly IDice _dice;
        private readonly IFighter _secondFighter;
        private readonly IFighter _startingFighter;

        public Battle(IFighter startingFighter, IFighter secondFighter, IDice dice)
        {
            _startingFighter = startingFighter;
            _secondFighter = secondFighter;
            _dice = dice;
        }

        public IFighter GetWinner()
        {
            while (true)
            {
                var hitStrength = _startingFighter.GetHitStrength(_dice);
                _secondFighter.DecreaseHealth(hitStrength);

                if (_secondFighter.HealthPoints <= 0)
                    return _startingFighter;

                hitStrength = _secondFighter.GetHitStrength(_dice);
                _startingFighter.DecreaseHealth(hitStrength);

                if (_startingFighter.HealthPoints <= 0)
                    return _secondFighter;
            }
        }
    }

    public class TrollLogWrapper : IFighter
    {
        private readonly Action<string> _log;
        private readonly ITroll _troll;

        public TrollLogWrapper(ITroll troll, Action<string> log)
        {
            _troll = troll;
            _log = log;
        }

        public int HealthPoints => _troll.HealthPoints;
        public int Strength => _troll.Strength;

        public void DecreaseHealth(int amountDecreased)
        {
            _log($"Troll lost {amountDecreased} health.");
            _troll.DecreaseHealth(amountDecreased);
            if (_troll.HealthPoints > 0)
                _log($"Total {_troll.HealthPoints} health.");
        }

        public int GetHitStrength(IDice dice)
        {
            var hitstrength = _troll.GetHitStrength(dice);
            _log($"Troll hits with {hitstrength} hitstrength.");
            return hitstrength;
        }
    }

    public class PlayerLogWrapper : IPlayer
    {
        private readonly ILogger _logger;
        private readonly Player _player;

        public PlayerLogWrapper(Player player, ILogger logger)
        {
            _player = player;
            _logger = logger;
        }

        public int HealthPoints => _player.HealthPoints;

        public int Strength => _player.Strength;

        public void DecreaseHealth(int amountDecreased)
        {
            _logger.Log($"Player lost {amountDecreased} health.");
            _player.DecreaseHealth(amountDecreased);
            if (_player.HealthPoints > 0)
                _logger.Log($"Total {_player.HealthPoints} health.");
        }

        public int GetHitStrength(IDice dice)
        {
            var hitstrength = _player.GetHitStrength(dice);
            _logger.Log($"Player hits with {hitstrength} hitstrength.");
            return hitstrength;
        }

        public void IncreaseHealth(int amountIncreased)
        {
            _logger.Log($"Player gained {amountIncreased} health.");
            _player.IncreaseHealth(amountIncreased);
            _logger.Log($"Total {_player.HealthPoints} health.");
        }

        public void IncreaseStrength(int amountIncreased)
        {
            _logger.Log($"Player gained {amountIncreased} strength.");
            _player.IncreaseStrength(amountIncreased);
            _logger.Log($"Total {_player.Strength} strength.");
        }

        public int WalkedMeters => _player.WalkedMeters;

        public void Walk(int meters)
        {
            _logger.Log($"Player walked {meters} meters.");
            _player.Walk(meters);
            if (_player.WalkedMeters < 1000)
                _logger.Log($"Total walked {_player.WalkedMeters} meters.");
        }
    }

    public interface IPlayer : IPlayableCharacter, IFighter
    {
    }

    public class Player : IPlayer
    {
        public Player(IPlayerStartupRule startupRule)
        {
            HealthPoints = startupRule.StartHealth;
            Strength = startupRule.StartStrength;
        }

        public int HealthPoints { get; private set; }
        public int Strength { get; private set; }

        public void DecreaseHealth(int amountDecreased)
        {
            HealthPoints -= amountDecreased;
        }

        public int GetHitStrength(IDice dice)
        {
            var hitStrength = dice.Roll(Strength);

            if (hitStrength % 3 == 0)
                hitStrength = hitStrength * 2;

            return hitStrength;
        }

        public void IncreaseHealth(int amountIncreased)
        {
            HealthPoints += amountIncreased;
        }

        public void IncreaseStrength(int amountIncreased)
        {
            Strength += amountIncreased;
        }

        public int WalkedMeters { get; private set; }

        public void Walk(int meters)
        {
            WalkedMeters += meters;
        }
    }

    public interface IPlayerStartupRule : ICharacterStartupRule
    {
    }

    public interface ICharacterStartupRule
    {
        int StartStrength { get; }
        int StartHealth { get; }
    }

    public class PlayerStartupRule : IPlayerStartupRule
    {
        public int StartStrength => 10;
        public int StartHealth => 40;
    }

    public interface ITroll : IFighter
    {
    }

    public class Troll : ITroll
    {
        public Troll(int strength, int health)
        {
            HealthPoints = health;
            Strength = strength;
        }

        public int HealthPoints { get; private set; }
        public int Strength { get; }

        public void DecreaseHealth(int amountDecreased)
        {
            HealthPoints -= amountDecreased;
        }

        public int GetHitStrength(IDice dice)
        {
            return dice.Roll(Strength);
        }
    }

    public interface IFighter
    {
        int HealthPoints { get; }
        int Strength { get; }
        void DecreaseHealth(int amountDecreased);
        int GetHitStrength(IDice dice);
    }

    public interface IPlayableCharacter
    {
        int WalkedMeters { get; }
        void Walk(int meters);
        void IncreaseStrength(int amountIncreased);
        void IncreaseHealth(int amountIncreased);
    }
}