using DeckOfCards;

Console.Clear();
string bar = "***************************************";
Console.WriteLine($"\n{bar}\n{bar}\n**********BlackJack Terminal***********\n{bar}\n{bar}\n\n");
bool play = true;
Dealer dealer = new ("Dealer");
Player player = setupPlayer();
Console.Clear();

while(play) {
    DeckOfCards.Deck deck = new Deck();
    deck.shuffle();
    player.give(deck.drawCard());
    player.give(deck.drawCard());
    dealer.give(deck.drawCard());
    displayRecord();
    showPlayState(dealer, player);
    string decision = promptPlayerForAction();
    Console.Clear();
    displayRecord();
    while(decision != "HOLD"){
        if(decision == "HIT") {
            Card newCard = deck.drawCard();
            player.give(newCard);
            showPlayState(dealer, player);
            if(player.handValue > 21) break;
            decision = promptPlayerForAction();
        } else {
            Console.WriteLine("\n\nHuh, HOLD or HIT?");
            decision = Console.ReadLine().ToUpper();
        }
        Console.Clear();
        displayRecord();
    }
    dealer.give(deck.drawCard());
    dealersTurn(dealer, player, deck);
    Console.Clear();
    
    string gameResultMessage;
    if(player.handValue <= 21 && (dealer.handValue < player.handValue || dealer.handValue > 21)) {
        gameResultMessage = "YOU WIN! :)";
        player.wins = player.wins + 1;
    }else if(player.handValue == dealer.handValue) {
        gameResultMessage = "DRAW";
    }else{
        gameResultMessage = "YOU LOSE! :(";
        dealer.wins = dealer.wins + 1;
    }

    displayRecord();

    Console.WriteLine("Dealer:\n");
    Console.WriteLine($"\t{ dealer.revealHand() }");
    Console.WriteLine($"Score:\t{dealer.handValue}\n");

    Console.WriteLine(player.name + ":\n");
    Console.WriteLine($"\t{ player.showHand() }");
    Console.WriteLine($"Score:\t{player.handValue}\n\n");
   
    Console.WriteLine(gameResultMessage + "\n");

    player.clearHand();
    dealer.clearHand();
  
    Console.WriteLine("PLAY AGAIN? YES or NO");
    string again = Console.ReadLine().ToUpper();
    Console.Clear();
    if(again != "YES") {
        play = false;
    }

}

Player setupPlayer() {
    Console.WriteLine("Player Name:\n");
    string playerName = Console.ReadLine();
    if(playerName != ""){
        return new Player(playerName);
    }else{
        return setupPlayer();
    }
}

string promptPlayerForAction() {
    Console.WriteLine("\n***************************************\n\nHIT or HOLD?"); 
    return Console.ReadLine().ToUpper();
}

void showPlayState(Player dealer, Player player) {
    Console.WriteLine("Dealer:\n");
    Console.WriteLine($"\t{ dealer.showHand() }\n\n");
    Console.WriteLine(player.name + ":\n");
    Console.WriteLine($"\t{ player.showHand() }\n\n");
}

void dealersTurn(Player dealer, Player player, Deck deck){
    bool dealerDraw = shouldDealerGo(dealer, player);
    while(dealerDraw){
        Card newDealerCard = deck.drawCard();
        dealer.give(newDealerCard);
        dealerDraw = shouldDealerGo(dealer, player);
    }
}

bool shouldDealerGo(Player dealer, Player player) {
    bool shouldGo = dealer.handValue < 21 && dealer.handValue < player.handValue && player.handValue <= 21;
    return shouldGo;
}

void displayRecord() {
    Console.Write("Total Wins:\t" + player.wins + "\t\t");
    Console.WriteLine("Total Loses:\t" + dealer.wins + "\n\n");
}