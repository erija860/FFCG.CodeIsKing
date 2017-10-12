using System;
using FFCG.G5.TrollSlayer.Characters;
using FFCG.G5.TrollSlayer.Interfaces;

namespace FFCG.G5.TrollSlayer.Extensions
{
    public static class PlayableCharacterExtensions
    {
        public static void WalkWithChanceOfStrengthIncrease(this IPlayableCharacter player, IDice dice, int sides)
        {
            var meters = dice.Roll(sides);
            player.Walk(meters);

            if (meters % 3 == 0)
                player.IncreaseStrength(dice.Roll(5));
        }

        public static void EatTrollsEar(this IPlayableCharacter player, IDice dice, Action<string> log)
        {
            var newHp = dice.Roll(20);
            log("Player eats the trolls ear.");
            player.IncreaseHealth(newHp);
        }
    }
}