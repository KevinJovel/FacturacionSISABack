using FacturacionSISA.Models;
using FacturacionSISA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturacionSISA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrdenCompraServicecs _Iprod;
        public OrdenCompraController(IOrdenCompraServicecs Iprod)
        {
            _Iprod = Iprod;
        }

        [HttpPost]
        public async Task<IActionResult> updateProducto([FromBody] List<TDetOrdenCompra> prod)
        {
            try
            {
                return Ok(await _Iprod.creatOrdenCompra(prod));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
