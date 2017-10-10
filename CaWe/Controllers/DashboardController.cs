using MVCBase.Attributes;
using MVCBase.DB;
using MVCBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBase.Controllers
{
    public class DashboardController : BaseController
    {
        private Repository db = new Repository();
        // GET: Dashboard
        /// <summary>
        /// Test only
        /// </summary>
        /// <returns></returns>
        [AuthorizeRoles("user")]
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.Locations = db.Locations.ToList();
            model.Orders = db.Orders.Include("UserInfo").Include("Location").ToList();
            model.Clients = db.UserInfos.Include("User").Where(x=>x.Email.StartsWith("user")).ToList();

            return View(model);
        }

        // GET: Dashboard-Template
        public ActionResult Template()
        {
            return View();
        }
    }
}