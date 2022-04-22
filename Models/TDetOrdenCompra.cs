using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FacturacionSISA.Models
{
    public partial class TDetOrdenCompra
    {
        public int DetOrdenId { get; set; }
        public int ProductoId { get; set; }
        public int OrdenId { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        [JsonIgnore]
        public virtual TOrdenCompra Orden { get; set; }
        [JsonIgnore]
        public virtual TProducto Producto { get; set; }
    }
}
