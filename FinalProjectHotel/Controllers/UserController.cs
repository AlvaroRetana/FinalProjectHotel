using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FinalProjectHotel.Models;
using FinalProjectHotel.Models.Account;
using System.Configuration;
using System.IO;
using System.Linq.Dynamic;

namespace FinalProjectHotel.Controllers
{
    public class UserController : Controller
    {

        Entities db = new Entities();
        SqlConnection conexion = new SqlConnection("Data Source=h-mandiola.database.windows.net;Initial Catalog=h-mandiola;User ID=dream-team;Password=Ulacit2019."); //catalog= bd_demo
        public static string CurrentPassword = "", CurrenteUsername = "";

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CreateUser()
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

        public ActionResult AsignarRoles()
        {
            UserViewModel user = new UserViewModel();
            user.Usernames = PopulateUsernames();
            return View();
        }

        [HttpPost]
        public ActionResult AsignarRoles(UserViewModel user)
        {

            user.Usernames = PopulateUsernames();
            var selectedItem = user.Usernames.Find(p => p.Value == user.userId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Fruit: " + selectedItem.Text;
                ViewBag.Message += "\\nQuantity: " + user.username;
            }

            return View(user);
        }

        private static List<SelectListItem> PopulateUsernames()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string connectionString = "Data Source=h-mandiola.database.windows.net;Initial Catalog=h-mandiola;User ID=dream-team;Password=Ulacit2019.";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT Username, ID FROM Usuario_Admin", con))
            {

                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = sdr["Username"].ToString(),
                            Value = sdr["ID"].ToString()
                        });
                    }
                }
                con.Close();

            }

            return items;
        }

        public ActionResult UserStatus(int page =1, string sort ="Nombre", string sortdir ="asc",string search="")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetClientes(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<Cliente> GetClientes(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            using(Entities dc = new Entities())
            {
                var v = (from a in dc.Cliente
                         where
                                 a.Nombre.Contains(search) ||
                                 a.Apellido1.Contains(search) ||
                                 a.Apellido2.Contains(search) ||
                                 a.Correo.Contains(search) ||
                                  a.Activo.Contains(search) 
                         select a
                         );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                if(pageSize > 0)
                {
                    v = v.Skip(skip).Take(pageSize);
                }
                return v.ToList();

            }
        }
    }
}