using System;
using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.Extensions;
using FFCG.G5.TrollSlayer.Interfaces;
using FFCG.G5.TrollSlayer.Rules;

namespace FFCG.G5.TrollSlayer.GameEngine
{
    public class TrollSlayerStoryGame
    {
        private readonly IDice _dice;
        private readonly Action<string> _log;
        private readonly IPlayer _player;
        private readonly IPlayerEquipmentRule _playerEquipmentRule;
        private readonly ITrollFactory _trollFactory;

        public TrollSlayerStoryGame(ILogger logger, 
            IDice dice, ITrollFactory trollFactory, IPlayer player,
            IPlayerEquipmentRule playerEquipmentRule)
        {
            _log = logger.Log;
            _dice = dice;
            _trollFactory = trollFactory;
            _player = player;
            _playerEquipmentRule = playerEquipmentRule;
        }

        public void Run()
        {
            PlayerWakesUp(_player);
            WalkUntilDeathOrEndOfTunnel(_player);
        }

        private void PlayerWakesUp(IPlayableCharacter player)
        {
            _log("Player wakes up...");
            player.Walk(_dice.Roll(50));

            _log("Player found some weapons and clothes.");
            _player.IncreaseHealth(_playerEquipmentRule.StartHealth);
            _player.IncreaseStrength(_playerEquipmentRule.StartStrength);

            player.WalkWithChanceOfStrengthIncrease(_dice, 50);
        }

        private void WalkUntilDeathOrEndOfTunnel<T>(T player) 
            where T : IPlayableCharacter, IFighter
        {
            while (player.HealthPoints > 0)
            {
                var troll = _trollFactory.GetTroll();

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
}