using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.GameEngine;
using FFCG.G5.TrollSlayer.Rules;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.TrollSlayer.Tests.GameEngine
{
    [TestFixture]
    public class When_running_a_new_game
    {
        private TrollSlayerStoryGame _game;
        private TestableLogger _logger;
        private TestableDice _dice;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _logger = new TestableLogger();
            _dice = new TestableDice(1);

            _game = new TrollSlayerStoryGame(
                _logger,
                _dice,
                new TrollFactory(
                    new TrollStartupRule(),
                    new TrollStatsChangeRule(),
                    _dice,
                    _logger),
                new Player(
                    _logger,
                    new CharacterCriticalStrikeRule()),
                new PlayerEquipmentRule());

            _game.Run();
        }

        [Test]
        public void Should_have_logged_to_logger()
        {
            _logger.LoggedEvents.Count.Should().BeGreaterThan(0);
        }
    }
}