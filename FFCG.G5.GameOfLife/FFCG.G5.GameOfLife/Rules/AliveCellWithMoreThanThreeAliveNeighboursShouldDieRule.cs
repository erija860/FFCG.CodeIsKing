namespace FFCG.G5.GameOfLife.Rules
{
    public class AliveCellWithMoreThanThreeAliveNeighboursShouldDieRule : ICellLiveRule
    {
        public bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive) =>
            neighbourCount <= 3
            && isAlive;
    }
}