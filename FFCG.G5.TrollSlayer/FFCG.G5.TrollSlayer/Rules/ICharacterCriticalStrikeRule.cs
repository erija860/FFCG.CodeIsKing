namespace FFCG.G5.TrollSlayer.Characters
{
    public interface ICharacterCriticalStrikeRule
    {
        int DevidedByGivesCriticalHit { get; }
        int CriticalHitPower { get; }
    }
}