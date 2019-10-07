using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelpers
{
    public class DateReader : BaseConsoleReader<DateTime> //<> iekavas liek datu tipu, jo klase no kuras manto ir noradits generic datu tips
    {
        protected override bool CheckValue(string input, out DateTime value) //norada datu tipu, kas tiks atgriezts
        {
            //jaizdzes noklusejuma pazinojumu
            return DateTime.TryParse(input, out value);
        }
    }
}
