using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FacturacionSISA.Models
{
    public partial class TProducto
    {
        public TProducto()
        {
            TDetOrdenCompras = new HashSet<TDetOrdenCompra>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        [JsonIgnore]
        public virtual ICollection<TDetOrdenCompra> TDetOrdenCompras { get; set; }
    }
}
