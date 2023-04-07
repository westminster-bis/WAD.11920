using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_WEBAPPLICATION_11920.DATA_ACCESS;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var repository = new BookRepository();
            var books = repository.GetBooks();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var repository = new BookRepository();
            var book = repository.GetById(id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var repository = new UserRepository();
            var users = repository.GetUsers();
            ViewBag.usersList = users;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            var repository = new BookRepository();
            try
            {
                // TODO: Add insert logic here
                repository.Create(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new UserRepository();
            var users = repository.GetUsers();
            ViewBag.usersList = users;

            var bookRepository = new BookRepository();
            var book = bookRepository.GetById(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit( Book book)
        {
            var bookRepository = new BookRepository();


            try
            {
                // TODO: Add update logic here
                bookRepository.Update(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var bookRepository = new BookRepository();
            var book = bookRepository.GetById(id);
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            var bookRepository = new BookRepository();
            try
            {
                // TODO: Add delete logic here
                bookRepository.Delete(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
