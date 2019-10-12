using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public abstract class BasePlayer : IBlackjackPlayer
    {               //encapsulation- visas ipasibas tiek definets viena klase ka privatas
        //private netiek mantots
        protected string Name { get; set; }
        protected List<Card> Cards { get; set; }

        public BasePlayer()
        {
            Cards = new List<Card>();
            Name = GetName();
        }
        public int CountPoints()
        {
            int points = Cards.Sum(c => c.GetPoints()); //c norada uz card objektu, un c. norada, ko jamekle konkretaja objekta
            /*foreach (var card in Cards)
            {
                points += card.GetPoints();
            }*/
            if(points > 21)
            {
                int aceCount = Cards.Count(c => c.GetPoints() == 11);
                while(aceCount > 0 && points > 21)
                {
                    points -= 10;
                    aceCount--;
                }
            }
            return points;
        }

        public List<Card> GetCards()
        {
            return Cards;
        }


    public abstract string GetName();

        public virtual void GiveCard(Card card) //ar virtual nosaka, ka klases, kas manto so klasi, var parrakstit konkreto metodi. Polymorphism
        {
            Cards.Add(card);
        }

        public bool IsGameCompleted()
        {
            return CountPoints() > 21;
        }

        public abstract bool WantCard(); //abstract metodes noeikti japarraksta (override) klase, kura manto so klasi
    }
}
