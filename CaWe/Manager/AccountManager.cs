using MVCBase.Entities;
using MVCBase.Manager;
using MVCBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBase.UI.Manager
{
    public class AccountManager
    {

        private UserManager userManager;

        private UserManager UserManager
        {
            get { return userManager ?? (userManager = new UserManager()); }
        }

        public UserViewModel GetModel(string username)
        {
            UserViewModel model = new UserViewModel();
            model.UserInfo = UserManager.Find(u => u.Email == username).FirstOrDefault();
            return model;
        }
    }
}