using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Handling
{
    class UserProfile
    {
        public enum Genders
        {
            Female,
            Male
        }
        public string FullName { get; set; }
        public Genders Gender { get; set; }
        public DateTime Birthday { get; set; }
        //public char Gender;

        public UserProfile()
        {

        }
        public UserProfile(string fullName, Genders gender, DateTime birthday)
        {
            FullName = fullName;
            Gender = gender;
            Birthday = birthday;
        }

        public int Age()
        {
            int yearNow = DateTime.Today.Year;
            int birthYear = Birthday.Year;
            int age = yearNow - birthYear;

            if(Birthday.Month > DateTime.Today.Month)
            {
                age -= 1;
            }
            return age;
        }
    }
}
