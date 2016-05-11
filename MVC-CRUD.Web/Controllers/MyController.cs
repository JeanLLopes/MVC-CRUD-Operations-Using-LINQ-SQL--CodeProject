using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Web.Data;
using MVC_CRUD.Web.Repository;

namespace MVC_CRUD.Web.Controllers
{
    public class MyController : Controller
    {
        #region Private member variables...
        private readonly IUserRepository _userRepository = new UserRepository();
        #endregion



        // GET: My
        public ActionResult Index()
        {

            var dbConnection = new MVCDBContext();
            var userList = from user in _userRepository.GetUsers() select user;
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
            var userDetails =  _userRepository.GetUserByID(id);
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
        public ActionResult Create(Models.User user)
        {
            try
            {

                var userData = new User();

                if (user != null)
                {
                    userData.UserId = user.UserId;
                    userData.Address = user.Address;
                    userData.Company = user.Company;
                    userData.Designation = user.Designation;
                    userData.Email = user.Email;
                    userData.FirstName = user.FirstName;
                    userData.LastName = user.LastName;
                    userData.PhoneNo = user.PhoneNo;
                }

                _userRepository.InsertUser(userData);
                _userRepository.Save();


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
            var userDetails = _userRepository.GetUserByID(id);
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
                var user = _userRepository.GetUserByID(id);
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


                    _userRepository.UpdateUser(user);
                    _userRepository.Save();
                }

                

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
            var userDetails = _userRepository.GetUserByID(id);
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
        public ActionResult Delete(int id, User user)
        {
            try
            {
                var userData = _userRepository.GetUserByID(id);
                if (userData != null)
                {
                    _userRepository.DeleteUser(id);
                    _userRepository.Save();
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
