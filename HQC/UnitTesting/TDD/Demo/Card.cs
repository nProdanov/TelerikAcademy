using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            var faceIntNumber = (int)this.Face;
            switch (faceIntNumber)
            {
                case 11: result.Append("J"); break;
                case 12: result.Append("Q"); break;
                case 13: result.Append("K"); break;
                case 14: result.Append("A"); break;
                default: result.Append(faceIntNumber); break;
            }

            switch ((int)this.Suit)
            {
                case 1: result.Append("♣"); break;
                case 2: result.Append("♦"); break;
                case 3: result.Append("♥"); break;
                case 4: result.Append("♠"); break;
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            var cardToCompare = obj as Card;

            return this.Face == cardToCompare.Face && this.Suit == cardToCompare.Suit;
        }

        public override int GetHashCode()
        {
            return this.Face.GetHashCode() ^ this.Suit.GetHashCode();
        }
    }
}
