using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.PokerGame.Tests
{
    [TestFixture]
    public class When_creating_cardDeck
    {
        private CardDeck _cardDeck;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cardDeck = new CardDeck();
        }

        [Test]
        public void Deck_should_have_52_cards()
        {
            _cardDeck.Cards.Count.Should().Be(52);
        }
    }
}