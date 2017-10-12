namespace FFCG.G5.GameOfLife
{
    public class AliveCellWithTwoOrThreeAliveNeighboursShouldLiveRule : ICellLiveRule
    {
        public bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive) =>
            (neighbourCount == 2 || neighbourCount == 3)
            && isAlive;
    }
}