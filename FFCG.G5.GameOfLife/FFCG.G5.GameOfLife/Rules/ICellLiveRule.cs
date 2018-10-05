namespace FFCG.G5.GameOfLife.Rules
{
    public interface ICellLiveRule
    {
        bool ShouldLiveNextGeneration(int neighbourCount, bool isAlive);
    }
}