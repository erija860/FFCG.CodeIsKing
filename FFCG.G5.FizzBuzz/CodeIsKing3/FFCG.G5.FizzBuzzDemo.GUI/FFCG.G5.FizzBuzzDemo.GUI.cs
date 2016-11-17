using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.G5.FizzBuzzDemo.GUI
{
    class FizzBuzzDemoGUI
    {
        static void Main(string[] args)
        {
            FizzBuzzDemo fizzBuzz = new FizzBuzzDemo();
            List<String> serie = fizzBuzz.GetSerieOf100RoundsVersion2();

            foreach (string serieItem in serie)
            {
                Console.WriteLine(serieItem);
            }
        }
    }
}
