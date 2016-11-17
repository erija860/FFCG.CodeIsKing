using System;

namespace FFCG.G5.DiceGame
{
    public class DiceGame
    {
        private Dice _dice;

        public DiceGame()
        {
            UserPoints = 0;
        }

        public int UserGuess { get; set; }

        public int UserPoints { get; private set; }

        public void SetupDiceRandomizer(IRandom randomizer)
        {
            _dice = new Dice(randomizer);
        }
        public void RunGame(IUserInput inputStream)
        {


            /*IRandom randomizer = new Randomizer(maxValueOfDice);
            var dice = new Dice(randomizer);*/


            Console.WriteLine("New roll: " + _dice.RollDice());

            while (true)
            {
                Console.WriteLine("Guess 0 for lower or 1 for higher:");

                UserGuess = int.Parse(inputStream.GetInput());
                Console.WriteLine("New roll: " + _dice.RollDice());

                if (!GetRoundResult(_dice))
                    break;
            }
        }

        public bool GetRoundResult(Dice dice)
        {
            if (ConditionForNewRound(dice))
            {
                IncrementUserPoints();
                return true;
            }
            Console.WriteLine("Game over. You gained {0} points", UserPoints);
            return false;
        }

        private bool ConditionForNewRound(Dice dice)
        {
            return ((UserGuess == 0) && (dice.NewDiceValue < dice.OldDiceValue))
                   || ((UserGuess == 1) && (dice.NewDiceValue > dice.OldDiceValue));
        }

        private void IncrementUserPoints()
        {
            UserPoints++;
        }
    }
}