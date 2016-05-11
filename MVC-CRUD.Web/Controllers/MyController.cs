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

            var dbConnection = new MVCEntities();
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
        public ActionResult Details(int? id)
        {
            var dbContext = new MVCEntities();
            var userDetails = dbContext.Users.FirstOrDefault(x => x.UserId == id);
            var user = new Models.User();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.Address = userDetails.Address;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
                user.Email = userDetails.Email;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.PhoneNo = userDetails.PhoneNo;

            }


            return View(user);
        }

        // GET: My/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: My/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                var dbContext = new MVCEntities();
                dbContext.Users.Add(user);
                dbContext.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: My/Edit/5
        public ActionResult Edit(int? id)
        {
            var dbContext = new MVCEntities();
            var userDetails = dbContext.Users.FirstOrDefault(x => x.UserId == id);
            var user = new Models.User();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.Address = userDetails.Address;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
                user.Email = userDetails.Email;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.PhoneNo = userDetails.PhoneNo;
            }


            return View(user);
        }

        // POST: My/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User userDetails)
        {
            try
            {
                var dbContext = new MVCEntities();
                var user = dbContext.Users.FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    user.UserId = userDetails.UserId;
                    user.Address = userDetails.Address;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                    user.Email = userDetails.Email;
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.PhoneNo = userDetails.PhoneNo;


                    dbContext.SaveChanges();
                }

                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: My/Delete/5
        public ActionResult Delete(int? id)
        {
            var dbContext = new MVCEntities();
            var userDetails = dbContext.Users.FirstOrDefault(x => x.UserId == id);
            var user = new Models.User();
            if (userDetails != null)
            {
                user.UserId = userDetails.UserId;
                user.Address = userDetails.Address;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
                user.Email = userDetails.Email;
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.PhoneNo = userDetails.PhoneNo;
            }


            return View(user);

        }

        // POST: My/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, User user)
        {
            try
            {
                var dbContext = new MVCEntities();
                var userData = dbContext.Users.FirstOrDefault(x => x.UserId == id);
                if (userData != null)
                {
                    dbContext.Users.Remove(userData);
                    dbContext.SaveChanges(); 
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
