using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.UI.Models
{
    public class LoginVM
    {
        [MaxLength(25,ErrorMessage = "Kullanıcı adı en fazla 25 karakter olabilir."),Required(ErrorMessage = "Kullanıcı adı zorunludur."),MinLength(5, ErrorMessage = "Kullanıcı adı en az 5 karakter olabilir."),DataType(DataType.Text)]
        public string Username { get; set; }

        [MaxLength(25, ErrorMessage = "Şifre en fazla 25 karakter olabilir."), Required(ErrorMessage = "Şifre zorunludur."), MinLength(5, ErrorMessage = "Şifre en az 5 karakter olabilir."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
