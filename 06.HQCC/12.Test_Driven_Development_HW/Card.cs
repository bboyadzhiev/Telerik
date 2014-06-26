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
            StringBuilder sb = new StringBuilder();

            if ((int)this.Face <= 10)
            {
                sb.Append((int)this.Face).ToString();
            }
            else
            {
                sb.Append(this.Face.ToString()[0]);
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs: sb.Append('♣');
                    break;
                case CardSuit.Diamonds: sb.Append('♦');
                    break;
                case CardSuit.Hearts: sb.Append('♥');
                    break;
                case CardSuit.Spades: sb.Append('♠');
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid suit: " + this.Suit);
            }
            return sb.ToString();
        }

    }
}
