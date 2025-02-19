using Microsoft.AspNetCore.Mvc;
using RuhJob.com.DataAccess.Context;
using RuhJob.com.DataAccess.Entity;

namespace RuhJob.com.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() 
        {
            var values = _db.Abouts.ToList();
            return View(values);
        }

        public IActionResult AboutDelete(int id)
        {
            var ent = _db.Abouts.Find(id);
            _db.Remove(ent);
            _db.SaveChanges();
            return RedirectToAction("About");
        }

        public IActionResult Categoy()
        {
            var values = _db.Categories.ToList();
            return View(values);
        }

        public IActionResult CategoryDelete(int id)
        {
            var ent = _db.Categories.Find(id);
            _db.Remove(ent);
            _db.SaveChanges();
            return RedirectToAction("Categoy");
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            _db.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Categoy");
        }


        public IActionResult Contact()
        {
            var values=_db.Contacts.ToList();
            return View(values);
        }

        public IActionResult ContactDelete(int id) { 
        
            var ent = _db.Contacts.Find(id);    
            _db.Remove(ent);
            _db.SaveChanges();
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public IActionResult ContactAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact p)
        {
            _db.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Contact");
        }


        public IActionResult Jobs() 
        {
            var values = _db.Jobs.ToList();
            return View(values);
        }

        public IActionResult JobDelete(int id)
        {

            var ent = _db.Jobs.Find(id);
            _db.Remove(ent);
            _db.SaveChanges();
            return RedirectToAction("Jobs");
        }


        [HttpGet]
        public IActionResult JobUpdate(int id)
        {
            ViewBag.list = _db.Categories.ToList();
            var values = _db.Jobs.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult JobUpdate(Job p)
        {
            ViewBag.list = _db.Categories.ToList();
            _db.Update(p);
            _db.SaveChanges();
            return RedirectToAction("Jobs");
        }


    }
}
