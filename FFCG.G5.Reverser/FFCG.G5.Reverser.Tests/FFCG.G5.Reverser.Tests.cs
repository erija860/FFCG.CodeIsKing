using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Reverser.Tests
{
    [TestClass]
    public class ReverserTester
    {
        private Reverser _reverser;

        [TestInitialize]
        public void SetUp()
        {
            _reverser = new Reverser();
        }

        [TestMethod]
        public void Should_reverse_one_word()
        {
            var result = _reverser.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        public void Should_reverse_words_in_sentence_and_keep_them_in_place()
        {
            var result = _reverser.Reverse("hello world");
            Assert.AreEqual("olleh dlrow", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions()
        {
            var result = _reverser.Reverse("For the Win");
            Assert.AreEqual("Rof eht Niw", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions_In_Different_Positions()
        {
            var result = _reverser.Reverse("tEst DiffeRent plaCes Of UPQerCAse");
            Assert.AreEqual("tSet TnereFfid secAlp Fo ESAcrEQpu", result);
        }

        [TestMethod]
        public void Should_keep_uppercase_positions_no_matter_char()
        {
            var result = _reverser.Reverse("tEst DiffeRent plaCes Of UPPerCAse");
            Assert.AreEqual("tSet TnereFfid secAlp Fo ESAcrEPpu", result);
        }
    }
}