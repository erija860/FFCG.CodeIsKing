using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.PokerGame.Tests
{
    [TestFixture]
    public class When_getting_hand_from_deck
    {
        private CardDeck _cardDeck;
        private PokerHand _newHand;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cardDeck = new CardDeck();
            _cardDeck.ScrambleDeck();
            _newHand = _cardDeck.GetHand(5);
        }

        [Test]
        public void Deck_should_have_five_cards_less()
        {
            _cardDeck.Cards.Count.Should().Be(47);
        }

        [Test]
        public void New_hand_should_have_five_cards()
        {
            _newHand.Cards.Length.Should().Be(5);
        }
    }
}