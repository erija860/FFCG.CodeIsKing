using System;
using System.Collections.Generic;

namespace FFCG.G5.DiceGame
{
    public interface IUserInput
    {
        string GetInput();
    }

    /* public static int Get_Commands(IUserInput input)
     {
         do
         {
             string noOfCommands = input.GetInput();
             // Rest of code here
         }
}*/

    public class UserInputStream : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }

    // Unit Test
    public class FakeUserInputStream : IUserInput
    {
        private readonly List<string> _cheatInts;
        private int _intToReturn;

        public FakeUserInputStream()
        {
            _cheatInts = new List<string> { "1", "0", "1", "0" };
            _intToReturn = -1;
        }

        public string GetInput()
        {
            _intToReturn++;
            return _cheatInts[_intToReturn];
        }
    }

    /* public void TestThisCode()
             {
                 GetCommands(new FakeUserInput());
             }*/
}