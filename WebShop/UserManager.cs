using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class UserManager
    {
        private int currentId;
        //static nosaka, ka sis mainigais nav saistits ne ar vienu objektu. Veidojot jaunu user manager netiks katru reizi taisits jauns saraksts pari ieprieksejam
        private static List<User> Users = new List<User>();  


        public UserManager()
        {
            currentId = 100;
        }

        public User GetByEmailAndPassword(string email, string password) //compare to existing user
        {
            User user = Users.Find(u => u.Email == email && u.Password == password); //search in users list by 2 criteria
            return user;
        }
        public User Create(User user)
        {
            user.Id = currentId;
            Users.Add(user);
            currentId++;
            return user;
        }
        public User GetByEmail(string email)
        {
            User user = Users.Find(u => u.Email == email); //search in users list
            return user;
        }
        public void Delete(int id)
        {
            Users.Remove(Users.Find(u => u.Id == id));
        }
        public User Update(User user) //procedures with void. Method/function the same
        {
            User updatedUser = Users.Find(u => u.Id == user.Id);
            updatedUser = user;
            return updatedUser;
        }

        public void Seed()
        {
            Users.Add(new User()
            {
                Id = 1, 
                Email = "d@l.lv", 
                Password = "1234"
            });
            
            Users.Add(new User()
            {
                Id = 2,
                Email = "e@l.lv",
                Password = "4321"
            });
        }
    }
}
