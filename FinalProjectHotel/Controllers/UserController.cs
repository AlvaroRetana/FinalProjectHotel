using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FinalProjectHotel.Models;

namespace FinalProjectHotel.Controllers
{
    public class UserController : Controller
    {

        Entities db = new Entities();

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult SaveData(Usuario_Admin model)
        {
            db.Usuario_Admin.Add(model);
            db.SaveChanges();
            return Json("Registration Successfull", JsonRequestBehavior.AllowGet);
        }

    }
}