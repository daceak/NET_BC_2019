using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public class Robot : BasePlayer
    {
        public override string GetName()
        {
            return "R0B0T";
        }

        public override int GuessNumber() //Robot guess
        {
            Random random = new Random();
            CurrentGuess = random.Next(1, 501);
            return CurrentGuess;
        }
    }
}
