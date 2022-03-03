using System;

namespace DeckOfCardsPoker.Ranks
{
    public class FourOfAKind : IHandRankingCategory
    {
        private const string category = "Four Of A Kind";
        private const int BaseValue = 7000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            bool firstFourCards, lastFourCards;

            if (cards.Length != 5)
                return false;

            Helper.SortByRank(cards);         // Sort by rank first

            /* ------------------------------------------------------
               Check for: 4 cards of the same rank 
                      + higher ranked unmatched card 
           ------------------------------------------------------- */
            firstFourCards = cards[0].GetRank == cards[1].GetRank &&
                 cards[1].GetRank == cards[2].GetRank &&
                 cards[2].GetRank == cards[3].GetRank;


            /* ------------------------------------------------------
               Check for: lower ranked unmatched card 
                      + 4 cards of the same rank 
           ------------------------------------------------------- */
            lastFourCards = cards[1].GetRank == cards[2].GetRank &&
                 cards[2].GetRank == cards[3].GetRank &&
                 cards[3].GetRank == cards[4].GetRank;

            if(firstFourCards || lastFourCards)
            {
                value = BaseValue + (int)cards[2].GetRank;
                return true;
            }
            return false;
        }

        public Tuple<int, string> GetValue()
        {
            return Tuple.Create(value, category);
        }
    }
}
