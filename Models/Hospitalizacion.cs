//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeterinariaServ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hospitalizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hospitalizacion()
        {
            this.Detalle_Factura = new HashSet<Detalle_Factura>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_Mascota { get; set; }
        public Nullable<int> ID_Cama { get; set; }
        public Nullable<int> ID_ProductoFarmacia { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public Nullable<decimal> Costo { get; set; }
    
        public virtual Cama Cama { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Factura> Detalle_Factura { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual Productos_Farmacia Productos_Farmacia { get; set; }
    }
}
