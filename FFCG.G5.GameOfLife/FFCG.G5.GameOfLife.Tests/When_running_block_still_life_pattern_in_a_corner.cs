using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.GameOfLife.Tests
{
    [TestFixture]
    public class When_running_block_still_life_pattern_in_a_corner
    {
        private GameOfLife _game;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _game = new GameOfLife(4,4);
            _game.ToggleCellStatus(0, 0);
            _game.ToggleCellStatus(0, 1);
            _game.ToggleCellStatus(1, 0);
            _game.ToggleCellStatus(1, 1);
        }

        [Test]
        public void Alive_cells_should_be_constant()
        {
            _game.Cells[0, 0].IsAlive.Should().BeTrue();
            _game.Cells[0, 1].IsAlive.Should().BeTrue();
            _game.Cells[1, 0].IsAlive.Should().BeTrue();
            _game.Cells[1, 1].IsAlive.Should().BeTrue();

            _game.UpdateToNextGeneration();

            _game.Cells[0, 0].IsAlive.Should().BeTrue();
            _game.Cells[0, 1].IsAlive.Should().BeTrue();
            _game.Cells[1, 0].IsAlive.Should().BeTrue();
            _game.Cells[1, 1].IsAlive.Should().BeTrue();
        }
    }
}