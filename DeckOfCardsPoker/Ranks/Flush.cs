using System;

namespace DeckOfCardsPoker.Ranks
{
    public class Flush : IHandRankingCategory
    {
        private const string category = "Flush";
        private const int BaseValue = 5000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            if (cards.Length != 5)
            {
                return false;
            }

            Helper.SortBySuit(cards);
            if(cards[0].GetSuit == cards[4].GetSuit)
            {
                value = BaseValue + Helper.ValueHighCard(cards);
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
