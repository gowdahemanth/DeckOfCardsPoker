using System;

namespace DeckOfCardsPoker.Ranks
{
    public class TwoPairs : IHandRankingCategory
    {
        private const string category = "Two Pair";
        private const int BaseValue = 2000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            bool firstUnmatched, middleUnmatched, lastUnmatched;
            int tempValue = 0;

            if (cards.Length != 5)
                return false;

            //if (is4s(h) || isFullHouse(h) || is3s(h))
            //    return (false);        // The hand is not 2 pairs (but better)      

            Helper.SortByRank(cards);

            /* --------------------------------
               Checking: a a  b b x
           -------------------------------- */
            lastUnmatched = cards[0].GetRank == cards[1].GetRank &&
                 cards[2].GetRank == cards[3].GetRank;
            if(lastUnmatched)
            {
                tempValue = ((int)cards[2].GetRank * 14 * 14 * 14 * 14) +
                            ((int)cards[0].GetRank * 14 * 14) +
                            (int)cards[4].GetRank;
            }

            /* ------------------------------
               Checking: a a x  b b
           ------------------------------ */
            middleUnmatched = cards[0].GetRank == cards[1].GetRank &&
                 cards[3].GetRank == cards[4].GetRank;
            if (middleUnmatched)
            {
                tempValue = ((int)cards[3].GetRank * 14 * 14 * 14 * 14) +
                            ((int)cards[0].GetRank * 14 * 14) +
                            (int)cards[2].GetRank;
            }

            /* ------------------------------
               Checking: x a a  b b
           ------------------------------ */
            firstUnmatched = cards[1].GetRank == cards[2].GetRank &&
                 cards[3].GetRank == cards[4].GetRank;
            if (firstUnmatched)
            {
                tempValue = ((int)cards[3].GetRank * 14 * 14 * 14 * 14) +
                            ((int)cards[1].GetRank * 14 * 14) +
                            (int)cards[0].GetRank;
            }

            if (lastUnmatched || middleUnmatched || firstUnmatched)
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
