using System;

namespace DeckOfCardsPoker.Ranks
{
    public class Straight : IHandRankingCategory
    {
        private const string category = "Straight";
        private const int BaseValue = 4000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            int i, testRank;

            if (cards.Length != 5)
            {
                return false;
            }

            Helper.SortByRank(cards);

            /* ===========================
                 Check if hand has an Ace
               =========================== */
            if (cards[4].GetRank == Rank.ACE)
            {
                /* =================================
                   Check straight using an Ace
                   ================================= */
                bool a = cards[0].GetRank == Rank.TEN && cards[1].GetRank == Rank.JACK &&
                            cards[2].GetRank == Rank.QUEEN && cards[3].GetRank == Rank.KING;
                bool b = cards[0].GetRank == Rank.TWO && cards[1].GetRank == Rank.THREE &&
                            cards[2].GetRank == Rank.FOUR && cards[3].GetRank == Rank.FIVE;

                if(a || b)
                {
                    value = BaseValue + Helper.ValueHighCard(cards);
                    return true;
                }
                return false;
            }
            else
            {
                /* ===========================================
                   General case: check for increasing values
                   =========================================== */
                testRank = (int)cards[0].GetRank + 1;

                for (i = 1; i < 5; i++)
                {
                    if ((int)cards[i].GetRank != testRank)
                        return (false);        // Straight failed...

                    testRank++;   // Next card in hand
                }

                value = BaseValue + Helper.ValueHighCard(cards);
                return true;
            }
        }

        public Tuple<int, string> GetValue()
        {
            return Tuple.Create(value, category);
        }
    }
}
