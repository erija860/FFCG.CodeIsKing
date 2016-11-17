using System.Drawing;

namespace FFCG.G5.Painter
{
    public abstract class Vehicle
    {
        protected string Name;
        public Color Color { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Car : Vehicle
    {
        public Car()
        {
            Name = "Car";
        }
    }

    public class Bus : Vehicle
    {
        public Bus()
        {
            Name = "Bus";
        }
    }

    public class Train : Vehicle
    {
        public Train()
        {
            Name = "Train";
        }
    }

    public class Airplane : Vehicle
    {
        public Airplane()
        {
            Name = "Airplane";
        }
    }
}