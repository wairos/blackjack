namespace DeckOfCards;

public class Player {

    public int wins { get; set; }
    public string name { get; }
    public List<Card> hand { get; set;}
    public int handValue { set; get;}

    public Player(string name) {
        this.name = name;
        this.hand = new List<Card> {};
        this.handValue = 0;
    }

    public void give(Card card) {
        this.hand.Add(card);
        this.handValue = this.updateHandValue();
    }

    public string showHand() {
        return string.Join(", ", this.hand.Select(x => x.getName() + $"<{x.value}>"));
    }

    public int updateHandValue() {
        int value = 0;
        int fullValue = 0;
        List<Card> aces = new List<Card>();
        foreach(Card card in this.hand) {
            if(card.isAce) {
                aces.Add(card);
                fullValue += 11;
                value += 1;
            }else{
                fullValue += card.value;
                value += card.value;
            }
        }

        if(fullValue <= 21 && value <= 21) {
            return fullValue;
        }

        foreach(Card card in aces) {
            if(fullValue > 21) {
                fullValue -= 10;
                if(fullValue <= 21) {
                    value = fullValue;
                }
            }
        }
        return value;
    }

    public void clearHand() {
        this.hand.Clear();
    }

}