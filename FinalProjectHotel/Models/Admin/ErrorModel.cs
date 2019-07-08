using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class ErrorModel
    {

        public int ID { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Hora { get; set; }


    }
}