namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsOnePairTests
    {
        [Test]
        public void IsOnePairShouldReturnFalseIfTwoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)});

            var isValid = handChecker.IsOnePair(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsOnePairShouldReturnFalseIfNoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)});

            var isValid = handChecker.IsOnePair(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsOnePairShouldReturnTrueIfOnlyOnePairIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)});

            var isValid = handChecker.IsOnePair(hand);

            Assert.IsTrue(isValid);
        }
    }
}
