using System;

namespace CIK_Kata1
{
    internal class TestEngineFizzBuzz
    {
        internal void runTests()
        {
            CorrectReturnedNumberAnswer();
            ShouldNotReturnNumberAnswer();
            CorrectReturnedBuzzAnswer();
            ShouldNotReturnBuzzAnswer();
            CorrectReturnedFizzAnswer();
            CorrectReturnedFizzBuzzAnswer();
            CorrectReturnedFizzBuzzAnswerCheck2();
        }

        private void CorrectReturnedNumberAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(1);
            TestClass.AreEqual(true, receivedAnswer.GetType() == typeof(Number),
                "Should return Number");
        }

        private void ShouldNotReturnNumberAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer shouldNotBeNumber = testFactory.getAnswer(10);
            TestClass.AreNotEqual(new Number(1), shouldNotBeNumber,
                "Should not return Number");
        }

        private void CorrectReturnedBuzzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(5);
            TestClass.AreEqual(true, receivedAnswer.GetType() == typeof(Buzz),
                "Should return Buzz");
        }

        private void ShouldNotReturnBuzzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(4);
            TestClass.AreFalse(receivedAnswer.GetType() == typeof(Buzz),
                "Should not return Buzz");
        }

        private void CorrectReturnedFizzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(3);
            TestClass.AreEqual(true, receivedAnswer.GetType() == typeof(Fizz),
                "Should return Fizz");
        }

        private void CorrectReturnedFizzBuzzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(15);
            TestClass.AreEqual(true, receivedAnswer.GetType() == typeof(FizzBuzz),
                "Should return FizzBuzz");
        }
        private void CorrectReturnedFizzBuzzAnswerCheck2()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(60);
            TestClass.AreTrue(receivedAnswer.GetType() == typeof(FizzBuzz),
                "Should return FizzBuzz");
        }
    }
}