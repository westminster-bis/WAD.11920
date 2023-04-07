using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAD_WEBAPPLICATION_11920.DATA_ACCESS;
using WAD_WEBAPPLICATION_11920.Models;

namespace WAD_WEBAPPLICATION_11920.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var repository = new UserRepository();
            var users = repository.GetUsers();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var repo = new UserRepository();
            var user = repo.GetById(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            var repository = new UserRepository();

            try
            {
                // TODO: Add insert logic here
                repository.CreateUser(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var repository = new UserRepository();
            var user = repository.GetById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var repository = new UserRepository();
            try
            {
                // TODO: Add update logic here
                repository.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var repository = new UserRepository();
            var user = repository.GetById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(User user)
        {
            var repository = new UserRepository();
            try
            {
                // TODO: Add delete logic here
                repository.DeleteUser(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
