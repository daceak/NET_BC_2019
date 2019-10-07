using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    public interface IPlayer  //interface tikai norada, kam ir jabut
    {
        int GuessNumber();
        bool IsNumberGuessed(int number);
        string GetName();
    }
}
