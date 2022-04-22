using FacturacionSISA.Models;
using FacturacionSISA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FacturacionSISA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _Iprod;
        public ProductosController(IProductoService Iprod)
        {
            _Iprod = Iprod;
        }
        [HttpPost]
        public async Task<ActionResult> crearProducto([FromBody] TProducto prod)
        {
            try
            {
                return Ok(await _Iprod.creatProducto(prod));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> listarProductos()
        {
            try
            {
                return Ok(await _Iprod.listaProductos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        } 
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> listarProductos(int id)
        {
            try
            {
                return Ok(await _Iprod.getProductosById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> updateProducto([FromBody] TProducto prod)
        {
            try
            {
                return Ok(await _Iprod.updateProducto(prod));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> deleteProducto([FromBody] TProducto prod)
        {
            try
            {
                return Ok(await _Iprod.eliminarProducto(prod));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
