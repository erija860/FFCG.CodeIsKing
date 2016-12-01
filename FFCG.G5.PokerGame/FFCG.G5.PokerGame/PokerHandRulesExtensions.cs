using System.Linq;

namespace FFCG.G5.PokerGame
{
    public static class PokerHandRulesExtensions
    {
        public static bool IsPair(this PokerHand h) =>
            h.Cards.GroupBy(card => card.Value)
                .Count(c => c.Count() == 2) == 1;

        public static bool IsTwoPair(this PokerHand h) =>
            h.Cards.GroupBy(card => card.Value)
                .Count(c => c.Count() == 2) == 2;

        public static bool IsThreeOfAKind(this PokerHand h) =>
            h.Cards.GroupBy(card => card.Value)
                .Count(c => c.Count() == 3) == 1;

        public static bool IsFourOfAKind(this PokerHand h) =>
            h.Cards.GroupBy(card => card.Value)
                .Count(c => c.Count() == 4) == 1;

        public static bool IsFullHouse(this PokerHand h) =>
            IsThreeOfAKind(h)
            &&
            IsPair(h);

        public static bool IsStraight(this PokerHand h) =>
            (h.Cards.GroupBy(card => card.Value)
                 .Count() == h.Cards.Count())
            &&
            ((h.Cards.Max(card => (int)card.Value)
              - h.Cards.Min(card => (int)card.Value) == h.Cards.Count() - 1
             ) || (
                 (h.Cards.Max(card => card.Value) == CardValue.King)
                 &&
                 (h.Cards.Min(card => card.Value) == CardValue.Ace)
                 &&
                 (h.Cards.Max(card => (int)card.Value)
                  - (int)h.Cards[1].Value == h.Cards.Count() - 2)));

        public static bool IsFlush(this PokerHand h) =>
            h.Cards.GroupBy(card => card.Suit).Count() == 1;

        public static bool IsStraightFlush(this PokerHand h) =>
            IsStraight(h)
            &&
            IsFlush(h);

        public static bool IsRoyalFlush(this PokerHand h) =>
            IsStraightFlush(h)
            &&
            (h.Cards.Max(card => card.Value) == CardValue.King)
            &&
            (h.Cards.Min(card => card.Value) == CardValue.Ace);
    }
}