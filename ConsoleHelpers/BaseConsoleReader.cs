using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelpers
{
    public abstract class BaseConsoleReader<T> //T norada uz generic datu tipu, janomaina visur, kur tiek noradits datu tips saja klase
    {    
        //abstract: sis klases ietvaros metode netiek realizeta, bet to ir jarealize nakamaja klase, kas so klasi un metodi izmantos
    
        protected abstract bool CheckValue(string input, out T value);
        public T GetValue(string question) 
        {
            Console.WriteLine(question);
            string input = Console.ReadLine();
            if(CheckValue(input, out T value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Invalid value!");
                return GetValue(question);
            }
        }
    }
}
