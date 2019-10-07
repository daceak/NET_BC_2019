using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public class Game
    {
        int CurrentNumber; // current number player guesses
        IPlayer PlayerOne;
        IPlayer PlayerTwo;
        public void StartNewGame() // generates new random number
        {
            Random random = new Random();
            CurrentNumber = random.Next(1, 501);

            PlayerOne = new User();
            PlayerTwo = new Robot();

        }
        public void Loop() // main game logic
        {
            //playerturn
            //robotguess etc
            while(true)
            {
                PlayerTurn(PlayerOne);
            }
        }
        public void PlayerTurn(IPlayer player) // player move
        {
            player.GuessNumber();
            

        }
    }
}
