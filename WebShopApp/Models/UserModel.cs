using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApp.Models
{
    public abstract class UserModel
    {
        public abstract string Email { get; set; }
        public abstract string Password { get; set; }

    }
}
