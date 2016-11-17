using System.Drawing;

namespace FFCG.G5.Painter
{
    public class Painter
    {
        public void Paint(Vehicle vehicle, Color color)
        {
            vehicle.Color = color;
        }
    }
}