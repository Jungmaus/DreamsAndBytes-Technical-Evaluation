using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Extensions.Security;
using DreamsAndBytes.Security.Abstract;
using DreamsAndBytes.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DreamsAndBytes.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IHash _hash;
        private readonly ICrypto _crypto;

        public LoginController(IUserService userService, IHash hash, ICrypto crypto)
        {
            this._userService = userService;
            this._hash = hash;
            this._crypto = crypto;
        }   

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                model.Username = _crypto.Encrypt(model.Username.ClearData(DataType.Text));
                model.Password = _hash.Hash(model.Password.ClearData(DataType.Password));

                var user = _userService.Get(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
                if (user is null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya Şifre yanlış.");
                }
                else
                {
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())
                        };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Product");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}