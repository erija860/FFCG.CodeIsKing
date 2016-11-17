using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.DiceGame.Tests
{
    [TestClass]
    public class DiceGameTests
    {
        private Dice _defaultDice;
        private DiceGame _diceGame;

        [TestInitialize]
        public void SetUp()
        {
            _diceGame = new DiceGame();
            var randomizer = new Randomizer(6);
            _diceGame.SetupDiceRandomizer(randomizer);
            _defaultDice = new Dice(randomizer);
        }

        [TestMethod]
        public void Diceroll_Returns_Some_Value()
        {
            var result = _defaultDice.RollDice();
            Assert.IsTrue(result.ToString() != null);
        }

        [TestMethod]
        public void Diceroll_Returns_Number_Lower_Than_Max_Value()
        {
            var result = _defaultDice.RollDice();
            Assert.IsTrue(result <= 6);
        }

        [TestMethod]
        public void Diceroll_Returns_Number_Higher_Than_Zero()
        {
            var result = _defaultDice.RollDice();
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void User_Can_Enter_Guess()
        {
            _diceGame.UserGuess = 0;
            Assert.AreEqual(0, _diceGame.UserGuess);
        }

        [TestMethod]
        public void Game_Round_Should_Return_False()
        {
            var randomizer = new CheatRandomizer(new List<int> { 1, 2, 3, 4 });
            var cheatDice = new Dice(randomizer);
            cheatDice.RollDice();
            _diceGame.UserGuess = 0;
            cheatDice.RollDice();
            Assert.IsFalse(_diceGame.GetRoundResult(cheatDice));
        }

        [TestMethod]
        public void Game_Round_Should_Return_True()
        {
            var randomizer = new CheatRandomizer(new List<int> { 1, 2, 3, 4 });
            var cheatDice = new Dice(randomizer);
            cheatDice.RollDice();
            _diceGame.UserGuess = 1;
            cheatDice.RollDice();
            Assert.IsTrue(_diceGame.GetRoundResult(cheatDice));
        }

        [TestMethod]
        public void Two_Right_Guesses_Should_Give_Two_Points()
        {
            var randomizer = new CheatRandomizer(new List<int> { 1, 2, 3, 4 });
            var cheatDice = new Dice(randomizer);
            var diceGame = new DiceGame();
            //diceGame.SetupDiceRandomizer(randomizer);
            cheatDice.RollDice();
            diceGame.UserGuess = 1;
            cheatDice.RollDice();
            diceGame.GetRoundResult(cheatDice);
            diceGame.UserGuess = 1;
            cheatDice.RollDice();
            diceGame.GetRoundResult(cheatDice);
            var pointsGained = diceGame.UserPoints;
            Assert.IsTrue(pointsGained == 2);
        }

        [TestMethod]
        public void Right_Guess_Of_Lower_Number_Should_Give_A_Point()
        {
            var randomizer = new CheatRandomizer(new List<int> { 6, 5, 4, 3 });
            var cheatDice = new Dice(randomizer);
            var diceGame = new DiceGame();
            cheatDice.RollDice();
            diceGame.UserGuess = 0;
            cheatDice.RollDice();
            diceGame.GetRoundResult(cheatDice);
            var pointsGained = diceGame.UserPoints;
            Assert.IsTrue(pointsGained == 1);
        }

        [TestMethod]
        public void Test_RunGame()
        {
            IUserInput userInputStream = new FakeUserInputStream();
            _diceGame.RunGame(userInputStream);
        }
    }
}