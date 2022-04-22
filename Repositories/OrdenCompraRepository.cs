using FacturacionSISA.Models;
using FacturacionSISA.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FacturacionSISA.Repositories
{
    public class OrdenCompraRepository : IOrdenCompraServicecs
    {

        private readonly FacturacionSISADBContext _ctx;
        public OrdenCompraRepository(FacturacionSISADBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TOrdenCompra> creatOrdenCompra(List<TDetOrdenCompra> prod)
        {
            TOrdenCompra orden = new TOrdenCompra();
            orden.Fecha = System.DateTime.Now;
            _ctx.TOrdenCompras.Add(orden);
            _ctx.SaveChanges();
            var ultimaOrden = await _ctx.TOrdenCompras.OrderBy(x=>x.OrdenCompraId).LastAsync();

            foreach (var item in prod)
            {
                var producto = _ctx.TProductos.Where(x => x.ProductoId == item.ProductoId).FirstOrDefault();
                item.OrdenId = ultimaOrden.OrdenCompraId;
                item.Total = producto.Precio * item.Cantidad;
                _ctx.TDetOrdenCompras.Add(item);
                _ctx.SaveChanges();
            }
            return ultimaOrden;
        }

        //public async Task<TOrdenCompra> creatOrdenCompra(List<TDetOrdenCompra> prod)
        //{
        //    TOrdenCompra orden = new TOrdenCompra();
        //    orden.Fecha = System.DateTime.Now;
        //    _ctx.TOrdenCompras.Add(orden);
        //    var ultimaOrden = await _ctx.TOrdenCompras.LastAsync();

        //    foreach (var item in prod)
        //    {
        //        item.OrdenId = ultimaOrden.OrdenCompraId;
        //        _ctx.TDetOrdenCompras.Add(item);
        //    }
        //    return ultimaOrden;
        //}
    }
}
