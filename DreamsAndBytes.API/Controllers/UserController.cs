using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DreamsAndBytes.API.Models;
using DreamsAndBytes.API.Models.User;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Extensions.Security;
using DreamsAndBytes.Security.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DreamsAndBytes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IHash _hash;
        private readonly ICrypto _crypto;

        public UserController(IConfiguration configuration, IUserService userService, IHash hash, ICrypto crypto)
        {
            this._configuration = configuration;
            this._userService = userService;
            this._hash = hash;
            this._crypto = crypto;
        }

        [HttpPost]
        [Route("Authenticate")]
        public AuthenticateResponseModel Authenticate([FromBody]AuthenticateRequestModel model)
        {
            AuthenticateResponseModel responseModel = new AuthenticateResponseModel();
            if (ModelState.IsValid)
            {
                model.Username = _crypto.Encrypt(model.Username.ClearData(DataType.Text));
                model.Password = _hash.Hash(model.Password.ClearData(DataType.Password));

                var user = _userService.Get(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
                if(user is null)
                {
                    responseModel.IsSuccess = false;
                    responseModel.ErrorMessage = "Kullanıcı adı veya Şifre yanlış.";
                }else
                {
                    responseModel.IsSuccess = true;
                    responseModel.Token = GenerateJWT(user.ID, _crypto.Decrypt(user.Username));
                }
            }else
            {
                responseModel.IsSuccess = false;
                responseModel.ErrorMessage = "Invalid input";
            }
            return responseModel;
        }

        private string GenerateJWT(int userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}