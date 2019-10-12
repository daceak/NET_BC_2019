using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelpers
{
    public class ConsoleInput
    {
        public static DateTime GetDate(string question)   //static var izsaukt bez klases instances 
        {
            return new DateReader().GetValue(question);  //iekavas norada veidu uz kuru japarveido object , kas tiek atgriezts no metodes GetValue
        }

        public static string GetText(string question)
        {
            return new TextReader().GetValue(question);
        }
        public static int GetInt(string question)
        {
            return new IntegerReader().GetValue(question);
        }

        public static bool GetBool(string question)
        {
            string answer = GetText(question).ToLower();
            if(answer == "y" || answer == "yes")
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
