using Electronic_Library1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library1.Controllers
{
    public class CustomerController : Controller
    {
        private LibraryContext context;
        public CustomerController(LibraryContext lib)
        { context = lib; }

        public IActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("cid") == null)
            { return View(); }
            else
            { return View("Details"); }

        }
        [HttpPost]
        public IActionResult Login(string cid, string cpass)
        {
            Customer c = context.Customers.Where(c => c.Name == cid && c.Password == cpass).FirstOrDefault();
            if (c != null)
            {
                HttpContext.Session.SetString("cid", cid);
                return View("Details");
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }

        }
        public IActionResult Details()
        {
            if (HttpContext.Session.GetString("cid") == null)
            {
                return RedirectToAction("Login");
            }
            else
            {

                string? cid = HttpContext.Session.GetString("cid");
                Customer c = context.Customers.Where(e=>e.Name== cid).FirstOrDefault();
                if (c != null)
                    return View(c);
                else
                    return View("Login");
            }

        }
        [HttpGet]
        public IActionResult Search()
        {
            var books = context.Books.Include(b => b.Employee).OrderBy(b => b.Author).ToList();
            return View(books);
        }
        [HttpPost]
        public IActionResult Search(string Skey)
        {
            var books = context.Books.Where(b => b.Title.Contains(Skey)).Include(b => b.Employee).OrderBy(b => b.Author).ToList();
            return View("Search", books);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("cid") == null)
                return RedirectToAction("Login");
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string newpass)
        {
            if (HttpContext.Session.GetString("cid") == null)
                return RedirectToAction("Login");
            string? cid = HttpContext.Session.GetString("cid");
            Customer c = context.Customers.Where(e => e.Name == cid).FirstOrDefault(); ;
            c.Password = newpass;
            context.Customers.Update(c);
            context.SaveChanges();
            return View("Details");
        }
        public IActionResult Upload()
        { 
          return View();
        }
    }
}


