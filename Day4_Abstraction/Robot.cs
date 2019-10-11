using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// Klase Robot ir spēlētāja-robota klase, kas manto abstrakto klasi Base Player, kas nosaka, ka šajā klasē jārealizē mantojamās klases metodes(GetName un GuessNumber).
    /// </summary>
    public class Robot : BasePlayer  //seit nav konstruktors atseviski, bet tas tiek izsaukts no mantotas klases BasePlayer
    {
        /// <summary>
        /// Metode ar kuru iegūst spēlētāja-robota vārdu.
        /// </summary>
        /// <returns>Atgriež jau nodefinētu string formāta vārdu.</returns>
        public override string GetName()
        {
            return "R0B0T";
        }
        /// <summary>
        /// Metode ar kuru tiek realizēts spēlētāja-robota minējums.
        /// </summary>
        /// <returns>Atgriež Random uzģenerētu int tipa skaitli noteiktās robežās, balstoties uz iepriekšejo minējumu. </returns>
        public override int GuessNumber() //Robot guess
        {
            Thread.Sleep(200);
            if(NextGuess == 0)
            {
            CurrentGuess = new Random().Next(1, 501);
            }
            else if (NextGuess == -1)
            {
                CurrentGuess = new Random().Next(1, CurrentGuess);
            }
            else if(NextGuess == 1)
            {
                CurrentGuess = new Random().Next(CurrentGuess + 1, 501);
            }
            return CurrentGuess;
        }
    }
}
