using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public abstract class BasePlayer : IBlackjackPlayer
    {
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

        public void GiveCard(Card card)
        {
            Cards.Add(card);
        }

        public bool IsGameCompleted()
        {
            return CountPoints() > 21;
        }

        public abstract bool WantCard();
    }
}
