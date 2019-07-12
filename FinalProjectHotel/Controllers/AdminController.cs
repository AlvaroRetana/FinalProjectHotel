using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL;
using FinalProjectHotel.Models;
using FinalProjectHotel.Models.Admin;
using Newtonsoft.Json;
using System.Diagnostics;


namespace FinalProjectHotel.Controllers
{

    public class AdminController : Controller
    {

        // View HabitacionesListas
        public ActionResult AbleRooms(BLL.Habitacion habitacion)
        {
            List<RoomModel> list = new List<RoomModel>();
            DataSet dataSet = new DataSet();
            dataSet = habitacion.lista_habitaciones();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new RoomModel
                {
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Numero = Convert.ToInt32(row["Numero"]),
                    Descripcion = row["Descripcion"].ToString(),
                    Imagen = row["Imagen"].ToString(),
                    Disponibilidad = row["Disponibilidad"].ToString(),
                    ID_Precio = row["ID_Precio"].ToString()

                });
            }
            return View(list);
        }

        // View ClientesActivos
        public ActionResult ActiveClients(BLL.Cliente cliente)
        {
            List<ClientModel> list = new List<ClientModel>();
            DataSet dataSet = new DataSet();
            dataSet = cliente.lista_clientes();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new ClientModel
                {

                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Apellido1 = row["Apellido1"].ToString(),
                    Apellido2 = row["Apellido2"].ToString(),
                    Correo = row["Correo"].ToString(),
                    Telefono = row["Telefono"].ToString(),
                    Activo = row["Activo"].ToString()

                });
            }
            return View(list);
        }

        // View Actividades
        public ActionResult ActivitiesList(BLL.Actividad actividad)
        {
            List<ActivityModel> list = new List<ActivityModel>();
            DataSet dataSet = new DataSet();
            dataSet = actividad.lista_actividad();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new ActivityModel
                {
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Imagen = row["Imagen"].ToString()

                });
            }
            return View(list);
        }

        // View Bitácora
        public ActionResult Binnacle(BLL.Bitacora bitacora)
        {
            List<BinnacleModel> list = new List<BinnacleModel>();
            DataSet dataSet = new DataSet();
            dataSet = bitacora.lista_bitacora();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new BinnacleModel
                {
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Usuario = row["Usuario"].ToString(),
                    Fecha_Hora = Convert.ToDateTime(row["Fecha_Hora"]),
                    Codigo_Registro = Convert.ToInt32(row["Codigo_registro"]),
                    Tipo = row["Tipo"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Detalle = row["Detalle"].ToString()


                });
            }
            return View(list);
        }

        // View Lista Consecutivos
        public ActionResult ConsecutiveList(BLL.Consecutivo consecutivo)
        {
            List<ConsecutiveModel> list = new List<ConsecutiveModel>();
            DataSet dataSet = new DataSet();
            dataSet = consecutivo.lista_consecutivos();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new ConsecutiveModel
                {
                    Codigo = Convert.ToInt32(row["Codigo"]),
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Prefijo = row["Prefijo"].ToString(),
                    Rango_Inicial = Convert.ToInt32(row["Rango_inicial"]),
                    Rango_Final = Convert.ToInt32(row["Rango_final"])
                });
            }
            return View(list);
        }

        // View Error
        public ActionResult Faults(BLL.Error error)
        {
            List<ErrorModel> list = new List<ErrorModel>();
            DataSet dataSet = new DataSet();
            dataSet = error.lista_errores();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new ErrorModel
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Numero = Convert.ToInt32(row["Numero"]),
                    Descripcion = row["Descripcion"].ToString(),
                    Fecha_Hora = Convert.ToDateTime(row["Fecha_Hora"])

                });
            }
            return View(list);
        }

        // View InsertActivity
        public ActionResult InsertActivityForm()
        {
            return View();
        }

        // View InsertConsecutiveForm
        [HttpGet]
        public ActionResult InsertConsecutiveForm()
        {

            return View();
        }

        // View InsertPricesForm
        public ActionResult InsertPricesForm()
        {
            return View();
        }

        // View InsertRoomsForm
        public ActionResult InsertRoomsForm()
        {
            return View();
        }

        // View PriceList
        public ActionResult PricesList(BLL.Precio precio)
        {
            List<PriceModel> list = new List<PriceModel>();
            DataSet dataSet = new DataSet();
            dataSet = precio.lista_precios();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new PriceModel
                {
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Tipo = row["Tipo"].ToString(),
                    Precio = row["Precio"].ToString()
                });
            }
            return View(list);
        }

        // View RoomsList
        public ActionResult RoomsList(BLL.Habitacion habitacion)
        {
            List<RoomModel> list = new List<RoomModel>();
            DataSet dataSet = new DataSet();
            dataSet = habitacion.lista_habitaciones();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                list.Add(new RoomModel
                {
                    ID_Consecutivo = row["ID_Consecutivo"].ToString(),
                    Nombre = row["Nombre"].ToString(),
                    Numero = Convert.ToInt32(row["Numero"]),
                    Descripcion = row["Descripcion"].ToString(),
                    Imagen = row["Imagen"].ToString(),
                    Disponibilidad = row["Disponibilidad"].ToString(),
                    ID_Precio = row["ID_Precio"].ToString()
                });
            }
            return View(list);
        }

        // View UpdateActivity
        public ActionResult UpdateActivityForm()
        {
            return View();
        }

        // View Consecutivo
        [HttpGet]
        public ActionResult UpdateConsecutiveForm()
        {

            return View();
        }

        // View Precios
        public ActionResult UpdatePricesForm()
        {
            return View();
        }

        // View UpdateRoomsForm
        public ActionResult UpdateRoomsForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string result="";

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    result = "~/images/" + file.FileName;


                }
                catch (Exception ex)
                {
          
                }
        
            return Content(result);
        }


        [HttpGet]
        public JsonResult GetConsecutives()
        {

            Entities entities = new Entities();
            return Json(entities.Consecutivo_Objeto.Where(x => x.ID_ConsecutivoObjeto.Contains("HAB"))
                .Select(x => new
            {
                Consecutivo = x.ID_ConsecutivoObjeto 
        }).ToList(), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetPrices()
        {

            Entities entities = new Entities();
            return Json(entities.Precio.Select(x => new
            {
                Consecutive = x.ID_Consecutivo,
                 Price = x.Precio1

            }).ToList(), JsonRequestBehavior.AllowGet);

        }



        // Inserts y Updates

        public JsonResult SaveConsecutive(BLL.Consecutivo consecutive)
        {

            consecutive.agregar_consecutivo();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePrice(BLL.Precio price)
        {

            price.agregar_precio();

            return Content("Success!");
        }

        public ActionResult SaveRoom(BLL.Habitacion room)
        {

            room.agregar_habitacion();

            return Content("Success!");

        }

        public JsonResult UpdateConsecutive(BLL.Consecutivo consecutive)
        {
            consecutive.modifica_consecutivo();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePrice(BLL.Precio price)
        {
            price.modifica_precio();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateRoom(BLL.Habitacion room)
        {
            room.modifica_habitacion();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }


    }
}