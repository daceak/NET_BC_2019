using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Handling
{
    class UserProfile
    {
        public string FullName;
        public char Gender;
        public DateTime Birthday;

        public UserProfile(string fullName, char gender, DateTime birthday)
        {
            FullName = fullName;
            Gender = gender;
            Birthday = birthday;
        }

        public int Age(DateTime birthday)
        {
            int yearNow = DateTime.Today.Year;
            int birthYear = birthday.Year;
            int age = yearNow - birthYear;
            return age;
        }
    }
}
