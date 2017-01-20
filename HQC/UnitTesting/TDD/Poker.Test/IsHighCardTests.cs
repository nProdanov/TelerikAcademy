namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsHighCardTests
    {
        [Test]
        public void IsHighCardReturnFalseIfStraightFlushIsPassed()
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

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfFourOfAKindIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfFullHouseIsPassed()
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

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfFlushIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)});

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfStraightIsPassed()
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

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfThreeOfAKindIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfTwoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)});

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnFalseIfOnePairIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)});

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsHighCardReturnTrueIfNoOfOtherHandIsValid()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs)});

            var isValid = handChecker.IsHighCard(hand);

            Assert.IsTrue(isValid);
        }
    }
}
