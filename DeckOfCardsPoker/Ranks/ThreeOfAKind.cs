using System;

namespace DeckOfCardsPoker.Ranks
{
    public class ThreeOfAKind : IHandRankingCategory
    {
        private const string category = "Three Of A Kind";
        private const int BaseValue = 3000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            bool firstThreeSame, middleThreeSame, lastThreeSame;

            if (cards.Length != 5)
                return false;

            Helper.SortByRank(cards);         // Sort by rank first

            /* ------------------------------------------------------
               Check for: x x x a b
           ------------------------------------------------------- */
            firstThreeSame = cards[0].GetRank == cards[1].GetRank &&
                 cards[1].GetRank == cards[2].GetRank &&
                 cards[3].GetRank != cards[0].GetRank &&
                 cards[4].GetRank != cards[0].GetRank &&
                 cards[3].GetRank != cards[4].GetRank;

            /* ------------------------------------------------------
               Check for: a x x x b
           ------------------------------------------------------- */
            middleThreeSame = cards[1].GetRank == cards[2].GetRank &&
                 cards[2].GetRank == cards[3].GetRank &&
                 cards[0].GetRank != cards[1].GetRank &&
                 cards[4].GetRank != cards[1].GetRank &&
                 cards[0].GetRank != cards[4].GetRank;

            /* ------------------------------------------------------
               Check for: a b x x x
           ------------------------------------------------------- */
            lastThreeSame = cards[2].GetRank == cards[3].GetRank &&
                 cards[3].GetRank == cards[4].GetRank &&
                 cards[0].GetRank != cards[2].GetRank &&
                 cards[1].GetRank != cards[2].GetRank &&
                 cards[0].GetRank != cards[1].GetRank;

            if(firstThreeSame || middleThreeSame || lastThreeSame)
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
