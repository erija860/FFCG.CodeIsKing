using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.GameEngine;
using FFCG.G5.TrollSlayer.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.TrollSlayer.Tests.GameEngine
{
    [TestFixture]
    public class When_fighting_a_battle
    {
        [SetUp]
        public void SetUp()
        {
            _logger = new TestableLogger();
            var player = new Player(_logger, new CharacterCriticalStrikeRule());
            player.IncreaseHealth(10);
            player.IncreaseStrength(10);
            _firstFighter = player;
            _secondFighter = new Troll(1, 1, _logger);
            var battle = new Battle(_firstFighter, _secondFighter, new TestableDice(10));
            _winner = battle.GetWinner();
        }

        private ILogger _logger;
        private IFighter _firstFighter;
        private IFighter _secondFighter;
        private IFighter _winner;

        [Test]
        public void Should_be_correct_winner()
        {
            _winner.GetType().Should().Be(typeof(Player));
        }
    }
}