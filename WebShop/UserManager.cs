using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebShop
{
    public class UserManager : BaseManager<User>
    {
        //static nosaka, ka sis mainigais nav saistits ne ar vienu objektu. Veidojot jaunu user manager netiks katru reizi taisits jauns saraksts pari ieprieksejam

        public UserManager(WebShopDB db)
            :base(db)
        {

        }

        protected override DbSet<User> Table
        {
            get
            {
                return _db.Users;
            }
        }

        public User GetByEmailAndPassword(string email, string password) //compare to existing user
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password); //search in users list by 2 criteria
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = _db.Users.FirstOrDefault(u => u.Email == email); //search in users list
            return user;
        }

        public void Seed()
        {
        }
    }
}
