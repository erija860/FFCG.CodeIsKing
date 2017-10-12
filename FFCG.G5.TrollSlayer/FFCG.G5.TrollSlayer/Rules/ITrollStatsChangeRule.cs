namespace FFCG.G5.TrollSlayer.Rules
{
    public interface ITrollStatsChangeRule
    {
        int BaseHealthChangePerInstance { get; }
        int BaseStrengthChangePerInstance { get; }
    }
}