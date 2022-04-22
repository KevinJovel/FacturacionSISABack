using FacturacionSISA.Models;
using FacturacionSISA.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionSISA.Repositories
{
    public class ProductoRepository : IProductoService
    {

        private readonly FacturacionSISADBContext _ctx;
        public ProductoRepository(FacturacionSISADBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TProducto> creatProducto(TProducto prod)
        {
            await _ctx.TProductos.AddAsync(prod);
            await _ctx.SaveChangesAsync();
            return prod;
        }

        public async Task<TProducto> eliminarProducto(TProducto prod)
        {
            _ctx.TProductos.Remove(prod);
            await _ctx.SaveChangesAsync();
            return prod;
        }

        public async Task<TProducto> getProductosById(int ID)
        {
            return await _ctx.TProductos.Where(x => x.ProductoId == ID).FirstOrDefaultAsync();
        }

        public async Task<List<TProducto>> listaProductos()
        {
            return await _ctx.TProductos.ToListAsync();
        }

        public async Task<TProducto> updateProducto(TProducto prod)
        {
           
            try
            {
                string spSQL = "EXEC [dbo].[SP_MODIFICAR_PRECIO_PRODUCTO]  @ID,@Precio";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = prod.ProductoId},
                        new SqlParameter("@Precio", SqlDbType.Decimal) { Value = prod.Precio},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return prod;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
