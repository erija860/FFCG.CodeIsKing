using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIK_Kata1
{
    class KataGame
    {

        static void Main(string[] args)
        {
            /*
            KataFizzBuzzGame game = new KataFizzBuzzGame();
            game.play();
            
            KataFizzBuzzGame game = new KataFizzBuzzGame();
            game.play();

            TestEngineFizzBuzz KataTests = new TestEngineFizzBuzz();
            KataTests.runTests();
            */


        }
    }

    class KataFizzBuzzGame
    {
        private int numberOfTurns;
        private AnswerFactory factory;
        private Answer nextAnswer;

        public KataFizzBuzzGame()
        {
            numberOfTurns = 100;
            factory = new ConcreteAnswerFactory2(); // Which factory to be used. 2 is testversion.
        }

        public void play()
        {
            for (int currentNumber = 1; currentNumber <= numberOfTurns; currentNumber++)
            {
                nextAnswer = factory.getAnswer(currentNumber);
                nextAnswer.speak();
            }
        }
    }
}
