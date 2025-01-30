using Microsoft.AspNetCore.Mvc;
using RuhJob.com.DataAccess.Context;

namespace RuhJob.com.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;

        public AboutController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var values=_db.Abouts.ToList();
            return View(values);
        }
    }
}
