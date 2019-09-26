using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Destinos");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ViewModels.LoginViewModel login)
        {

            if(login.UserName=="thiago" && login.Password == "abc123")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, login.UserName));

                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = login.IsPersistent });

                return RedirectToAction("Index", "Destinos");
            }


            return View();
        }
    }
}