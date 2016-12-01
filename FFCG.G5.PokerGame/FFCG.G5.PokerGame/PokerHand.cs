using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G5.PokerGame
{
    public class PokerHand
    {
        public Card[] Cards;

        public PokerHand(List<Card> cards)
        {
            if (cards.Count != 5)
                throw new ArgumentException("Wrong number of cards in hand");
            Cards = cards.OrderBy(c => c.Value).ToArray();
        }

        public string GetCards() =>
            Cards.Aggregate("", (current, card) => current + card.GetValues() + " ");

        public string CheckHand()
        {
            if (this.IsRoyalFlush())
                return "Royal flush";
            if (this.IsStraightFlush())
                return "Straight flush";
            if (this.IsFourOfAKind())
                return "Four of a kind";
            if (this.IsFullHouse())
                return "Full house";
            if (this.IsFlush())
                return "Flush";
            if (this.IsStraight())
                return "Straight";
            if (this.IsThreeOfAKind())
                return "Three of a kind";
            if (this.IsTwoPair())
                return "Two pair";
            return this.IsPair() ? "Pair" : "High card";
        }
    }
}