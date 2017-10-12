using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.GameOfLife.Tests
{
    [TestFixture]
    public class When_running_blinker_oscillator_pattern
    {
        private GameOfLife _game;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _game = new GameOfLife(5,5);
            _game.ToggleCellStatus(1,2);
            _game.ToggleCellStatus(2,2);
            _game.ToggleCellStatus(3,2);
        }

        [Test]
        public void Alive_cells_should_toggle()
        {
            _game.Cells[1, 2].IsAlive.Should().BeTrue();
            _game.Cells[2, 2].IsAlive.Should().BeTrue();
            _game.Cells[3, 2].IsAlive.Should().BeTrue();

            _game.UpdateToNextGeneration();

            _game.Cells[2, 1].IsAlive.Should().BeTrue();
            _game.Cells[2, 2].IsAlive.Should().BeTrue();
            _game.Cells[2, 1].IsAlive.Should().BeTrue();

            _game.UpdateToNextGeneration();

            _game.Cells[1, 2].IsAlive.Should().BeTrue();
            _game.Cells[2, 2].IsAlive.Should().BeTrue();
            _game.Cells[3, 2].IsAlive.Should().BeTrue();
        }
    }
}