using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Handling
{
    class UsersList
    {
        public List<UserProfile> users = new List<UserProfile>();

        public void Add(string fullName, UserProfile.Genders gender, DateTime birthday)
        {
            //vards max 20 simboli
            if(fullName.Length > 20)
            {
                throw new UsersExceptions("Name too long!");
            }           
            //datums nav nakotne
            if(birthday > DateTime.Today)
            {
                throw new UsersExceptions("Date in the future!");
            }
            //datums nav mazaks par 01.01.1800
            if (birthday < new DateTime(1980, 01, 01))
            {
                throw new UsersExceptions("Date too far!");
            }

            UserProfile user = new UserProfile(fullName, gender, birthday);
            Console.WriteLine(user.Age());
            users.Add(user);
        }
        public void Display()
        {
            foreach(var user in users)
            {
                Console.WriteLine("{0}, gender: {1}, birthday: {2}", user.FullName, user.Gender, user.Birthday);
            }
        }
    }
}
