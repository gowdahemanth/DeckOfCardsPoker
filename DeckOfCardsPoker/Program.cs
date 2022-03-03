using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 1 || args.Length < 1)
            {
                Console.WriteLine("Error: Invalid argument.");
                Console.WriteLine("USAGE: DeckOfCardsPoker.exe input1.txt");
                return;
            } 

            string[] playerList = ReadAndValidateInput.ReadInputFile(args[0]);
            if(playerList is null || playerList.Length == 0)
            {
                Console.WriteLine("Warning: Player not found.");
                return;
            }

            //Initialize a Deck object, which will create a deck of 52 cards.
            Deck deck = new Deck();

            //For each player, create a 'Hand' object, which will assign 5 random cards to the player.
            List<Hand> hands = new List<Hand>();
            foreach(string player in playerList)
            {
                Hand hand = new Hand(deck, player);
                hands.Add(hand);
            }
            
            foreach (Hand hand in hands)
            {
                hand.GetRanking();
            }

            //Display all players and ranks.
            foreach (Hand hand in hands)
            {
                hand.Display();
            }

            //Display winner.
            Hand winner = hands.OrderByDescending(p => p.RankValue).First();
            Console.WriteLine("Winner is {0}", winner.PlayerName);
        }
    }
}
