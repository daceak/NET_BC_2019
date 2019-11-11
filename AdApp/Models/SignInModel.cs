using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdApp.Models
{
    public class SignInModel : UserModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public override string Password { get; set; }
    }
}
