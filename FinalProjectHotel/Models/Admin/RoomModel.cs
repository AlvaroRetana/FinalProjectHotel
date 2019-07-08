using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class RoomModel
    {

        public string ID_Consecutivo { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Disponibilidad { get; set; }
        public string ID_Precio { get; set; }

    }
}