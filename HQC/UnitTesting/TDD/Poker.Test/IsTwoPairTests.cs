namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsTwoPairTests
    {
        [Test]
        public void IsTwoPairShouldReturnFalseIfOnePairAndThreeDiferentFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsTwoPair(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsTwoPairShouldReturnFalseIfNoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsTwoPair(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsTwoPairShouldReturnTrueIfTwoPairsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)});

            var isValid = handChecker.IsTwoPair(hand);

            Assert.IsTrue(isValid);
        }
    }
}
