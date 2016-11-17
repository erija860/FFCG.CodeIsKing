using System.Collections.Generic;
using System.Linq;
using FFCG.G5.Painter.InputOutput;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Painter.PainterShop.Tester
{
    [TestClass]
    public class PaintShopTesterWithInput4And3
    {
        private PaintShop _paintshop;
        private TestOutput _output;

        [TestInitialize]
        public void SetUp()
        {
            _output = new TestOutput();
            _paintshop = new PaintShop(new FakeUserInputStream(new List<string> { "4", "3" }), _output);
            _paintshop.MakeBusiness();
        }

        [TestMethod]
        public void Fake_user_input_number_four_should_lead_to_airplane_vehicle()
        {
            var msg = _output.LastMessage;

            string[] ssize = msg.Split(null);
            Assert.AreEqual(ssize[0], "Airplane");
        }

        [TestMethod]
        public void Fake_user_input_number_four_should_lead_to_green_vehicle()
        {
            var msg = _output.LastMessage;

            string[] ssize = msg.Split(null);
            Assert.AreEqual(ssize.Last(), "Green");
        }
    }
}