using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.TrollSlayer.Tests.Extensions
{
    [TestFixture]
    public class When_eating_trolls_ear
    {
        private IPlayer _player;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var logger = new TestableLogger();
            _player = new Player(new TestableLogger(), new CharacterCriticalStrikeRule());
            _player.EatTrollsEar(new TestableDice(1),logger.Log);
        }

        [Test]
        public void Should_increase_health()
        {
            _player.HealthPoints.Should().Be(1);
        }
    }
}