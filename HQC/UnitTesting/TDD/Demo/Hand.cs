using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Empty);

            var cardsCount = this.Cards.Count;
            if (cardsCount == 0)
            {
                return result.ToString();
            }

            for (int i = 0; i < cardsCount - 1; i++)
            {
                result.Append(string.Format("{0}, ", this.Cards[i].ToString()));
            }

            result.Append(this.Cards[cardsCount - 1].ToString());

            return result.ToString();
        }
    }
}
