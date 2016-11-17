using System;
using System.Collections.Generic;

namespace FFCG.G5.DiceGame
{
    public interface IRandom
    {
        int GetRandomNumber();
    }

    public class Randomizer : IRandom
    {
        private readonly int _maxValueOfDice;
        private readonly Random _rnd;

        public Randomizer(int maxValueOfDice)
        {
            _maxValueOfDice = maxValueOfDice;
            _rnd = new Random();
        }

        public int GetRandomNumber()
        {
            return _rnd.Next(1, _maxValueOfDice);
        }
    }

    public class CheatRandomizer : IRandom
    {
        private readonly List<int> _cheatInts;
        private int _intToReturn;
        // private readonly Random _rnd;


        public CheatRandomizer(List<int> cheatInts)
        {
            _cheatInts = cheatInts; //new List<int> { 1, 2, 3, 4 };
            _intToReturn = -1;
            // _rnd = new Random();
        }

        public int GetRandomNumber()
        {
            _intToReturn++;
            return _cheatInts[_intToReturn];
        }
    }
}