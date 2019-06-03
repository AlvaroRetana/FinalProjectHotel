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

        public JsonResult CheckValidUSer(Usuario_Admin model)
        {
            string result = "Fail";
            var DataItem = db.Usuario_Admin.Where(x => x.Username == model.Username && x.Password == model.Password).SingleOrDefault();
            if (DataItem != null)
            {
                Session["UserID"] = DataItem.ID.ToString();
                Session["UserName"] = DataItem.Username.ToString();
                result = "Success";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AfterLogin()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}