using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FacturacionSISA.Models
{
    public partial class TOrdenCompra
    {
        public TOrdenCompra()
        {
            TDetOrdenCompras = new HashSet<TDetOrdenCompra>();
        }

        public int OrdenCompraId { get; set; }
        public DateTime Fecha { get; set; }
        [JsonIgnore]

        public virtual ICollection<TDetOrdenCompra> TDetOrdenCompras { get; set; }
    }
}
