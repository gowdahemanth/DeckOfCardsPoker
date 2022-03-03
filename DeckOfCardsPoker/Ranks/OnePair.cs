using System;

namespace DeckOfCardsPoker.Ranks
{
    public class OnePair : IHandRankingCategory
    {
        private const string category = "One Pair";
        private const int BaseValue = 1000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            bool a1, a2, a3, a4;
            int tempValue = 0;

            if (cards.Length != 5)
                return false;

            //if (is4s(h) || isFullHouse(h) || is3s(h) || is22s(h))
            //    return (false);        // The hand is not one pair (but better)       

            Helper.SortByRank(cards);

            /* --------------------------------
               Checking: a a x y z
           -------------------------------- */
            a1 = cards[0].GetRank == cards[1].GetRank;

            /* --------------------------------
               Checking: x a a y z
           -------------------------------- */
            a2 = cards[1].GetRank == cards[2].GetRank;

            if (a1 || a2)
            {
                tempValue = ((int)cards[1].GetRank * 14 * 14) + ((int)cards[4].GetRank * 14);
            }

            /* --------------------------------
               Checking: x y a a z
           -------------------------------- */
            a3 = cards[2].GetRank == cards[3].GetRank;

            /* --------------------------------
               Checking: x y z a a
           -------------------------------- */
            a4 = cards[3].GetRank == cards[4].GetRank;

            if (a3 || a4)
            {
                tempValue = ((int)cards[3].GetRank * 14 * 14) + ((int)cards[1].GetRank * 14);
            }

            if(a1 || a2 || a3 || a4)
            {
                value = BaseValue + tempValue;
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
