using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SPO17Books.Data.Entities;
using SPO17Books.Models;
using SPO17Books.Services;

namespace SPO17Books.Controllers
{
    public class StoreController : Controller
    {
        private ISqlService _db { get; set; }
        private string _userId { get; set; }

        public StoreController(ISqlService db,
            IHttpContextAccessor httpContextAccessor, 
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            var user = httpContextAccessor.HttpContext.User;
            _userId = userManager.GetUserId(user);
        }

        public IActionResult Index()
        {
            var books = _db.Get<Book>().Where(b => b.UserId.Equals(_userId));

            return View(books);
        }

        public IActionResult Details(int bookId)
        {
            var book = _db.Get<Book>(bookId);

            if (book == null) return RedirectToAction("Index");

            return View(book);
        }

        public IActionResult Store()
        {
            var books = _db.Get<Book>()
                .Where(b => b.UserId == null || b.UserId.Equals(string.Empty));

            return View(books);
        }

        public IActionResult Buy(int bookId)
        {
            var book = _db.Get<Book>(bookId);
            book.UserId = _userId;
            _db.Update(book);
            return RedirectToAction("Store");
        }

        public IActionResult Return(int bookId)
        {
            var book = _db.Get<Book>(bookId);
            book.UserId = string.Empty;
            _db.Update(book);
            return RedirectToAction("Index");
        }
    }
}