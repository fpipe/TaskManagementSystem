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
    public class AccountController : Controller
    {
        IUserRepository _userRepository = new UserRepository();
        public User ActiveUser = null;

        public JsonResult LoginUsername(string username)
        {
            ActiveUser = _userRepository.ValidateUsername(username);
            if (ActiveUser != null)
            {
                return Json(ActiveUser.ID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LoginPassword(string password)
        {
            ActiveUser = _userRepository.ValidatePassword(password);
            if (ActiveUser != null)
            {
                if(ActiveUser.Type == 0)
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                if(ActiveUser.Type == 1)
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(-1, JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}