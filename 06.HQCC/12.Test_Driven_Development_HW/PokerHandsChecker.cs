using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public const byte HAND_COUNT = 5;
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5 || hasRepeatingCards(hand))
            {
                return false;
            }
            return true;
        }

        public bool hasRepeatingCards(IHand hand)
        {
           for (int i = 0; i < HAND_COUNT; i++)
           {
               for (int j = 0; j < HAND_COUNT; j++)
               {
                   if (i != j)
                   {
                       if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                       {
                           return true;
                       }
                   }
               }
           }
           return false;
        }

        public bool isOfOneSuit(IHand hand)
        {
            for (int i = 1; i < HAND_COUNT; i++)
            {
                if (hand.Cards[i].Suit == hand.Cards[0].Suit)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            SortedDictionary<CardFace, int> facesCount = new SortedDictionary<CardFace, int>();
            for (int i = 0; i < HAND_COUNT; i++)
            {
                CardFace face = hand.Cards[i].Face;
                if (facesCount.ContainsKey(hand.Cards[i].Face))
                {
                    int count;
                    if (facesCount.TryGetValue(face, out count)){
                        count++;
                        facesCount.Remove(face);
                        facesCount.Add(face, count);
                    }
                }
                else
                {
                    facesCount.Add(face, 1);
                }
            }

            foreach (var count in facesCount.Values)
            {
                if (count == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (isOfOneSuit(hand) && IsValidHand(hand))
            {
                return true;
            }
            return false;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
