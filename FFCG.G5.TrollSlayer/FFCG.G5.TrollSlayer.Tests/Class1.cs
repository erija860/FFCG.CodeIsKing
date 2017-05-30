using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.TrollSlayer.Tests
{
    public class Class1
    {
    }

    public class TestableLogger : ILogger
    {
        public TestableLogger()
        {
            LoggedEvents = new List<string>();
        }

        public List<string> LoggedEvents { get; }

        public void Log(string message)
        {
            LoggedEvents.Add(message);
        }
    }

    public class TestableDice : IDice {
        public int Roll(int sides)
        {
            return 1;
        }
    }

    [TestFixture]
    public class When_running_a_new_game
    {
        private TrollSlayerStoryGame _game;
        private TestableLogger _logger;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _logger = new TestableLogger();
            _game = new TrollSlayerStoryGame(_logger, new TestableDice());
            _game.RunNewRound();
        }

        [Test]
        public void Should_have_logged_to_logger()
        {
            _logger.LoggedEvents.Count.Should().BeGreaterThan(0);
        }
    }
}