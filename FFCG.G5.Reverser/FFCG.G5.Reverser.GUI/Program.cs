using System;

namespace FFCG.G5.Reverser.GUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var reverser = new Reverser();
            while (true)
            {
                Console.Write("Enter a word to reverse: ");
                Console.WriteLine(reverser.Reverse(Console.ReadLine()));
            }
        }
    }
}