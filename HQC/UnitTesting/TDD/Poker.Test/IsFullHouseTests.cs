namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsFullHouseTests
    {
        [Test]
        public void IsFullHouseShouldReturnFalseIfTwoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsFullHouse(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIffThreeSameFaceCardsAndTwoDifferentArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsFullHouse(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsFullHouseShouldReturnFalseIfTwoSameFaceCardsAndThreeDifferentArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsFullHouse(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsFullHouseShouldReturnTrueIFThreeSameFaceCardsAndTwoOtherCardsWithTheSameFaceArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades)
            });

            var isValid = handChecker.IsFullHouse(hand);

            Assert.IsTrue(isValid);
        }
    }
}
