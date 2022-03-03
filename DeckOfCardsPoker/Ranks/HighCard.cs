using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCardsPoker.Ranks
{
    public class HighCard : IHandRankingCategory
    {
        private const string category = "High Card";
        private int value;
        public bool FindTheRank(Card[] cards)
        {
            Helper.SortByRank(cards);
            value = Helper.ValueHighCard(cards);
            return true;
        }

        public Tuple<int, string> GetValue()
        {
            return Tuple.Create(value, category);
        }
    }
}
