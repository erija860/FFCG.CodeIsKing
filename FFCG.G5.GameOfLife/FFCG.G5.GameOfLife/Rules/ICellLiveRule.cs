namespace FFCG.G5.GameOfLife
{
    public interface ICellLiveRule
    {
        bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive);
    }
}