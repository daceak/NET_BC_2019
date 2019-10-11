using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// Klase User ir spēlētāja klase, kas manto abstrakto klasi Base Player, kas nosaka, ka šajā klasē jārealizē mantojamās klases metodes(GetName un GuessNumber).
    /// </summary>
    public class User : BasePlayer
    {
        /// <summary>
        /// Metode ar kuru noskaidrot spēlētāja vārdu.
        /// </summary>
        /// <returns>Atgriež spēlētāja ievadīto vārdu string formātā. </returns>
        public override string GetName()
        {
            if(!String.IsNullOrEmpty(Name))
            {
                return Name;
            }
            return ConsoleInput.GetText("Enter your name: ");
        }
        /// <summary>
        /// Metode ar kuru tiek realizēts spēlētāja minējums.
        /// </summary>
        /// <returns>Atgriež minējumu int formātā.</returns>
        public override int GuessNumber()
        {
            CurrentGuess = ConsoleInput.GetInt("Enter your guess: ");
            return CurrentGuess;
        }
    }
}
