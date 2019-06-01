using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AuthenticationController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth(AuthModel model)
        {
            if (ModelState.IsValid)
            {
                //hardcoded users
                if (model.User.ToLower() == "user" && model.Password.ToLower() == "123")
                {
                    await SetClaims("User", 1);
                    return RedirectToAction("Index", "home");
                }

                else if (model.User.ToLower() == "admin" && model.Password.ToLower() == "123")
                {
                    await SetClaims("Admin", 2);
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    ModelState.AddModelError("erros", "User or password invalid");
                    return View();
                }
            }
            else
                return View(model);
        }

        private async Task SetClaims(string userName, int id)
        {
            var claims = new List<Claim>
                    {
                        new Claim("Email", userName),
                        new Claim("FullName",userName),
                        new Claim("UserID", id.ToString()),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}