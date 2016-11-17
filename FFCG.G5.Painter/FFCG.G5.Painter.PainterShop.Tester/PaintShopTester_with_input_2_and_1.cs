using System.Collections.Generic;
using System.Linq;
using FFCG.G5.Painter.InputOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Painter.PainterShop.Tester
{
    [TestClass]
    public class PaintShopTesterWithInput2And1
    {
        private TestOutput _output;
        private PaintShop _paintshop;

        [TestInitialize]
        public void SetUp()
        {
            _output = new TestOutput();
            _paintshop = new PaintShop(new FakeUserInputStream(new List<string> { "2", "1" }), _output);
            _paintshop.MakeBusiness();
        }

        [TestMethod]
        public void Fake_user_input_number_two_should_lead_to_bus_vehicle()
        {
            var msg = _output.LastMessage;

            var ssize = msg.Split(null);
            Assert.AreEqual(ssize[0], "Bus");
        }

        [TestMethod]
        public void Fake_user_input_number_one_should_lead_to_red_vehicle()
        {
            var msg = _output.LastMessage;

            var ssize = msg.Split(null);
            Assert.AreEqual(ssize.Last(), "Red");
        }
    }
}