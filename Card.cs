namespace DeckOfCards
{
    public class Card
    {
        public int rank { get; }
        public int value { get; set; }
        public int suit { get; }

        public bool isAce { get; }

        private static readonly string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private static readonly string[] suits = { "Diamond", "Spade", "Club", "Heart" }; 

        public Card(int rankIndex, int suitIndex)
        {
            this.rank = rankIndex;
            this.suit = suitIndex;
            this.value = (rankIndex == 0) ? 1 : (rankIndex <= 9) ? rankIndex + 1 : 10;
            this.isAce = rankIndex == 0;
        }

        public string getSuit()
        {
            return suits[this.suit];
        }

        public string getRank()
        {
            return ranks[this.rank];
        }

        public string getName()
        {
            return $"{getRank()} of {getSuit()}s";
        }
    }
}
