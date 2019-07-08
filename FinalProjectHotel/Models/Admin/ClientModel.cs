using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class ClientModel
    {

        public string ID_Consecutivo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Activo { get; set; }


    }
}