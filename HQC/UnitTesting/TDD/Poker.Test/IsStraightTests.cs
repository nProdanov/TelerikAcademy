namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsStraightTests
    {
        [Test]
        public void IsStraightShouldReturnFalseIfFiveNonSequentialCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var isValid = handChecker.IsStraight(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightShouldReturnFalseIfFTwoSequentialCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var isValid = handChecker.IsStraight(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightShouldReturnFalseIfFThreeSequentialCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var isValid = handChecker.IsStraight(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightShouldReturnFalseIfFFourSequentialCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var isValid = handChecker.IsStraight(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightShouldReturnTrueIfFiveSequentialCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades)
            });

            var isValid = handChecker.IsStraight(hand);

            Assert.IsTrue(isValid);
        }
    }
}
