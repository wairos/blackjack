namespace DeckOfCards;

public class Dealer : Player {
    public Dealer(string name) : base(name)
    {
    }

    public new string showHand() {
        Card faceCard = this.hand[0];
        string mes = faceCard.getName();
        for(int i = 1; i < this.hand.Count; i++) {
            mes += ", ?";
        }
        return mes;
    }

    public string revealHand() {
        return string.Join(", ", this.hand.Select(x => x.getName() + $"<{x.value}>"));
    }
}