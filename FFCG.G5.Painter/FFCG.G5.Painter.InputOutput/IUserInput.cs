using System;
using System.Collections.Generic;
using System.IO;

namespace FFCG.G5.Painter.InputOutput
{
    public interface IUserInput
    {
        string GetInput();
    }

    public class UserInputStream : IUserInput
    {
        private readonly TextReader _stream;

        public UserInputStream()
        {
            _stream = Console.In;
        }

        public string GetInput()
        {
            var readLine = _stream.ReadLine();
            return readLine?.Trim() ?? "";
        }
    }

    public class FakeUserInputStream : IUserInput
    {
        private readonly List<string> _cheatStrings;
        private int _placeToReturn;

        public FakeUserInputStream()
        {
            _cheatStrings = new List<string> { "1", "2", "3", "0" }; //Default strings
            _placeToReturn = -1;
        }

        public FakeUserInputStream(List<string> inputs)
        {
            _cheatStrings = inputs;
            _placeToReturn = -1;
        }

        public string GetInput()
        {
            _placeToReturn++;
            return _cheatStrings[_placeToReturn];
        }
    }
}