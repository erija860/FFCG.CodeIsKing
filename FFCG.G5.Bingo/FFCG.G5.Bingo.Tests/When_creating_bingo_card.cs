using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFCG.G5.Bingo.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.Bingo.Tests
{
    [TestFixture]
    public class When_creating_bingo_card
    {
        private BingoCard _card;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _card = new BingoCard(5, 3);
        }

        [Test]
        public void Card_is_created()
        {
            _card.Should().NotBeNull();
        }
    }

    [TestFixture]
    public class When_drawing_number_and_marking_it
    {
        private BingoCard _card;
        private int _drawnNumber;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _card = new BingoCard(5, 3);
            _drawnNumber =_card.GetRandomNumber();
            _card.MarkNumberAsDrawn(_drawnNumber);
        }

        [Test]
        public void Number_should_be_marked()
        {
            
        }
    }

    [TestFixture]
    public class When_checking_for_bingo
    {
        private int[,] _numbers;
        private BingoCard _card;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _card = new BingoCard(5, 3);
            _numbers = _card.GetNumbers();
            _numbers[2, 0] = 0;
            _numbers[2, 1] = 0;
            _numbers[2, 2] = 0;
        }

        [Test]
        public void SomeTest()
        {
            _card.IsBingo().Should().Be(true);
        }
    }
}
