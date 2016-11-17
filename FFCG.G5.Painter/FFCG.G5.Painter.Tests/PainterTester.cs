using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FFCG.G5.Painter.Tests
{
    [TestClass]
    public class PainterTester
    {
        private Painter _painter;

        [TestInitialize]
        public void SetUp()
        {
            _painter = new Painter();
        }

        [TestMethod]
        public void Painting_car_red_should_make_car_red()
        {
            Vehicle car = new Car();
            _painter.Paint(car, Color.Red);
            Assert.IsTrue(car.Color.Equals(Color.Red));
        }

        [TestMethod]
        public void Painting_bus_blue_should_make_bus_blue()
        {
            Vehicle bus = new Bus();
            _painter.Paint(bus, Color.Blue);
            Assert.IsTrue(bus.Color.Equals(Color.Blue));
        }

        [TestMethod]
        public void Painting_train_green_should_make_train_green()
        {
            Vehicle train = new Train();
            _painter.Paint(train, Color.Green);
            Assert.IsTrue(train.Color.Equals(Color.Green));
        }

        [TestMethod]
        public void Painting_airplane_pink_should_make_airplane_pink()
        {
            Vehicle airplane = new Airplane();
            _painter.Paint(airplane, Color.Pink);
            Assert.IsTrue(airplane.Color.Equals(Color.Pink));
        }
    }
}