using System;

namespace DeckOfCardsPoker.Ranks
{
    public class RankingImplementer
    {
        public Tuple<int,string> Execute(Card[] cards)
        {
            //Straight Flush
            IHandRankingCategory _handRankingCategory = new StraightFlush();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Four of a kind
            _handRankingCategory = new FourOfAKind();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Full house
            _handRankingCategory = new FullHouse();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Flush
            _handRankingCategory = new Flush();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Straight
            _handRankingCategory = new Straight();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }
            
            //Three of a kind
            _handRankingCategory = new ThreeOfAKind();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Two pairs
            _handRankingCategory = new TwoPairs();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //One pair
            _handRankingCategory = new OnePair();
            if (_handRankingCategory.FindTheRank(cards))
            {
                return _handRankingCategory.GetValue();
            }

            //Default
            _handRankingCategory = new HighCard();
            _handRankingCategory.FindTheRank(cards);
            return _handRankingCategory.GetValue();
        }
    }
}
