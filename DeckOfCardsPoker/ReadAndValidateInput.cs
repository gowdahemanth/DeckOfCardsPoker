using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeckOfCardsPoker
{
    public static class ReadAndValidateInput
    {
        private static IList<string> Players = new List<string>();
        
        public static string[] ReadInputFile(string fileName)
        {
            string[] playerList = null;
            try
            {
                playerList = File.ReadAllLines(fileName).Where(line => line != "").ToArray();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Error: Input file not found", ex.InnerException);
                return Players.ToArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: File read", ex.InnerException);
                return Players.ToArray();
            }

            foreach (string player in playerList)
            {
                if(Players.Count == 10)
                {
                    Console.WriteLine("Input has more than 10 players. Only the first 10 valid names are selected.");
                    break;
                }
                bool isValidPlayerName = player.All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c));

                if(isValidPlayerName)
                {
                    Players.Add(player);
                }
                else
                {
                    Console.WriteLine("Warning: {0} is not a valid player name.", player);
                }
            }

            return Players.ToArray();
        }
    }
}
