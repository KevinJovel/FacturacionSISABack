using FacturacionSISA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturacionSISA.Services
{
    public interface IProductoService
    {
        Task<List<TProducto>> listaProductos();
        Task<TProducto> getProductosById(int ID);

        Task<TProducto> creatProducto(TProducto prod);
        Task<TProducto> updateProducto(TProducto prod);
        Task<TProducto> eliminarProducto(TProducto prod);
    
    }
}
