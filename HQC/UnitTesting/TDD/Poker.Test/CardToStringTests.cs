namespace Poker.Test
{
    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class CardToStringTests
    {
        [Test]
        public void ToStringTestsIfCardIsAceOfClubs()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            var result = card.ToString();

            Assert.AreEqual("A♣", result);
        }

        [Test]
        public void ToStringTestsIfCardIsTwoOfDiamonds()
        {
            ICard card = new Card(CardFace.Two, CardSuit.Diamonds);
            var result = card.ToString();

            Assert.AreEqual("2♦", result);
        }

        [Test]
        public void ToStringTestsIfCardIsFiveOfHearts()
        {
            ICard card = new Card(CardFace.Five, CardSuit.Hearts);
            var result = card.ToString();

            Assert.AreEqual("5♥", result);
        }

        [Test]
        public void ToStringTestsIfCardIsTenOfSpades()
        {
            ICard card = new Card(CardFace.Ten, CardSuit.Spades);
            var result = card.ToString();

            Assert.AreEqual("10♠", result);
        }
    }
}
