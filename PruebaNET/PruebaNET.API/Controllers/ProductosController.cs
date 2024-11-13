using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PruebaNET.BL.Interfaces;
using PruebaNET.DAL;
using PruebaNET.DAL.DTOs;
using PruebaNET.DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaNET.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        IProductos _productos;

        public ProductosController(IProductos productos)
        {
            this._productos=productos;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductos()
        {
            return await _productos.GetProducts();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Task<ProductGetByIDDTO> GetProductAsync(int id)
        {
            return _productos.GetProductAsync(id);
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<IActionResult> SetProduct(ProductDTO product)
        {
            bool result = await _productos.SetProductAsync(product);
            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, mensaje = "Producto creado con éxito" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, mensaje = "Error creando el producto" });
            }

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO product)
        {
            bool result = await _productos.UpdateProductAsync(product,id);
            if (result)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, mensaje = "Producto modificado con éxito" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, mensaje = "Error modificando el producto" });
            }
        }
    }
}
