using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// BasePlayer ir abstrakta klase, kurā tiek realizēts IPlayer interfeiss, kas nosaka, ka šajā klasē jābūt metodēm GetName un GuessNumber.
    /// Šīs klases ietvarā nerealizē norādītās metodes, jo klase ir abstrakta, bet klasēm, kas mantos BasePlayer būs jārealizē šīs klases visas metodes. 
    /// </summary>
    public abstract class BasePlayer : IPlayer
    {
        protected string Name { get; set; } //protected pieejamas saja un klases, kas manto so klasi
        protected int CurrentGuess { get; set; }

        protected int NextGuess { get; set; }

        /// <summary>
        /// Konstruktors, kas nosaka, ka izmantojot BasePlayer klasi un izveidojot jaunu objektu citā klasē, tiks izsaukta GetName metode.
        /// </summary>
        protected BasePlayer() //constructor to create user/robot based on this class. Meaning when a new object will be created with this construct., GetName will be called.
        {
            Name = GetName();
        }

        /// <summary>
        /// Metode ar kuru tiks realizēts spēlētāja minējums. Tiks realizēta klasē, kas mantos klasi Base Player.
        /// </summary>
        /// <returns>Atgriež minējumu skaitļa formā.</returns>
        public abstract int GuessNumber();

        /// <summary>
        /// Metode, lai noskaidrotu spēlētāja vārdu. Tiks realizēta klasē, kas mantos klasi Base Player.
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// Metode ar kuŗu pārbaudīt vai minētais skaitlis ir vienāds ar spēles sākumā uzģenerēto skaitli. Izsaucot metodi tai ir jānorāda sistēmas uzģenerēto skaitli. Tiks realizēta klasē, kas mantos klasi Base Player.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Atgriež true vai false, atkarībā vai skaitlis ir uzminēts.</returns>
        public virtual bool IsNumberGuessed(int number)
        {
            if(number > CurrentGuess)
            {
                Console.WriteLine($"{Name}'s guess {CurrentGuess} is less than number to guess!");
                NextGuess = 1; //guess too small
            }
            else if(number < CurrentGuess)
            {
                Console.WriteLine($"{Name}'s guess {CurrentGuess} is bigger than number to guess!");
                NextGuess = -1; //guess too big
            }
            return CurrentGuess == number;
        }
    }
}
