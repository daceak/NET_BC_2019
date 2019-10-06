using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public abstract class BasePlayer :IPlayer
    {
        public string Name { get; set; }
        public int CurrentGuess { get; set; }
        public static bool IsNumberGuessed(int number)
        {
            //check
            return false;
        }
        public abstract string GetName()
        {
            string name = "";
            return name;
        }
    }
}
