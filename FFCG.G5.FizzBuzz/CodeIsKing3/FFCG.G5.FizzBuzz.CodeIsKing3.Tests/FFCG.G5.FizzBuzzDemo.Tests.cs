using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G5.FizzBuzzDemo.Tests
{
    [TestClass]
    public class FizzBuzzDemoTests
    {

        private List<String> _serie;

        [TestInitialize]
        public void SetUp()
        {
            FizzBuzzDemo fizzBuzz = new FizzBuzzDemo();
            _serie = fizzBuzz.GetSerieOf100RoundsVersion2();
        }


        [TestMethod]
        public void Get_Serie_Returns_Serie_With_100_Slots()
        {
            Assert.AreEqual(100, _serie.Count());
        }

        [TestMethod]
        public void Last_String_In_Serie_Is_Buzz()
        {
            Assert.AreEqual("Buzz", _serie.Last());
        }

        [TestMethod]
        public void First_String_In_Serie_Is_1()
        {
            Assert.AreEqual("1", _serie.First());
        }

        [TestMethod]
        public void Number_Devisible_By_3_Should_Be_Fizz()
        {
            Assert.AreEqual("Fizz", _serie[2]);
            Assert.AreEqual("Fizz", _serie[11]);
        }

        [TestMethod]
        public void Number_Devisible_By_5_Should_Be_Buzz()
        {
            Assert.AreEqual("Buzz", _serie[4]);
            Assert.AreEqual("Buzz", _serie[9]);
        }

        [TestMethod]
        public void Number_Devisible_By_3_And_5_Should_Be_FizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", _serie[14]);
            Assert.AreEqual("FizzBuzz", _serie[29]);
        }

        [TestMethod]
        public void Number_Devisible_By_Or_Includes_3_Should_Be_Fizz()
        {
            Assert.AreEqual("Fizz", _serie[12]);
            Assert.AreEqual("Fizz", _serie[22]);
        }

        [TestMethod]
        public void Number_Devisible_By_Or_Includes_5_Should_Be_Buzz()
        {
            Assert.AreEqual("Buzz", _serie[51]);
            Assert.AreEqual("Buzz", _serie[58]);
        }

        [TestMethod]
        public void Number_Devisible_By_Or_Includes_3_And_Devisible_By_Or_Includes_5_Should_Be_FizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", _serie[52]);
            Assert.AreEqual("FizzBuzz", _serie[34]);
        }
    }
}
