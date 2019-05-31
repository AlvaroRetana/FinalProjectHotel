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
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.Cliente_Articulos = new HashSet<Cliente_Articulos>();
            this.Cliente_Habitaciones = new HashSet<Cliente_Habitaciones>();
            this.Codigos_Descuento = new HashSet<Codigos_Descuento>();
            this.Historial_Transacciones = new HashSet<Historial_Transacciones>();
            this.Reservacion_habitaciones = new HashSet<Reservacion_habitaciones>();
        }
    
        public int ID { get; set; }
        public int ID_Consecutivo { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Dias_Visita { get; set; }
        public string Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente_Articulos> Cliente_Articulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente_Habitaciones> Cliente_Habitaciones { get; set; }
        public virtual Consecutivo Consecutivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Codigos_Descuento> Codigos_Descuento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial_Transacciones> Historial_Transacciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservacion_habitaciones> Reservacion_habitaciones { get; set; }
    }
}
