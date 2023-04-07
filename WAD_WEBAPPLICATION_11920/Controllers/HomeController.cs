using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_WEBAPPLICATION_11920.DATA_ACCESS;

namespace WAD_WEBAPPLICATION_11920.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks();

            //Get users list
            var userRepository = new UserRepository();
            var users = userRepository.GetUsers();
       


            ViewBag.bookList = books;
            ViewBag.userList = users;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}