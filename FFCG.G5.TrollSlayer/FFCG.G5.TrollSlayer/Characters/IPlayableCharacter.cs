namespace FFCG.G5.TrollSlayer.Characters
{
    public interface IPlayableCharacter
    {
        int WalkedMeters { get; }
        void Walk(int meters);
        void IncreaseStrength(int amountIncreased);
        void IncreaseHealth(int amountIncreased);
    }
}