
using Electronic_Library1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Electronic_Library.Controllers
{
    public class EmployeeController : Controller
    {
        private LibraryContext context;
        public EmployeeController(LibraryContext lib)
        { context = lib; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            var books = context.Books.Include(b => b.Employee).OrderBy(b => b.Author).ToList();
             

                return View(books);
            
            
        }
        [HttpPost]
        public IActionResult Search(string k)
        {
            var books = context.Books.Where(b => b.Title.Contains(k)).Include(b => b.Employee).OrderBy(b => b.Author).ToList();
            
                return View(books);
            




        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("eid") == null)
            { return View(); }
            else
            { return View("Details"); }

        }
        [HttpPost]
        public IActionResult Login( string eid,string epass)
        {
            Employee e = context.Employees.Where(c => c.Name==eid && c.Password==epass).FirstOrDefault();
            if (e != null)
            {
                HttpContext.Session.SetString("eid", eid);
                return View("Details");
            }
            else
            {
                return RedirectToAction("Login", "Employee");
            }

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.em = context.Employees.OrderBy(c => c.Name).ToList();
            
                return View();
            

        }
        [HttpPost]
        public IActionResult Add(Book B)
        {
            context.Books.Add(B);
            context.SaveChanges();
            return RedirectToAction("Search");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var del = context.Books.Find(id);
            return View(del);
        }

        [HttpPost]
        public IActionResult Delete(Book m)
        {

            context.Books.Remove(m);
            context.SaveChanges();
            return RedirectToAction("Search", "Employee");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}

