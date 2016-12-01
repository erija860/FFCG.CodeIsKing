using System;

namespace FFCG.G5.PokerGame.GUI
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
                try
                {
                    var game = new PokerGameRunner();
                    game.RunGame();
                    Console.WriteLine("Run again?... ");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
        }
    }
}