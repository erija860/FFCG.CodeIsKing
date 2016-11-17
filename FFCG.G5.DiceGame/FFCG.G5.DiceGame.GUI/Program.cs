using System;

namespace FFCG.G5.DiceGame.GUI
{
    internal class Program
    {
        private static void Main()
        {
            var diceGame = new DiceGame();
            Console.WriteLine("Choose number of sides on the dice:");
            var maxValueOfDice = int.Parse(Console.ReadLine());
            diceGame.SetupDiceRandomizer(new Randomizer(maxValueOfDice));
            IUserInput userInputStream = new UserInputStream();
            diceGame.RunGame(userInputStream);
            /*Console.WriteLine("Choose number of sides on the dice:");
            int maxValueOfDice = int.Parse(Console.ReadLine());

            IRandom randomizer = new Randomizer(maxValueOfDice);
            var diceGame = new DiceGame();
            var dice = new Dice(maxValueOfDice);


            Console.WriteLine("New roll: " + dice.RollDice());

            while (true)
            {
                Console.WriteLine("Enter 0 for lower or 1 for higher:");

                diceGame.UserGuess = int.Parse(Console.ReadLine());
                Console.WriteLine("New roll: " + dice.RollDice());

                if (!diceGame.GetRoundResult(dice))
                    break;
            }*/
        }
    }
}