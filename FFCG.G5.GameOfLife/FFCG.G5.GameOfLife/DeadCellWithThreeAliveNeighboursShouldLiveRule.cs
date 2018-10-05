using FFCG.G5.GameOfLife.Rules;

namespace FFCG.G5.GameOfLife
{
    public class DeadCellWithThreeAliveNeighboursShouldLiveRule : ICellLiveRule
    {
        public bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive) =>
            neighbourCount == 3
            && !isAlive;
    }
}