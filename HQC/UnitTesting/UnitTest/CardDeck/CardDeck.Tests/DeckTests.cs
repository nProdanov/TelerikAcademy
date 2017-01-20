namespace CardDeck.Tests
{
    using CardDeck;

    using NUnit.Framework;

    [TestFixture]
    public class DeckTests
    {
        private const int allCardsInTheDeck = 24;
       
        [Test]
        public void CardsLeftShouldBeAllCardsWhenNewDeckIsPassed()
        {
            var testDeck = new Deck();

            Assert.AreEqual(DeckTests.allCardsInTheDeck, testDeck.CardsLeft);
        }

        [TestCase(5, 19)]
        [TestCase(1, 23)]
        [TestCase(24, 0)]
        [TestCase(23, 1)]
        public void CardsLeftShouldDecreaseWhenCardsAreGetting(int getCardsCount, int expectedCardsLeftCount)
        {
            var testDeck = new Deck();

            for (int i = 0; i < getCardsCount; i++)
            {
                testDeck.GetNextCard();
            }

            Assert.AreEqual(expectedCardsLeftCount, testDeck.CardsLeft);
        }

        [Test]
        public void GetNextCardShouldThrowAnExceptionWhenTryToGetACardAndDeckIsEmpty()
        {
            var testDeck = new Deck();

            for (int i = 0; i < DeckTests.allCardsInTheDeck; i++)
            {
                testDeck.GetNextCard();
            }

            Assert.Throws(typeof(InternalGameException), () => { testDeck.GetNextCard(); });
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheTrumpWhenPassANewCard()
        {
            var testDeck = new Deck();
            var jackOfClubs = new Card(CardSuit.Club, CardType.Jack);

            testDeck.ChangeTrumpCard(jackOfClubs);

            Assert.AreEqual(jackOfClubs, testDeck.TrumpCard);
        }
    }
}
