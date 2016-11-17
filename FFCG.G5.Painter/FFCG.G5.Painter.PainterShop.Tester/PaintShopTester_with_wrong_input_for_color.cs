using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFCG.G5.Painter.InputOutput;

namespace FFCG.G5.Painter.PainterShop.Tester
{
    [TestClass]
    public class PaintShopTesterWithWrongInputForColor
    {
        private PaintShop _paintshop;
        private TestOutput _output;

        [TestInitialize]
        public void SetUp()
        {
            _output = new TestOutput();
            _paintshop = new PaintShop(new FakeUserInputStream(new List<string> { "4", "5" }), _output);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Wrong input to color selection")]
        public void Fake_user_wrong_input_for_color_should_throw_exception()
        {
            _paintshop.MakeBusiness();

        }
    }
}
