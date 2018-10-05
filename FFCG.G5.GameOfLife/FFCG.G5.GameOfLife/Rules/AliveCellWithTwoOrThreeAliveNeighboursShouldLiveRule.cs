namespace FFCG.G5.GameOfLife.Rules
{
    public class AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule : ICellLiveRule
    {
        public bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive) =>
            (neighbourCount == 2 || neighbourCount == 3)
            && isAlive;
    }
}