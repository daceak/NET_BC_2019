using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public class User : BasePlayer
    {
        public override string GetName()
        {
            return ConsoleInput.GetText("Enter your name: ");
        }

        public override int GuessNumber()
        {
            CurrentGuess = ConsoleInput.GetInt("Enter your guess: ");
            return CurrentGuess;
        }
    }
}
