namespace FFCG.G5.PokerGame
{
    public class Card
    {
        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public Suit Suit { get; }
        public CardValue Value { get; }

        public string GetValues()
        {
            return string.Format($"{Value} of {Suit}");
        }
    }
}