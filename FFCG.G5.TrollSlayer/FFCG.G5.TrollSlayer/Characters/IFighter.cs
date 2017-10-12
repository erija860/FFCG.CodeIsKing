using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Characters
{
    public interface IFighter
    {
        int HealthPoints { get; }
        int Strength { get; }
        void DecreaseHealth(int amountDecreased);
        int GetHitStrength(IDice dice);
    }
}