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
    
    public partial class Consecutivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consecutivo()
        {
            this.Actividades = new HashSet<Actividades>();
            this.Articulos = new HashSet<Articulos>();
            this.Bitacora = new HashSet<Bitacora>();
            this.Clientes = new HashSet<Clientes>();
            this.Codigos_Descuento = new HashSet<Codigos_Descuento>();
            this.Habitaciones = new HashSet<Habitaciones>();
            this.Historial_Transacciones = new HashSet<Historial_Transacciones>();
            this.Precios = new HashSet<Precios>();
            this.Reservacion_habitaciones = new HashSet<Reservacion_habitaciones>();
        }
    
        public int ID { get; set; }
        public int Consecutivo1 { get; set; }
        public string Descripcion { get; set; }
        public string Prefijo { get; set; }
        public Nullable<int> Rango_inicial { get; set; }
        public Nullable<int> Rango_final { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividades> Actividades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articulos> Articulos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bitacora> Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Codigos_Descuento> Codigos_Descuento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Habitaciones> Habitaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial_Transacciones> Historial_Transacciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precios> Precios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservacion_habitaciones> Reservacion_habitaciones { get; set; }
    }
}
