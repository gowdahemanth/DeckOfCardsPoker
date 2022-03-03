using System;

namespace DeckOfCardsPoker.Ranks
{
    public class FullHouse : IHandRankingCategory
    {
        private const string category = "Full House";
        private const int BaseValue = 6000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            bool firstThreeCardsSame, lastThreeCardsSame;

            if (cards.Length != 5)
                return false;

            Helper.SortByRank(cards);       // Sort by rank first

            /* ------------------------------------------------------
               Check for: x x x y y
           ------------------------------------------------------- */
            firstThreeCardsSame = cards[0].GetRank == cards[1].GetRank &&
                 cards[1].GetRank == cards[2].GetRank &&
                 cards[3].GetRank == cards[4].GetRank;

            /* ------------------------------------------------------
               Check for: x x y y y
           ------------------------------------------------------- */
            lastThreeCardsSame = cards[0].GetRank == cards[1].GetRank &&
                 cards[2].GetRank == cards[3].GetRank &&
                 cards[3].GetRank == cards[4].GetRank;

            if(firstThreeCardsSame || lastThreeCardsSame)
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
