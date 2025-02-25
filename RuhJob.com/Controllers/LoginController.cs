using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RuhJob.com.DataAccess.Context;
using RuhJob.com.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace RuhJob.com.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;
        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User p)
        {
            var admin = Login(p);
                Authenticate(admin);
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User p)
        {
            p.Roleid = 2;
            _db.Add(p);
            _db.SaveChanges();
            return RedirectToAction("SignIn");
        }

        //Cookie
        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public User Login(User model)
        {
            var res = _db.Users.Where(x => x.UserName == model.UserName).Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();
                var pass = model.Password;

                if (pass == user.Password)
                {
                    var x = res.First();
                    return x;
                }

            }
            return model;
        }

    }
}
