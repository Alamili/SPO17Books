using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPO17Books.Data.Entities;
using SPO17Books.Models;
using SPO17Books.Services;

namespace SPO17Books.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ISqlService _db { get; set; }
        public AdminController(ISqlService db)
        {
            _db = db;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var users = _db.Get<ApplicationUser>()
                .Select(au => new AppUser {
                    Email = au.Email,
                    UserId = au.Id
                });
            return View(users);
        }

        public IActionResult Books(string userId)
        {
            var books = _db.Get<Book>().Where(b => b.UserId.Equals(userId));
            return View(books);
        }
    }
}