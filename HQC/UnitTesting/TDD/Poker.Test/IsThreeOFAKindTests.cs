namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class IsThreeOFAKindTests
    {
        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfTwoSameFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfFourSameFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseIfFiveDifferentFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsThreeOfAKindShouldReturnTrueIFThreeSameFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)});

            var isValid = handChecker.IsThreeOfAKind(hand);

            Assert.IsTrue(isValid);
        }
    }
}
