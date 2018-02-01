using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Domain.Interfaces;
using TaskManagementSystem.Repository.EntityFramework.Repositories;

namespace TaskManagementSystem.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository = new UserRepository();

        public ActionResult TasksPerUserReport()
        {
            var dbUsers = _userRepository.GetAll();
            Dictionary<string, int> report = new Dictionary<string, int>();
            foreach (var user in dbUsers)
            {
                var tempUser = user.Username;
                var userTasks = user.Tasks.Count;
                report.Add(tempUser,userTasks);
            }
            return View(report);
        }
        public ActionResult ActivateUser(int id)
        {
            if (_userRepository.ActivateUser(id))
            {
                return RedirectToAction("ListAll");
            }
            return View();
        }
        public ActionResult DeactivateUser(int id)
        {
            if (_userRepository.DeactivateUser(id))
            {
                return RedirectToAction("ListAll");
            }
            return View();
        }

        public ActionResult ListAll()
        {
            var users = _userRepository.GetAll().Where(x => x.IsActivated == true).ToList();

            return View(users);
        }

        public ActionResult PendingUsers()
        {
            var pendingUsers = _userRepository.GetAll().Where(x => x.IsActivated == false);

            return View(pendingUsers);
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Create(user))
                    return RedirectToAction("ListAll");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            if (_userRepository.Delete(user.ID))
                return RedirectToAction("ListAll");

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Update(user))
                {
                    return RedirectToAction("ListAll");
                }
            }

            return View();
        }

    }
}