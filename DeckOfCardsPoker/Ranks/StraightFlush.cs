using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCardsPoker.Ranks
{
    public class StraightFlush : IHandRankingCategory
    {
        private const string category = "Straight Flush";
        private const int BaseValue = 8000000;
        private int value;

        public bool FindTheRank(Card[] cards)
        {
            Straight straight = new Straight();
            Flush flush = new Flush();
            if(straight.FindTheRank(cards) && flush.FindTheRank(cards))
            {
                value = BaseValue + Helper.ValueHighCard(cards);
                return true;
            }
            return false;
        }

        public Tuple<int,string> GetValue()
        {
            return Tuple.Create(value, category);
        }
    }
}
