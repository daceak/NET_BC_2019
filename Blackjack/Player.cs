using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player : BasePlayer
    {
        public override string GetName()
        {
            return "Dealer";
        }
        public override bool WantCard()
        {
            string another = ConsoleInput.GetText("Do you want another card (y/n)? ").ToLower();
            if (another == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
