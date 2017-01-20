namespace Poker.Test
{
    using System.Collections.Generic;
    
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class HandToStringTests
    {
        [Test]
        public void ToStringHandShouldReturnEmptyStringIfNoCardsArePassed()
        {
            IHand hand = new Hand(new List<ICard>());
            var result = hand.ToString();

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void ToStringHandShouldReturnStringOfOneCardWithoutCommaIfOneCardIsPassed()
        {
            IHand hand = new Hand(new List<ICard>() { new Card(CardFace.Ten, CardSuit.Spades)});
            var result = hand.ToString();

            Assert.AreEqual("10♠", result);
        }

        [Test]
        public void ToStringHandShouldReturnStringsOfTwoCardsSeparatedByACommaAndSpaceIfTwoCardsArePassed()
        {
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)});

            var result = hand.ToString();

            Assert.AreEqual("10♠, 10♠", result);
        }

        [Test]
        public void ToStringHandShouldReturnStringsOfFiveCardsSeparatedByACommaAndSpaceIfFiveCardsArePassed()
        {
            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs)});

            var result = hand.ToString();

            Assert.AreEqual("10♠, 5♣, 3♥, 7♦, A♣", result);
        }
    }
}
