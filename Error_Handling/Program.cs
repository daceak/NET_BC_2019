using ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Handling
{
    class Program
    {
        static void Main(string[] args) //Start the right project->(solution explorer)->labais taustins uz solution nosaukuma un set as StartUp project
        {
            try
            {
                //izsaukt funkciju no klases
                /*UsersList newList = new UsersList();  
                newList.Add();*/

                UsersList users = new UsersList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Add new user? y/n");
                        char proceed = char.Parse(Console.ReadLine());
                        if (proceed == 'y')  //char liek ''   string ""
                        {
                            
                            /*lai lietotu funkcijas no klases ConsoleHelpers (pasu veidotas)- 
                            labais taustins uz solution, reference- izvelas Console Helpers. Tad pirms funkcijas ieraksta klases nosaukumu (ConsoleInput)
                            pie kludas pazinojuma izvelas using ConsoleHelpers (biblioteka, kas izveidota).*/
                             
                            string fullName = ConsoleInput.GetText("Enter full name: ");    
                            UserProfile.Genders gender = GetGender("Enter gender (Female, Male): ");
                            DateTime birthday = ConsoleInput.GetDate("Enter birthday (year-month-day): ");

                            users.Add(fullName, gender, birthday);
                        }
                        else
                        {
                            users.Display();
                            break;
                        }
                    }
                    catch (UsersExceptions msg)  //mainiga nosaukums var but jebkads
                    {
                        Console.WriteLine($"{msg.Message}. Last user not added, please try again!");     //Message iebuvets Exceptions klase
                    }
                }
            }
            catch(Exception msg)
            {
                Console.WriteLine($"Unexpected error! ({msg.Message})");
            }
            Console.Read();
        }


        public static UserProfile.Genders GetGender(string q)
        {
            Console.WriteLine(q);
            string input = Console.ReadLine().ToLower();
            if(Enum.TryParse(input, true, out UserProfile.Genders gender))  //true- ja patiess, tad return jauno vertibu
            {
                return gender;
            }

            else
            {
                Console.WriteLine("Not valid input!");
                return GetGender(q);
            }
        }


    }
}
