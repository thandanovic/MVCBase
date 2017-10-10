﻿using MVCBase.Common;
using MVCBase.Entities;
using MVCBase.Manager;
using MVCBase.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MVCBase.Helpers
{
    public class AuthHelper
    {
        private PasswordHasher passwordHasher;

        private PasswordHasher PasswordHasher
        {
            get { return passwordHasher ?? (passwordHasher = new PasswordHasher()); }
        }

        private UserRoleManager userRoleManager;

        private UserRoleManager UserRoleManager
        {
            get { return userRoleManager ?? (userRoleManager = new UserRoleManager()); }
        }

        private UserManager userManager;

        private UserManager UserManager
        {
            get { return userManager ?? (userManager = new UserManager()); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public bool SignIn(LoginViewModel userModel)
        {
            // Get user
            User user = this.TryToLogin(userModel);
            if (user == null)
                return false;

            List<Claim> userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.Name, user.Email));
            //userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId));

            //// Get roles
            IEnumerable<UserRole> roles = null;// UserRoleManager.Find(r => r.UserId == user.UserId);
            //roles = roles == null ? roles : roles.Where(x => x.UserId == user.UserId).ToList();

            // Uncomment this when roles are provided
            userClaims.Add(new Claim(ClaimTypes.Role, "user"));
            if (roles != null)
                roles.ToList().ForEach(r => userClaims.Add(new Claim(ClaimTypes.Role, r.Role.Name)));

            ClaimsIdentity userClaimIdentity = new ClaimsIdentity(userClaims, DefaultAuthenticationTypes.ApplicationCookie);

            this.AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                IsPersistent = userModel.RememberMe,
                ExpiresUtc = DateTime.UtcNow.AddDays(1)
            }, userClaimIdentity);

            return true;
        }

        public void SignOut()
        {
            this.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private User TryToLogin(LoginViewModel model)
        {

            // Get all users from DB
            IEnumerable<User> users = UserManager.Find(u => u.Email == model.Email);

            if (users == null || users.Count() == 0)
            {
                model.AlertMessage = "User not found! Try with different email and password!";
                return null;
            }
            
            // Get specific user
            User user = users.FirstOrDefault(x => x.Email == model.Email); 
            

            // If user don't exist return null
            if (user == null)
            {
                model.AlertMessage = "User not found! Try with different email and password!";
                return null;
            }
              

            // Verify users password and return user if password matches, otherwise retun null
            if (PasswordHasher.VerifyHashedPassword(user.Pass, model.Password) == PasswordVerificationResult.Success)
            {
                return user;
            }
            else
            {
                model.AlertMessage = "Password incorect. Try again.";
                return null;
            }
           

        }
    }
}