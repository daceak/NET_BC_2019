using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card : Deck
    {
        string Rank;
        string Suit;
        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }
        
        // Returns card’s title (e.g. ‘Kārava 10’)
        public string GetTitle()
        {            
            return Suit + Rank;
        }
        // Returns card’s value (11 for Ace, 10 for face cards, numeric value for others)
        public int GetPoints()
        {
            switch(Rank)
            {
                case "A":
                case "K":
                case "Q":
                case "J":
                    return 10;
                default:
                    return int.Parse(Rank);

            }

        }
    }
}
