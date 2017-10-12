using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Tests
{
    public class TestableDice : IDice
    {
        private readonly int _shouldAlwaysRoll;

        public TestableDice(int shouldAlwaysRoll)
        {
            _shouldAlwaysRoll = shouldAlwaysRoll;
        }

        public int Roll(int sides)
        {
            return _shouldAlwaysRoll;
        }
    }
}