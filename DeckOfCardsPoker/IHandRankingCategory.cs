using System;

namespace DeckOfCardsPoker
{
    public interface IHandRankingCategory
    {
        bool FindTheRank(Card[] cards);

        Tuple<int,string> GetValue();
    }
}
