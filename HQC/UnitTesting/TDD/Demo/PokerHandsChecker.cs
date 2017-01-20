using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidCardCountInHand = 5;

        public bool IsValidHand(IHand hand)
        {
            var handCardCount = hand.Cards.Count;

            if (handCardCount < PokerHandsChecker.ValidCardCountInHand || PokerHandsChecker.ValidCardCountInHand < handCardCount)
            {
                return false;
            }

            if (hand.Cards.Distinct().Count() != PokerHandsChecker.ValidCardCountInHand)
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (!this.IsFlush(hand))
            {
                return false;
            }

            return this.IsStraight(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int sameFaceCardsCount = this.CheckHowManyCardsWithTheSameSuitThereAre(hand);

            if (sameFaceCardsCount != 4)
            {
                return false;
            }

            return true;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var orderedByFaceCards = hand.Cards.OrderBy(c => c.Face).ToList();

            int firstFaceCount = 1;
            int secondFaceCount = 1;
            bool isFirstFace = true;
            for (int i = 0; i < orderedByFaceCards.Count - 1; i++)
            {
                if (orderedByFaceCards[i].Face == orderedByFaceCards[i + 1].Face)
                {
                    if (isFirstFace)
                    {
                        firstFaceCount++;
                    }
                    else
                    {
                        secondFaceCount++;
                    }
                }
                else
                {
                    isFirstFace = false;
                }
            }

            if (firstFaceCount == 3 && secondFaceCount == 2)
            {
                return true;
            }
            else if (firstFaceCount == 2 && secondFaceCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            bool isFlush = true;

            var currentCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < PokerHandsChecker.ValidCardCountInHand; i++)
            {
                if (currentCardSuit != hand.Cards[i].Suit)
                {
                    isFlush = false;
                    break;
                }
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var orderedByFaceCards = hand.Cards.OrderBy(c => c.Face).ToList();

            var areFacesGrowingSequential = true;
            for (int i = 1; i < PokerHandsChecker.ValidCardCountInHand; i++)
            {
                int prevoiusCardFaceAsInt = (int)orderedByFaceCards[i - 1].Face;
                int currentCardFaceAsInt = (int)orderedByFaceCards[i].Face;
                if (prevoiusCardFaceAsInt + 1 != currentCardFaceAsInt)
                {
                    areFacesGrowingSequential = false;
                    break;
                }
            }

            return areFacesGrowingSequential;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var sameFaceCardsCount = this.CheckHowManyCardsWithTheSameSuitThereAre(hand);

            if (sameFaceCardsCount != 3)
            {
                return false;
            }

            return true;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var countPairs = this.CheckHowManyPairsArePassed(hand);

            if (countPairs != 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var countPairs = this.CheckHowManyPairsArePassed(hand);

            if (countPairs !=1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsOnePair(hand))
            {
                return false;
            }
            else if (this.IsTwoPair(hand))
            {
                return false;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return false;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return false;
            }
            else if (this.IsFlush(hand))
            {
                return false;
            }
            else if (this.IsStraight(hand))
            {
                return false;
            }
            else if (this.IsFullHouse(hand))
            {
                return false;
            }
            else if (this.IsStraightFlush(hand))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private int CheckHowManyPairsArePassed(IHand hand)
        {
            var orderedByFaceCards = hand.Cards.OrderBy(c => c.Face).ToList();

            int countPairs = 0;
            int countSameFaceCardsCount = 1;


            for (int i = 1; i < PokerHandsChecker.ValidCardCountInHand; i++)
            {
                if (orderedByFaceCards[i - 1].Face == orderedByFaceCards[i].Face)
                {
                    countSameFaceCardsCount++;
                }
                else
                {
                    if (countSameFaceCardsCount == 2)
                    {
                        countPairs++;
                    }

                    countSameFaceCardsCount = 1;
                }
            }

            if (countSameFaceCardsCount == 2)
            {
                countPairs++;
            }

            return countPairs;
        }

        private int CheckHowManyCardsWithTheSameSuitThereAre(IHand hand)
        {
            var orderedByFaceCards = hand.Cards.OrderBy(c => c.Face).ToList();

            int equalFaceCount = 1;
            int maxEqualCount = 0;

            for (int i = 1; i < PokerHandsChecker.ValidCardCountInHand; i++)
            {
                if (orderedByFaceCards[i - 1].Face == orderedByFaceCards[i].Face)
                {
                    equalFaceCount++;
                }
                else
                {
                    if (maxEqualCount < equalFaceCount)
                    {
                        maxEqualCount = equalFaceCount;
                    }

                    equalFaceCount = 1;
                }
            }

            return maxEqualCount;
        }
    }
}
