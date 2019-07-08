using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class ConsecutiveModel
    {
        public int Codigo { get; set; }
        public string ID_Consecutivo { get; set; }
        public string Descripcion { get; set; }
        public string Prefijo { get; set; }
        public int Rango_Inicial { get; set; }
        public int Rango_Final { get; set; }

    }
}