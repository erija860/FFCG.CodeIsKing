using System;
using System.Linq;

namespace FFCG.CodeIsKing.BowlingGame
{
    public class BowlingGame
    {
        private IFrame[] _frames;
        private IFrame _currentFrame;

        public BowlingGame()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            _frames = new IFrame[10];
            for (var i = 0; i < 9; i++)
                _frames[i] = new Frame();

            _frames[9] = new TenthFrame();
            _currentFrame = _frames[0];
        }

        public void Roll(int pins)
        {
            _currentFrame.Roll(pins);
        }

        public int Score()
        {
            return _frames.Select(f => f.Score()).Sum();
        }
    }

    public interface IBowler
    {
        int Roll(int pinsStandingUp);
        void Cheer();
    }

    public class Bowler : IBowler
    {
        private readonly ILogger _logger;
        private readonly ISkillAlgorithm _skillAlgorithm;

        public Bowler(ISkillAlgorithm skillAlgorithm, ILogger logger)
        {
            _skillAlgorithm = skillAlgorithm;
            _logger = logger;
        }

        public int Roll(int pinsStandingUp)
        {
            return _skillAlgorithm.PinsAbleToGetDown(pinsStandingUp);
        }

        public void Cheer()
        {
            _logger.Log("WOOOOH!");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public interface ISkillAlgorithm
    {
        int PinsAbleToGetDown(int standingPins);
    }

    public interface IFrame
    {
        int Score();
        int GetPinsOfFirstRoll();
        int GetPinsOfTwoRolls();
    }

    public abstract class FrameBase : IFrame
    {
        protected Roll[] Rolls;

        public abstract int Score();

        public int GetPinsOfFirstRoll()
        {
            return Rolls[0]?.Pins ?? 0;
        }

        public int GetPinsOfTwoRolls()
        {
            return GetPinsOfFirstRoll() + Rolls[1]?.Pins ?? 0;
        }
    }

    public class Frame : FrameBase
    {
        private IFrame _nextFrame;

        public Frame()
        {
            Rolls = new Roll[2];
        }

        public void SetNextFrame(IFrame frame)
        {
            _nextFrame = frame;
        }

        public override int Score()
        {
            return Rolls[0].Pins + Rolls[1].Pins;
        }
    }

    public class Roll
    {
        public int Pins { get; set; }
    }

    public class TenthFrame : FrameBase
    {
        public TenthFrame()
        {
            Rolls = new Roll[3];
        }

        public override int Score()
        {
            throw new NotImplementedException();
        }
    }
}