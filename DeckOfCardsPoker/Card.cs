namespace DeckOfCardsPoker
{
    public class Card
    {
        public Card(Suit _suit, Rank _rank)
        {
            GetSuit = _suit;
            GetRank = _rank;
        }

        public Suit GetSuit { get; }

        public Rank GetRank { get; }
    }

    public enum Suit
    {
        HEARTS = 0,
        DIAMONDS,
        CLUBS,
        SPADES
    }

    public enum Rank
    {        
        TWO = 2,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    }
}
