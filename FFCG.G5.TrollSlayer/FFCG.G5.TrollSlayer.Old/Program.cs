using System;
using System.Linq;

namespace FFCG.G5.TrollSlayer.Client.Old
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Press Enter to start a new game...");
                Console.ReadLine();

                var player = new Player();
                var walkedWeters = 0;
                Console.WriteLine("You enter a cave...");

                var meters = Dice.Roll(50);
                Console.WriteLine($"You walked {meters} meters ");
                walkedWeters += meters;

                Console.WriteLine("Du hittar vapen och kläder och får 40hp och 10str");
                player.HealthPoints += 40;
                player.Strength += 10;

                var trollHp = 20;
                var trollStr = 10;


                while (player.HealthPoints > 0)
                {
                    meters = Dice.Roll(50);
                    Console.WriteLine($"You walked {meters} meters ");
                    walkedWeters += meters;

                    if (meters % 5 == 0)
                    {
                        var newStrength = Dice.Roll(5);
                        player.Strength += newStrength;
                        Console.WriteLine($"Player gets {newStrength} added strength");
                    }

                    var troll = new Player();
                    trollHp += 2;
                    trollStr += 1;
                    troll.HealthPoints = Dice.Roll(trollHp);
                    troll.Strength = Dice.Roll(trollStr);
                    Console.WriteLine($"You encounter a troll!!! It has HP:{troll.HealthPoints}, Str:{troll.Strength}");

                    var bothIsAlive = true;
                    var activePlayer = player;
                    var receivingPlayer = troll;

                    while (bothIsAlive)
                    {
                        var hitStrength = Dice.Roll(activePlayer.Strength);

                        if (activePlayer.Name == "player")
                            if (hitStrength % 3 == 0)
                                hitStrength = hitStrength * 2;

                        Console.WriteLine(
                            $"{activePlayer.Name} hit the {receivingPlayer.Name} with {hitStrength} hit strength");

                        Console.WriteLine($"The  {receivingPlayer.Name} loses {hitStrength} health");
                        receivingPlayer.HealthPoints -= hitStrength;

                        if (receivingPlayer.HealthPoints <= 0)
                        {
                            bothIsAlive = false;
                            Console.WriteLine($"{receivingPlayer.Name} died...");
                        }

                        var tempActive = activePlayer;
                        activePlayer = receivingPlayer;
                        receivingPlayer = tempActive;
                    }

                    var newHp = Dice.Roll(20);
                    Console.WriteLine($"You eat the trolls ear and get {newHp}hp");
                    player.HealthPoints += newHp;

                    if (walkedWeters >= 1000)
                    {
                        Console.WriteLine(
                            $"You survived!! You have {player.HealthPoints}hp and {player.Strength}strength");
                        break;
                    }
                }
                if (player.HealthPoints <= 0)
                    Console.WriteLine($"You died after {walkedWeters} meters");
            }
        }
    }

    public static class Dice
    {
        public static int Roll(int sides) => Enumerable.Range(1, sides).OrderBy(x => Guid.NewGuid()).First();
    }

    public class Player : IBattleReady, IWalker
    {
        public string Name => "player";
        public int HealthPoints { get; set; }
        public int Strength { get; set; }
        public int WalkedMeters { get; set; }
    }

    public class Troll : IBattleReady
    {
        public string Name => "troll";
        public int HealthPoints { get; set; }
        public int Strength { get; set; }
    }

    public interface IBattleReady
    {
        string Name { get; }
        int HealthPoints { get; set; }
        int Strength { get; set; }
    }

    public interface IWalker
    {
        int WalkedMeters { get; set; }
    }
}