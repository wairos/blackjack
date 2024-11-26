using DeckOfCards;

bool play = true;
while(play) {

    Player player = new Player("Player 1");
    Player dealer = new Player("Dealer");

    DeckOfCards.Deck deck = new Deck();
    deck.shuffle();
    Card card = deck.drawCard();
    player.give(card);
    card = deck.drawCard();
    player.give(card);
    card = deck.drawCard();
    dealer.give(card); 
    card = deck.drawCard();
    dealer.give(card); 
    string bar = "\n***************************************";
    Console.WriteLine($"{bar}{bar}\n**********BlackJack Terminal***********{bar}{bar}\n\n");
    Console.WriteLine("Dealer:\n");
    Console.WriteLine($"\t{ dealer.showDealerHand() }\n\n");
    Console.WriteLine("Player 1:\n");
    Console.WriteLine($"\t{ player.showHand() }\n\n");

    string question = "\n\nHIT or HOLD?";
    Console.WriteLine(question);
    string decision = Console.ReadLine();

    while(decision != "HOLD"){
        if(decision == "HIT") {
            Console.WriteLine("\n\n*****PLAYER HIT!!*****\n\n");
            Card newCard = deck.drawCard();
            player.give(newCard);
        
            Console.WriteLine("Dealer:\n");
            Console.WriteLine($"\t{ dealer.showDealerHand() }\n\n");
            Console.WriteLine("Player 1:\n");
            Console.WriteLine($"\t{ player.showHand() }\n\n");
            if(player.handValue > 21) {
                Console.WriteLine("\n\n***BUST!***\n\n");
                break;
            }
            Console.WriteLine(question);
        } else {
            Console.WriteLine("\n\nHuh, HOLD or HIT?");
        }
        decision = Console.ReadLine();
    }

    bool dealerDraw = dealerGoes(dealer, player);
    while(dealerDraw){
        Card newDealerCard = deck.drawCard();
        dealer.give(newDealerCard);
        dealerDraw = dealerGoes(dealer, player);
    }

    Console.WriteLine("Dealer:\n");
    Console.WriteLine($"\t{ dealer.showHand() }\n");
    Console.WriteLine($"Score:\t{dealer.handValue}\n\n");

    Console.WriteLine("Player 1:\n");
    Console.WriteLine($"\t{ player.showHand() }\n");
    Console.WriteLine($"Score:\t{player.handValue}\n\n");

    if(player.handValue <= 21 && (dealer.handValue < player.handValue || dealer.handValue > 21)) {
        Console.WriteLine("\n\n***YOU WIN!***\n\n");

    }else if(player.handValue == dealer.handValue) {
        Console.WriteLine("\n\n***DRAW***\n\n");
    }else{
        Console.WriteLine("\n\n***YOU LOSE!***\n\n");
    }

    Console.WriteLine("PLAY AGAIN?");
    string again = Console.ReadLine();
    if(again != "YES") {
        play = false;
    }

}

bool dealerGoes(Player dealer, Player player) {
    bool shouldGo = dealer.handValue < 21 && dealer.handValue < player.handValue && player.handValue <= 21;
    return shouldGo;
}