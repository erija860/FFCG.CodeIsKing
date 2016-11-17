using System.Collections.Generic;
using System.Linq;
using FFCG.G5.Painter.InputOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Painter.PainterShop.Tester
{
    [TestClass]
    public class PaintShopTesterWithInput3And4
    {
        private PaintShop _paintshop;
        private TestOutput _output;

        [TestInitialize]
        public void SetUp()
        {
            _output = new TestOutput();
            _paintshop = new PaintShop(new FakeUserInputStream(new List<string> { "3", "4" }), _output);
            _paintshop.MakeBusiness();
        }

        [TestMethod]
        public void Fake_user_input_number_three_should_lead_to_train_vehicle()
        {
            var msg = _output.LastMessage;

            string[] ssize = msg.Split(null);
            Assert.AreEqual(ssize[0], "Train");
        }

        [TestMethod]
        public void Fake_user_input_number_four_should_lead_to_pink_vehicle()
        {
            var msg = _output.LastMessage;

            string[] ssize = msg.Split(null);
            Assert.AreEqual(ssize.Last(), "Pink");
        }
    }
}