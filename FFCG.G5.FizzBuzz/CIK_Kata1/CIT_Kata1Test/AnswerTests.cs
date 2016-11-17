using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIK_Kata1;

namespace CIK_Kata1Test
{
    [TestClass]
    public class AnswerTests
    {
        [TestMethod]
        public void CorrectReturnedNumberAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(1);
            Assert.AreEqual(true, receivedAnswer.GetType() == typeof(Number),
                "Wrong type of answer");
        }

        [TestMethod]
        public void CorrectReturnedBuzzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(5);
            Assert.AreEqual(true, receivedAnswer.GetType() == typeof(Buzz),
                "Wrong type of answer");
        }

        [TestMethod]
        public void CorrectReturnedFizzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(3);
            Assert.AreEqual(true, receivedAnswer.GetType() == typeof(Fizz),
                "Wrong type of answer");
        }

        [TestMethod]
        public void CorrectReturnedFizzBuzzAnswer()
        {
            AnswerFactory testFactory = new ConcreteAnswerFactory();
            Answer receivedAnswer = testFactory.getAnswer(15);
            Assert.AreEqual(true, receivedAnswer.GetType() == typeof(FizzBuzz),
                "Wrong type of answer");
        }
    }
}
