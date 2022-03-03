namespace DeckOfCardsPoker
{
    public static class Helper
    {
        /* ---------------------------------------------
            Sort hand by suit:

            smallest suit card first ....

            (Finding a flush is eaiser that way)
        --------------------------------------------- */
        public static void SortBySuit(Card[] h)
        {
            int i, j, min_j;

            /* ---------------------------------------------------
               The selection sort algorithm
               --------------------------------------------------- */
            for (i = 0; i < h.Length; i++)
            {
                /* ---------------------------------------------------
                   Find array element with min. value among
                   h[i], h[i+1], ..., h[n-1]
                   --------------------------------------------------- */
                min_j = i;   // Assume elem i (h[i]) is the minimum

                for (j = i + 1; j < h.Length; j++)
                {
                    if (h[j].GetSuit < h[min_j].GetSuit)
                    {
                        min_j = j;    // We found a smaller suit value, update min_j     
                    }
                }

                /* ---------------------------------------------------
                   Swap a[i] and a[min_j]
                   --------------------------------------------------- */
                Card help = h[i];
                h[i] = h[min_j];
                h[min_j] = help;
            }
        }


        /* ---------------------------------------------
          Sort hand by rank:

              smallest suit card first ....

          (Finding a flush is eaiser that way)
          --------------------------------------------- */
        public static void SortByRank(Card[] h)
        {
            int i, j, min_j;

            /* ---------------------------------------------------
               The selection sort algorithm
               --------------------------------------------------- */
            for (i = 0; i < h.Length; i++)
            {
                /* ---------------------------------------------------
                   Find array element with min. value among
                   h[i], h[i+1], ..., h[n-1]
                   --------------------------------------------------- */
                min_j = i;   // Assume elem i (h[i]) is the minimum

                for (j = i + 1; j < h.Length; j++)
                {
                    if (h[j].GetRank < h[min_j].GetRank)
                    {
                        min_j = j;    // We found a smaller rank value, update min_j     
                    }
                }

                /* ---------------------------------------------------
                   Swap a[i] and a[min_j]
                   --------------------------------------------------- */
                Card help = h[i];
                h[i] = h[min_j];
                h[min_j] = help;
            }
        }
        
        public static int ValueHighCard(Card[] cards)
        {
             return (int)cards[0].GetRank +
                                14 * (int)cards[1].GetRank +
                                14 * 14 * (int)cards[2].GetRank +
                                14 * 14 * 14 * (int)cards[3].GetRank +
                                14 * 14 * 14 * 14 * (int)cards[4].GetRank;
        }
    }
}
