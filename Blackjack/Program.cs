using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                while (ConsoleInput.GetBool("Start new game? "))
                {
                    game.StartNewGame();
                    game.Loop();
                }
            }
            catch(Exception msg)
            {
                Console.WriteLine("Unexpected error! {0}", msg.Message);
            }

            Console.Read();
        }
    }
}
