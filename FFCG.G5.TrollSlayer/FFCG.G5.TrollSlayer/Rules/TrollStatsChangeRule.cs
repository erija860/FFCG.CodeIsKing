namespace FFCG.G5.TrollSlayer.Rules
{
    public class TrollStatsChangeRule : ITrollStatsChangeRule
    {
        public int BaseHealthChangePerInstance => 2;
        public int BaseStrengthChangePerInstance => 1;
    }
}