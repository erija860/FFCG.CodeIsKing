using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.PokerGame.Tests
{
    [TestFixture]
    public class TestRules
    {
        [Test]
        public void Should_be_flush()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Nine),
                new Card(Suit.Diamonds, CardValue.Ten),
                new Card(Suit.Diamonds, CardValue.King),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsFlush().Should().BeTrue();
        }


        [Test]
        public void Should_be_four_of_a_kind()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Clubs, CardValue.Four)
            });

            hand.IsFourOfAKind().Should().BeTrue();
        }


        [Test]
        public void Should_be_full_house()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Spades, CardValue.Queen),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Hearts, CardValue.Queen)
            });

            hand.IsFullHouse().Should().BeTrue();
        }

        [Test]
        public void Should_be_pair()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Knight),
                new Card(Suit.Hearts, CardValue.Queen)
            });

            hand.IsPair().Should().BeTrue();
        }

        [Test]
        public void Should_be_royal_flush_with_ace()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Knight),
                new Card(Suit.Diamonds, CardValue.Ten),
                new Card(Suit.Diamonds, CardValue.King),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsRoyalFlush().Should().BeTrue();
        }

        [Test]
        public void Should_be_straight()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Knight),
                new Card(Suit.Diamonds, CardValue.Knight)
            });

            hand.IsTwoPair().Should().BeTrue();
        }

        [Test]
        public void Should_be_straight_with_ace()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Knight),
                new Card(Suit.Spades, CardValue.Ten),
                new Card(Suit.Hearts, CardValue.King),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsStraight().Should().BeTrue();
        }

        [Test]
        public void Should_be_three_of_a_kind()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Four),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Four),
                new Card(Suit.Hearts, CardValue.Queen)
            });

            hand.IsThreeOfAKind().Should().BeTrue();
        }

        [Test]
        public void Should_be_two_pair()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Four),
                new Card(Suit.Spades, CardValue.Three),
                new Card(Suit.Spades, CardValue.Five),
                new Card(Suit.Hearts, CardValue.Six),
                new Card(Suit.Diamonds, CardValue.Seven)
            });

            hand.IsStraight().Should().BeTrue();
        }

        [Test]
        public void Should_not_be_flush()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Diamonds, CardValue.Nine),
                new Card(Suit.Diamonds, CardValue.Ten),
                new Card(Suit.Spades, CardValue.King),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsFlush().Should().BeFalse();
        }

        [Test]
        public void Should_not_be_straight()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Seven),
                new Card(Suit.Spades, CardValue.Nine),
                new Card(Suit.Spades, CardValue.Eight),
                new Card(Suit.Hearts, CardValue.Knight),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsStraight().Should().BeFalse();
        }

        [Test]
        public void Should_not_be_straight_with_ace()
        {
            var hand = new PokerHand(new List<Card>
            {
                new Card(Suit.Diamonds, CardValue.Ace),
                new Card(Suit.Spades, CardValue.Nine),
                new Card(Suit.Spades, CardValue.Ten),
                new Card(Suit.Hearts, CardValue.King),
                new Card(Suit.Diamonds, CardValue.Queen)
            });

            hand.IsStraight().Should().BeFalse();
        }
    }
}