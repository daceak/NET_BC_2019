using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : BasePlayer
    {
        public const string DEALER_NAME = "Mr. Dealer";
        public override string GetName()
        {
            return DEALER_NAME;
        }
        public override bool WantCard()
        {
            return CountPoints() < 17;
        }
    }
}
