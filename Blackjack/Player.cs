using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player : BasePlayer
    {
        public override string GetName() //abstract, kad parraksta abstraktu metodi no mantotas klases
        {
            if(!String.IsNullOrEmpty(Name))
            {
                return Name;
            }
            return ConsoleInput.GetText("Enter your name: ");
        }
        public override bool WantCard()
        {
            return ConsoleInput.GetBool("Do you want another card (y/n)? ");
        }

        public override void GiveCard(Card card) //so metodi parraksta no klases BasePlayer
        {
            base.GiveCard(card); //base nosaka- izsaukt ari bazes klases funkciju. bez base neizmantos esošo saturu šai metodei
            Console.WriteLine($"You got card: {card.GetTitle()}, total points now: {CountPoints()}");
        }
    }
}
