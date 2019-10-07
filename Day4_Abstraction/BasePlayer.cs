using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public abstract class BasePlayer : IPlayer
    {
        public string Name { get; set; }
        public int CurrentGuess { get; set; }

        protected BasePlayer()
        {
            Name = GetName();
        }

        public abstract int GuessNumber();

        public abstract string GetName();

        public virtual bool IsNumberGuessed(int number)
        {
            return CurrentGuess == number;
        }
    }
}
