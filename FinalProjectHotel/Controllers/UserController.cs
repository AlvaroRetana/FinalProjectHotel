using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace FinalProjectHotel.Controllers
{
    public class UserController : Controller
    {

        SqlConnection conexion = new SqlConnection("Data Source=serviciosweb.database.windows.net;Initial Catalog=Vuelos;Persist Security Info=True;User ID=vuelosadmin;Password=12458+25Ddfsd$3Dsx+"); //catalog= bd_demo

        // GET: User
        public ActionResult Login()
        {
            return View();
        }

    }
}