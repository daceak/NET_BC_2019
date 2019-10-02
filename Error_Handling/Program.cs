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
            //izsaukt funkciju no klases
            /*UsersList newList = new UsersList();  
            newList.Add();*/

            UsersList users = new UsersList();
            while(true)
            {
            Console.WriteLine("Add new user? y/n");
            char proceed = char.Parse(Console.ReadLine());
            if (proceed == 'y')  //char liek ''   string ""
            {
             string fullName = GetName("Enter full name: ");
             UserProfile.Genders gender = GetGender("Enter gender: ");
             DateTime birthday = GetBirthday("Enter birthday: ");

            /*Console.WriteLine("Enter gender Male/Female: ");
                    string input = Console.ReadLine()
            UserProfile.Genders gender = Enum.TryParse(Console.ReadLine());*/

            users.Add(fullName, gender, birthday);

            }
            else
                break;
            }

            Console.Read();
        }


        public static UserProfile.Genders GetGender(string q)
        {
            Console.WriteLine(q);
            string input = Console.ReadLine();
            if(Enum.TryParse(input, out UserProfile.Genders gender))
            {
                return gender;
            }

            else
            {
                return GetGender(q);
            }
        }
        public static DateTime GetBirthday(string q)   //static var izsaukt bez klases instances 
        {
            Console.WriteLine(q);
            string input = Console.ReadLine();
            try
            {
                 DateTime birthday = (DateTime.Parse(input));
                
                    return birthday;

                
            }
            catch(Exception)   //vajag taisit individualos exceptions lai paraditu konkretu pazinojumu, piem., ja datums nepareizi tad zinu ""nepareizs formats"
            {
                return GetBirthday(q);
            }
        }


        public static string GetName(string q)
        {
            Console.WriteLine(q);
            string fullName = Console.ReadLine();

            if (fullName.Length <= 20)
            {
                return fullName;
            }


            else
            {
                Console.WriteLine("Name too long!");
                return GetName(q);
            }
        }

    }
}
