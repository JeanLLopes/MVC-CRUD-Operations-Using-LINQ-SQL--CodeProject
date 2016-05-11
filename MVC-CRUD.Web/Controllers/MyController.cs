using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Web.Data;

namespace MVC_CRUD.Web.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {

            var dbConnection = new MyDBDataContext();
            var userList = from user in dbConnection.Users select user;
            var users = new List<Models.User>();

            if (userList.Any())
            {
                foreach (var user in userList)
                {
                    users.Add(new Models.User{UserId = user.UserId,Address = user.Address,Company = user.Company,Designation = user.Designation,Email = user.Email,FirstName = user.FirstName,LastName = user.LastName,PhoneNo = user.PhoneNo});
                }
            }

            return View(users);
        }

        // GET: My/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: My/Create
        public ActionResult Create(User user)
        {

            var dbContext = new MyDBDataContext();
            dbContext.Users.InsertOnSubmit(user);
            dbContext.SubmitChanges();


            return RedirectToAction("Index");
        }

        // POST: My/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: My/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: My/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: My/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: My/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
