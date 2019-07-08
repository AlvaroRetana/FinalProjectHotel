using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectHotel.Models.Admin
{

    public class PriceModel
    {

        public string ID_Consecutivo { get; set; }
        public string Tipo { get; set; }
        public string Precio { get; set; }


    }
}