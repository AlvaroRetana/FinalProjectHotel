//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProjectHotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historial_Transacciones
    {
        public int ID { get; set; }
        public int ID_Consecutivo { get; set; }
        public int ID_Cliente { get; set; }
        public int Metodo_pago { get; set; }
        public int Monto { get; set; }
        public Nullable<int> ID_Habitacion { get; set; }
        public Nullable<int> ID_Articulo { get; set; }
    
        public virtual Articulos Articulos { get; set; }
        public virtual Clientes Clientes { get; set; }
        public virtual Consecutivo Consecutivo { get; set; }
        public virtual Habitaciones Habitaciones { get; set; }
    }
}
