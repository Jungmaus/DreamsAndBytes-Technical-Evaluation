using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DreamsAndBytes.UI.Controllers
{
    public class BaseController : Controller
    {
        public string GetClaimValue(string claimType) => HttpContext.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        
    }
}