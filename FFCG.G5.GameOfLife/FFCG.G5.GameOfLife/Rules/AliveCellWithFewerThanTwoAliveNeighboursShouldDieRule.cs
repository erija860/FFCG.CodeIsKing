namespace FFCG.G5.GameOfLife.Rules
{
    public class AliveCellWithFewerThanTwoAliveNeighboursShouldDieRule : ICellLiveRule
    {
        public bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive) =>
            neighbourCount >= 2
            && isAlive;
    }
}