namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsStraightFlushTests
    {
        [Test]
        public void IsStraightFlushShouldReturnFalseIfFiveSequentialCardsArePassedButFourSameSuitCardsAndOneCardOfADifferentSuit()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseIfFiveSequentialCardsArePassedButThreeSameSuitCardsAndTwoCardsOfADifferentSuit()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseIfFiveSequentialCardsButNotCardsOfTheSameSuitArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var isValid = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightFlushShoudReturnFalseIfFiveCardsOfSameSuitButNonSequentalFacesArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            });

            var isValid = handChecker.IsStraightFlush(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsStraightFlushShouldReturnTrueIfFiveSequentialCardsOfTheSameSuitArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var isValid = handChecker.IsStraightFlush(hand);

            Assert.IsTrue(isValid);
        }
    }
}
