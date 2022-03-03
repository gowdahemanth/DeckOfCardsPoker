using System;
using System.Collections.Generic;

namespace DeckOfCardsPoker
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 2; j <= 14; j++)
                {
                    cards.Add(new Card((Suit)i, (Rank)j));
                }
            }
            Shuffle();
        }

        private void Shuffle()
        {
            Random generator = new Random();
            for (int i = 0; i < 200; i++)
            {
                int index_1 = generator.Next(cards.Count - 1);
                int index_2 = generator.Next(cards.Count - 1);

                Card temp = cards[index_2];
                cards[index_2] = cards[index_1];
                cards[index_1] = temp;
            }
        }
        
        public Card DrawFromDeck
        {
            get
            {
                if(cards.Count <= 0)
                {
                    Console.WriteLine("Warning: The deck is empty.");
                    return null;
                }                
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
        }

    }
}
