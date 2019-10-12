using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        private IBlackjackPlayer PlayerOne;
        private IBlackjackPlayer PlayerTwo;
        private Deck Deck;

        public void StartNewGame()
        {
            PlayerOne = new Player();
            PlayerTwo = new Dealer();
            Deck = new Deck(); //jauna kāršu kava
            Deck.Shuffle(); //sajaukt kāršu sēcību

            //Give 2 cads for each player
            for(var i = 2; i > 0; i--)
            {
                PlayerOne.GiveCard(Deck.GetCard());
                PlayerTwo.GiveCard(Deck.GetCard());
            }
        }
        public void Loop()
        {           
            while(!PlayerOne.IsGameCompleted() && PlayerOne.WantCard()) //Loop for player
            {
                Card card = Deck.GetCard();
                PlayerOne.GiveCard(card);
            }
            if(PlayerOne.CountPoints() > 21)
            {
                Console.WriteLine("Game over, dealer wins! You got {0} points.", PlayerOne.CountPoints());
            }
            else if(PlayerOne.CountPoints() == 21)
            {
                Console.WriteLine("You win!");
            }
                        //ar return; var partraukt visu metodi jebkura bridi
            else
            {
                while (!PlayerTwo.IsGameCompleted() && PlayerTwo.WantCard()) //Loop for dealer
                {
                    Card card = Deck.GetCard();
                    PlayerTwo.GiveCard(card);

                    Console.WriteLine("You got {0} points", PlayerOne.CountPoints());
                }
                int playerPoints = PlayerOne.CountPoints();
                int dealerPoints = PlayerTwo.CountPoints();
                Console.WriteLine($"Your points {PlayerOne.CountPoints()}");
                Console.WriteLine($"Dealer points {PlayerTwo.CountPoints()}");

                Console.WriteLine(dealerPoints > 21 || playerPoints > dealerPoints  //short version instead of if else
                    ? "You win!"
                    : "You lose!");
            }
        }
    }
}
