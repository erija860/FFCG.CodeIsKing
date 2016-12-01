using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.PokerGame.Tests
{
    [TestFixture]
    public class When_scrambling_deck
    {
        private CardDeck _cardDeck;
        private List<Card> _oldCards;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _cardDeck = new CardDeck();
            _oldCards = _cardDeck.Cards;
            _cardDeck.ScrambleDeck();
        }

        [Test]
        public void Scrambled_deck_should_be_set()
        {
            _cardDeck.Cards.Should().NotBeNull();
        }

        [Test]
        public void Scrambled_deck_should_not_be_same_as_old()
        {
            _cardDeck.Cards.Should().NotBeSameAs(_oldCards);
            Assert.IsFalse(_cardDeck.Cards == _oldCards);
        }
    }
}