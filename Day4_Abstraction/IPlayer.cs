using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Abstraction
{
    /// <summary>
    /// Interface IPlayer, kas norāda, ka pielietojot šo interface būs jārealizē sekojošas metodes:
    /// Skaitļa minēšana;
    /// Vai skaitlis ir uzminēts;
    /// Vārda iegūšana.
    /// </summary>
    public interface IPlayer  //interface tikai norada, kam ir jabut
    {
        /// <summary>
        /// Metode ar kuru tiks realizēts spēlētāja minējums.
        /// </summary>
        /// <returns>Atgriež minējumu skaitļa formā.</returns>
        int GuessNumber();
        /// <summary>
        /// Metode ar kuŗu pārbaudīt vai minētais skaitlis ir vienāds ar spēles sākumā uzģenerēto skaitli. Izsaucot metodi tai ir jānorāda sistēmas uzģenerēto skaitli.
        /// </summary>
        /// <param name="number">Atgriež true vai false, atkarībā vai skaitlis ir uzminēts.</param>
        /// <returns></returns>
        bool IsNumberGuessed(int number);
        /// <summary>
        /// Metode ar kuru noskaidrot spēlētāja vārdu.
        /// </summary>
        /// <returns>Atgriež spēlētāja vārdu.</returns>
        string GetName();
    }
}
