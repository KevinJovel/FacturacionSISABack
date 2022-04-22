using FacturacionSISA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturacionSISA.Services
{
    public interface IOrdenCompraServicecs
    {
        Task<TOrdenCompra> creatOrdenCompra(List<TDetOrdenCompra> prod);
    }
}
