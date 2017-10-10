using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBase.Entities;
using MVCBase.Service;

namespace MVCBase.Controllers
{
    public class RoleController : BaseController
    {
        // GET: Role
        public ActionResult Index()
        {
            return View(CaWeService.Instance.GetAllRoles());
        }
    }
}
