using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdApp.Models
{
    public class SignUpModel : UserModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public override string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))] //izmanto nameof lai rezultats butu ""
        public string PasswordRepeat { get; set; }
    }
}
