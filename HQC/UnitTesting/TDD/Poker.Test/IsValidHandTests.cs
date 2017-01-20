namespace Poker.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class IsValidHandTests
    {
        [Test]
        public void IsValidHandShouldReturnFalseIfOneCardHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() { new Card(CardFace.Ace, CardSuit.Diamonds) });

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfTwoCardsHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfThreeCardsHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfFourCardsHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfFiveCardsHandIsPassedButTwoOfThemAreTheSame()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnFalseIfMoreThanFiveCardsHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValidHandShouldReturnTrueIfFiveNonSameCardsHandIsPassed()
        {
            var handChecker = new PokerHandsChecker();
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds)});

            var isValid = handChecker.IsValidHand(hand);

            Assert.IsTrue(isValid);
        }
    }
}
