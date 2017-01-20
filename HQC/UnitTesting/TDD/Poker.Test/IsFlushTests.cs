namespace Poker.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class IsFlushTests
    {
        [Test]
        public void IsFlushShouldBeFalseIfFourCardsAreWithSameSuitAndOneIsWithDifferent()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isFlush = handChecker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [Test]
        public void IsFlushShouldBeFalseIfThreeCardsAreWithSameSuitAndTwoAreWithDifferent()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isFlush = handChecker.IsFlush(hand);

            Assert.IsFalse(isFlush);
        }

        [Test]
        public void IsFlushShouldBeTrueIfAllCardsAreWithSameSuit()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds)});

            var isFlush = handChecker.IsFlush(hand);

            Assert.IsTrue(isFlush);
        }


    }
}
