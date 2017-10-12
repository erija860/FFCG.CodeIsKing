using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.GameOfLife.Tests
{
    [TestFixture]
    public class When_toggling_cell_status
    {
        private GameOfLife _game;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _game = new GameOfLife(2,2);
        }

        [Test]
        public void Cell_should_toggle_between_dead_and_alive()
        {
            _game.Cells[0, 0].IsAlive.Should().BeFalse();
            _game.ToggleCellStatus(0,0);
            _game.Cells[0, 0].IsAlive.Should().BeTrue();
            _game.ToggleCellStatus(0, 0);
            _game.Cells[0, 0].IsAlive.Should().BeFalse();
        }
    }
}