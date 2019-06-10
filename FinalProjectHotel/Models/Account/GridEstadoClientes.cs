using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectHotel.Models.Account
{
    public class GridEstadoClientes
    {

        public int ID { get; set; }
        public int ID_Consecutivo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Activo { get; set; }

    }
}