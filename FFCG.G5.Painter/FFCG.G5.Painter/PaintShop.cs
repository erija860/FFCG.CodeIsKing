using System;
using System.Drawing;
using FFCG.G5.Painter.InputOutput;

namespace FFCG.G5.Painter
{
    public class PaintShop
    {
        private readonly IUserInput _input;
        private readonly IOutput _output;
        private readonly Painter _painter;

        public PaintShop(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            _painter = new Painter();
        }

        public void MakeBusiness()
        {
            var vehicle = GetVehicleChoise();
            var color = GetColorChoise();
            _painter.Paint(vehicle, color);
            _output.Print($"{vehicle} was painted {color.GetString()}", color);
        }

        private Color GetColorChoise()
        {
            _output.Print("In what color do you want your vehicle? \n" +
                          "1. Red \n" +
                          "2. Blue \n" +
                          "3. Green \n" +
                          "4. Pink");

            switch (int.Parse(_input.GetInput()))
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Green;
                case 4:
                    return Color.Pink;
                default:
                    throw new Exception("Wrong input");
            }
        }

        private Vehicle GetVehicleChoise()
        {
            _output.Print("What is your vehicle? \n" +
                          "1. Car \n" +
                          "2. Bus \n" +
                          "3. Train \n" +
                          "4. Airplane");

            switch (int.Parse(_input.GetInput()))
            {
                case 1:
                    return new Car();
                case 2:
                    return new Bus();
                case 3:
                    return new Train();
                case 4:
                    return new Airplane();
                default:
                    throw new Exception("Wrong input");
            }
        }
    }
}