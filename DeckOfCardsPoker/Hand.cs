using DeckOfCardsPoker.Ranks;
using System;

namespace DeckOfCardsPoker
{
    public class Hand
    {
        private Card[] Cards;
        private string HandCategory;
        public string PlayerName { get; private set; }
        public int RankValue { get; private set; }
        
        public Hand(Deck deck, string name)
        {
            Cards = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                Cards[i] = deck.DrawFromDeck;
            }
            PlayerName = name;
        }

        public void Display()
        {
            Console.Write("{0} has: ", PlayerName); 
            for (int i = 0; i < 5; i++)
            {
                Console.Write("[{0},{1}] ", Cards[i].GetSuit, Cards[i].GetRank);
            }
            Console.WriteLine();
            Console.WriteLine("Rank: {0} Type: {1}\n", RankValue, HandCategory);
        }

        public void GetRanking()
        {
            if(Cards.Length != 5)
            {
                Console.WriteLine("{0} don't have 5 cards.", PlayerName);
                return;
            }

            RankingImplementer rankingImplementer = new RankingImplementer();
            Tuple<int,string> result = rankingImplementer.Execute(Cards);
            HandCategory = result.Item2;
            RankValue = result.Item1;
        }
    }
}
