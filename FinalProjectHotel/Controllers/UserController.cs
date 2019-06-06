using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FinalProjectHotel.Models;
using FinalProjectHotel.Models.Account;


namespace FinalProjectHotel.Controllers
{
    public class UserController : Controller
    {

        Entities db = new Entities();
        SqlConnection conexion = new SqlConnection("Data Source=h-mandiola.database.windows.net;Initial Catalog=h-mandiola;User ID=dream-team;Password=Ulacit2019."); //catalog= bd_demo
        public static string CurrentPassword = "", CurrenteUsername="";

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
                CurrentPassword = model.Password;
                CurrenteUsername = model.Username;
                Session["UserID"] = DataItem.ID.ToString();
                Session["UserName"] = DataItem.Username.ToString();
                result = "Success";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AfterLogin()
        {
            if (Session["UserID"] != null)
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
            CurrenteUsername = ""; CurrentPassword = "";
            return RedirectToAction("Login");
        }


        public ActionResult ChangePassword()
        {
            return View();
        }


        public ActionResult ChangePasswordUser(string Oldpassword, string Newpassword, string Confirmnewpassword)
        {
            string result = "";
            Usuario_Admin modelUser = new Usuario_Admin();

            if (Oldpassword == "" || Newpassword == "" || Confirmnewpassword == "")
            {
                result = "fail";
            }
            else
            {
                if (Oldpassword != CurrentPassword)
                {
                    result = "fail";
                }
                else
                {
                    if (Newpassword != Confirmnewpassword)
                    {
                        result = "fail";
                    }
                    else
                    {

                        SqlCommand com;

                        com = conexion.CreateCommand();

                        com.CommandText = "Execute ChangePassword @Username, @Password";
                        com.Parameters.Add("@Username", SqlDbType.VarChar).Value = CurrenteUsername;
                        com.Parameters.Add("@Password", SqlDbType.VarChar).Value = Newpassword;

                        conexion.Open();
                        com.ExecuteNonQuery();

                        conexion.Close();

                        CurrentPassword = Newpassword;
                        result = "Success";

                    }
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}