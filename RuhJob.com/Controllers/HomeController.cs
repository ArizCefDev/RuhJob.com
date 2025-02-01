using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RuhJob.com.DataAccess.Context;
using RuhJob.com.Models;

namespace RuhJob.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.c = _db.Categories.ToList();

            var values = _db.Jobs.ToList();
            return View(values);
        }

        public IActionResult Vacancy()
        {
            var values = _db.Jobs.ToList();
            return View(values);
        }

        public IActionResult Category()
        {
            var values = _db.Categories.ToList();
            return View(values);
        }

        public IActionResult Detail(int id)
        {
            if (id != null)
            {
                var values = _db.Jobs.Find(id);
                return View(values);
            }
            else
            {
                return Content("Bu elan movcud deyil");
            }

        }
    }
}
