using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G5.PokerGame
{
    public class CardDeck
    {
        public CardDeck()
        {
            CreateDeck();
            ScrambleDeck();
        }

        public List<Card> Cards { get; private set; }

        private void CreateDeck() =>
            Cards = (from Suit suit in Enum.GetValues(typeof(Suit))
                from CardValue value
                in Enum.GetValues(typeof(CardValue))
                select new Card(suit, value)).ToList();

        public void ScrambleDeck() =>
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();

        public PokerHand GetHand(int cardsInHand)
        {
            var newHand = new PokerHand(Cards.Take(cardsInHand).ToList());
            Cards.RemoveRange(0, 5);
            return newHand;
        }

        public bool DeckHasCardsForNewHand() =>
            Cards.Count >= 5;

        public void ResetDeck()
        {
            CreateDeck();
            ScrambleDeck();
        }
    }
}