using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.GameEngine
{
    public class Battle
    {
        private readonly IDice _dice;
        private readonly IFighter _secondFighter;
        private readonly IFighter _startingFighter;

        public Battle(IFighter startingFighter, IFighter secondFighter, IDice dice)
        {
            _startingFighter = startingFighter;
            _secondFighter = secondFighter;
            _dice = dice;
        }

        public IFighter GetWinner()
        {
            while (true)
            {
                var hitStrength = _startingFighter.GetHitStrength(_dice);
                _secondFighter.DecreaseHealth(hitStrength);

                if (_secondFighter.HealthPoints <= 0)
                    return _startingFighter;

                hitStrength = _secondFighter.GetHitStrength(_dice);
                _startingFighter.DecreaseHealth(hitStrength);

                if (_startingFighter.HealthPoints <= 0)
                    return _secondFighter;
            }
        }
    }
}