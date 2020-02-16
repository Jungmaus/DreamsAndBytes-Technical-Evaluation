using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.API.Models.User
{
    public class AuthenticateResponseModel
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
