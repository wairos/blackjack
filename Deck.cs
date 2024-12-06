namespace DeckOfCards
{
    public class Deck 
    {
        int totalCards = 52;
        int draw = 0;
        public Card[] cards;

        private int[] usedIndexes;


        
        public Deck() 
        {
            this.cards = this.generateCards();
            this.usedIndexes = new int[this.totalCards];
        }

        public Card drawCard() 
        {
            Random ran = new Random();
            int index = ran.Next(0, totalCards);
            if(Array.Exists(this.usedIndexes, n => n == index)){
                return this.drawCard();
            }
            this.usedIndexes[this.draw++] = index;
            return this.cards[index];
        }

        private Card[] generateCards() 
        {
            Card[] cards = new Card[this.totalCards];
            int cardIndex = 0;
            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 13; j++) 
                { 
                    cards[cardIndex] = new Card(j, i);
                    cardIndex++;
                }
            }
            return cards; 
        }

        public string fanCards() 
        {
            if (this.cards == null || this.cards.Length == 0)
            {
                throw new InvalidOperationException("No cards in the deck.");
            }

            string fanStr = "";
            for (int i = 0; i < this.cards.Length; i++) 
            {
                if (i > 0) 
                {
                    fanStr += ", ";
                }
                Card card = this.cards[i];
                fanStr += card.getName(); 
            }
            return fanStr;
        }

        public void shuffle()
        {
            Random rand = new Random();
            for (int i = this.cards.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[j];
                this.cards[j] = temp;
            }
        }
    }
}