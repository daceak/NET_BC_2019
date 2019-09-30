using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //kreisaja puse tiek iekrasots, kas sobrid tiek mainits un ko saglabas version control
            try
            {
            int num1 = GetNumber("Enter number one: ");
            int num2 = GetNumber("Enter number two: ");
            Console.WriteLine("Division = {0}, Sum is {1)",
                Calculator.Divide(num1, num2),
                Calculator.Sum(num1, num2));
            }
            catch(CalculatorException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {
                Console.WriteLine("Unknown error");
            }

            Console.Read();
        }

        static int GetNumber(string text)
        {
            Console.Write(text);
            string input = Console.ReadLine();

            /*if (int.TryParse(input, out int result))
            {
            return result;
            }*/

            try
            {
                int result = int.Parse(input);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
                //rekursija, atgriezas uz funcijas sakumu
                return GetNumber(text);
            }

        }
    }
}
