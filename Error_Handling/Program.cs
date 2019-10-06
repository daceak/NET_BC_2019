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
                    UserProfile.Genders gender = GetGender("Enter gender (Female: 0, Male: 1): ");
                    DateTime birthday = GetBirthday("Enter birthday: ");

                    users.Add(fullName, gender, birthday);
                }
                else
                {
                    users.Display();
                    break;
                }
            }
            Console.Read();

        }


        public static UserProfile.Genders GetGender(string q)
        {
            Console.WriteLine(q);
            string input = Console.ReadLine().ToLower();
            if(Enum.TryParse(input, out UserProfile.Genders gender))
            {
                return gender;
            }

            else
            {
                Console.WriteLine("Not valid input!");
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
            catch(Exception)
            {
                Console.WriteLine("Wrong input");
                return GetBirthday(q);
            }
        }


        public static string GetName(string q)
        {
            Console.WriteLine(q);
            string fullName = Console.ReadLine();
            fullName = fullName.Trim();

            if (!String.IsNullOrEmpty(fullName))    
            {
                return fullName;
            }


            else
            {
                Console.WriteLine("Empty text!");
                return GetName(q);
            }
        }

    }
}
