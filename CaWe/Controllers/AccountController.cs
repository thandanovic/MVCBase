using MVCBase.Attributes;
using MVCBase.Entities;
using MVCBase.Manager;
using MVCBase.Models;
using MVCBase.UI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBase.Controllers
{
    public class AccountController : BaseController
    {

        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult Index()
        {
            UserViewModel model = AccountManager.GetModel(User.Identity.Name);
            
            return View(model);
        }

        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult Edit()
        {
            UserViewModel model = AccountManager.GetModel(User.Identity.Name);
            return View(model);
        }

        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult SaveUserInfo(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            UserManager userManager = new UserManager();
            User updateUser = userManager.Find(u => u.Email == User.Identity.Name).FirstOrDefault();
            updateUser.FirstName = model.UserInfo.FirstName;
            updateUser.LastName = model.UserInfo.LastName;
            userManager.Update(updateUser);
            

            return View("Index");
        }


        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult ChangePassword(UserViewModel model)
        {
            return View();
        }
    }
}