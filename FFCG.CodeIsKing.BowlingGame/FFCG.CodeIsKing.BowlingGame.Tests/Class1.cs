using FakeItEasy;
using NUnit.Framework;

namespace FFCG.CodeIsKing.BowlingGame.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var game = new BowlingGame(new Bowler(A.Fake<ISkillAlgorithm>(), A.Fake<ILogger>()));
        }

        [Test]
        public void Should_return_correct_score()
        {
        }
    }
}