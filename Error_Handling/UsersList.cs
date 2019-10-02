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
            //parbaudes

            //vards max 20 simboli

            //datums nav nakotne

            //datums nav mazaks par 01.01.1800

            UserProfile user = new UserProfile(fullName, gender, birthday);
            users.Add(user);
            user.Age();
        }
    }
}
