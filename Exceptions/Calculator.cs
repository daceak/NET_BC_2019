using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Calculator
    {
        public static int Sum (int num1, int num2)
        {
            return num1 = num2;
        }
        public static decimal Divide (int num1, int num2)
        {
            //rules (parbaudes secigi pirms izpildes)            
            if(num2 == 0)
            {
                throw new CalculatorException("Can't divide by zero"); //teksts iekavas, jo konstruktora ievada string message
            }
            //execution
            return (decimal)num1 / num2; //te norada decimal, jo citadak atgrieztu ka int, jo input ir int
        }
    }
}
