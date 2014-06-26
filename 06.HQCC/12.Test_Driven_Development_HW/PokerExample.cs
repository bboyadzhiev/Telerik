using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            IHand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            IHand falseHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            });

            Console.WriteLine(hand);
            //
            IPokerHandsChecker checker = new PokerHandsChecker();
            //Trues
            Console.WriteLine(checker.IsValidHand(hand));
            Console.WriteLine(checker.IsValidHand(hand2));
            Console.WriteLine(checker.IsFourOfAKind(hand2));

            //Falses
            Console.WriteLine(checker.IsFourOfAKind(hand));
            Console.WriteLine(checker.IsValidHand(falseHand));
            
           // Console.WriteLine(checker.IsOnePair(hand));
           // Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
