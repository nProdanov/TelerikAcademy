namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class FourOfAKindTests
    {
        [Test]
        public void FourOfAKindShouldReturnFalseIfFiveDifferentFaceCardsArePassed()
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

            var isValid = handChecker.IsFourOfAKind(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void FourOfAKindShouldReturnTrueIfFourSameFaceCardsArePassed()
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

            var isValid = handChecker.IsFourOfAKind(hand);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void FourOfAKindShouldReturnFalseIfThreeSameFaceCardsArePassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts)
            });

            var isValid = handChecker.IsFourOfAKind(hand);

            Assert.IsFalse(isValid);
        }
    }
}
