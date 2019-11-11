using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class User : BaseData
    {
        public string Email { get; set; }
        public string Password { get; set; } // define values in {}. e.g. Add(New User(){1, "2@1.lv", "123"})


    }
}
