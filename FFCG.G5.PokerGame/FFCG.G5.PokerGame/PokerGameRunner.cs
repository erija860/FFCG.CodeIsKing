using System;

namespace FFCG.G5.PokerGame
{
    public class PokerGameRunner
    {
        private readonly CardDeck _deck;

        public PokerGameRunner()
        {
            _deck = new CardDeck();
        }

        public void RunGame()
        {
            var isStraightFlush = false;
            var tries = 1;
            do
            {
                if (_deck.DeckHasCardsForNewHand())
                {
                    var hand = _deck.GetHand(5);
                    isStraightFlush = hand.IsStraightFlush();
                    Console.WriteLine($"{tries},\t{hand.CheckHand()}, {hand.GetCards()}");
                    tries++;
                }
                else
                {
                    _deck.ResetDeck();
                }
            } while (!isStraightFlush);
        }
    }
}