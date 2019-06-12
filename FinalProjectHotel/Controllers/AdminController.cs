using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using FinalProjectHotel.Models;
using FinalProjectHotel.Models.Account;

namespace FinalProjectHotel.Controllers
{

    public class AdminController : Controller
    {

        Entities db = new Entities();
        // View Consecutivo
        public ActionResult Consecutive()
        {
            return View();
        }

        // View Lista Consecutivos
        public ActionResult ConsecutiveList()
        {
            return View();
        }

        // View Precios
        public ActionResult Precios()
        {
            return View();
        }

        // View HabitacionesListas
        public ActionResult HabitacionesListas()
        {
            return View();
        }

        // View Habitaciones
        public ActionResult Habitaciones()
        {
            return View();
        }

        // View ClientesActivos
        public ActionResult ClientesActivos()
        {
            return View();
        }


        // Inserts
        [HttpPost]
        public ActionResult SaveConsecutive(BLL.Consecutivo consecutive)
        {

            consecutive.agregar_consecutivo();
            
            return Content("Success!");
        }

        [HttpPost]
        public ActionResult SaveRoom(HttpPostedFileBase image, BLL.Habitacion habitacion)
        {

            var img = Path.GetFileName(image.FileName);

            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/"),
                                            System.IO.Path.GetFileName(image.FileName));
                    image.SaveAs(path);


                }

                habitacion.agregar_habitacion();

            
            }
            return Content("Success!");
        }

        [HttpPost]
        public ActionResult SavePrice(BLL.Precio precio)
        {

            precio.agregar_precio();

            return Content("Success!");
        }


    }
}