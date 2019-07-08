using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class BinnacleModel
    {

        public string ID_Consecutivo { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public int Codigo_Registro { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }


    }
}