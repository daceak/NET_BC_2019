using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// Klase, kurā tiek realizēta spēles gaita, sākot jaunu spēli, izsaucot ciklu un sekojot līdzi kļūdu noķeršanai programmas izpildes gaitā.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while(true)
                {
                Game game = new Game();
                game.StartNewGame();
                game.Loop();
                    Console.WriteLine("Start a new game (y/n)?");
                    if(Console.ReadLine() == "n")
                    {
                        break;
                    }
                }

            }
            catch(Exception msg)
            {
                Console.WriteLine($"Unexpected error!{msg.Message}");
            }
            Console.Read();
        }
    }
}
