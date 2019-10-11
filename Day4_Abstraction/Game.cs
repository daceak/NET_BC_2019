using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// Klase Game realizē spēles metodes- sākt jaunu spēi, Ciklu un spēlētāju gājienus.
    /// </summary>
    public class Game
    {
        private int CurrentNumber; // number to guess
        private IPlayer PlayerOne;
        private IPlayer PlayerTwo;
        /// <summary>
        /// StartNewGame metode uzģenerē jaunu minamo skaitli un divus jaunus spēlētājus.
        /// </summary>
        public void StartNewGame() // generates new random number
        {
            Random random = new Random();
            CurrentNumber = random.Next(1, 501);

            PlayerOne = new Robot();
            PlayerTwo = new User();

        }
        /// <summary>
        /// Metode Loop realizē spēles ciklu kamēr viens no spēlētājiem ir uzminējis skaitli. Ar šo metodi tiek izsaukta metode Player Turn ar kuras palīdzību noskaidro vai skaitlis ir uzminēts.
        /// </summary>
        public void Loop() // main game logic
        {
            while(true)
            {
                if(PlayerTurn(PlayerOne)) //vispirms izpilda to, kas ieksa if, tad parbauda rezultatu
                {
                    break;
                }
                if (PlayerTurn(PlayerTwo))
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Metode, ar kuras palīdzību noskaidro spēlētāja minējumu un pārbauda vai tas atbilst minamajam skaitlim.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Atgriež spēlētāja gājiena rezultātu- skaitlis ir uzminēts vai nē.</returns>
        private bool PlayerTurn(IPlayer player) // player move
        {
            player.GuessNumber();
            bool isGuessed = player.IsNumberGuessed(CurrentNumber);
            if(isGuessed)
            {
                Console.WriteLine($"Player {player.GetName()} wins");
            }
            return isGuessed; 
        }
    }
}
