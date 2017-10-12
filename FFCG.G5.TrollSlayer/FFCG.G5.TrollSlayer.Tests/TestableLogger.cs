using System.Collections.Generic;
using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Tests
{
    public class TestableLogger : ILogger
    {
        public TestableLogger()
        {
            LoggedEvents = new List<string>();
        }

        public List<string> LoggedEvents { get; }

        public void Log(string message)
        {
            LoggedEvents.Add(message);
        }
    }
}