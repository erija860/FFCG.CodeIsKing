using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.GameOfLife.Tests
{
    [TestFixture]
    public class CellLiveRuleTests
    {
        [Test]
        public void AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule_should_survive()
        {
            var cell = new Cell(true, new List<ICellLiveRule>{new AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule()});
            var nextGeneration = cell.NextGenerationState(2);

            nextGeneration.IsAlive.Should().BeTrue();
        }

        [Test]
        public void AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule_should_die()
        {
            var cell = new Cell(true, new List<ICellLiveRule> { new AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule() });
            var nextGeneration = cell.NextGenerationState(1);

            nextGeneration.IsAlive.Should().BeFalse();
        }

        [Test]
        public void AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule_should_survive()
        {
            var cell = new Cell(true, new List<ICellLiveRule> { new AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule() });
            var nextGeneration = cell.NextGenerationState(3);

            nextGeneration.IsAlive.Should().BeTrue();
        }

        [Test]
        public void AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule_should_die()
        {
            var cell = new Cell(true, new List<ICellLiveRule> { new AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule() });
            var nextGeneration = cell.NextGenerationState(4);

            nextGeneration.IsAlive.Should().BeFalse();
        }

        [Test]
        public void AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule_should_die()
        {
            var cell = new Cell(true, new List<ICellLiveRule> { new AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule() });
            var nextGeneration = cell.NextGenerationState(4);

            nextGeneration.IsAlive.Should().BeFalse();
        }

        [Test]
        public void AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule_should_survive()
        {
            var cell = new Cell(true, new List<ICellLiveRule> { new AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule() });
            var nextGeneration = cell.NextGenerationState(3);

            nextGeneration.IsAlive.Should().BeTrue();
        }

        [Test]
        public void DeadCellWithThreeAliveNeighboursShouldLiveRule_should_stay_dead()
        {
            var cell = new Cell(false, new List<ICellLiveRule> { new DeadCellWithThreeAliveNeighboursShouldLiveRule() });
            var nextGeneration = cell.NextGenerationState(4);

            nextGeneration.IsAlive.Should().BeFalse();
        }

        [Test]
        public void DeadCellWithThreeAliveNeighboursShouldLiveRule_should_awake()
        {
            var cell = new Cell(false, new List<ICellLiveRule> { new DeadCellWithThreeAliveNeighboursShouldLiveRule() });
            var nextGeneration = cell.NextGenerationState(3);

            nextGeneration.IsAlive.Should().BeTrue();
        }
    }
}