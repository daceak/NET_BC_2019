using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                game.StartNewGame();
                game.Loop();
            }
            catch(Exception)
            {
                Console.WriteLine("Unexpected error!");
            }

            Console.Read();
        }
    }
}
