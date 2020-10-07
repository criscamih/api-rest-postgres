using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  api_stock.Models;
using System.Text;
using api_stock.common.interfaces;
using Microsoft.AspNetCore.Http;

namespace api_stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase{
        private readonly IDataAccessRepository<ProductoModel> _dataAccessProducto;
         public ProductoController(IDataAccessRepository<ProductoModel>  dataAccessProducto)
         {
             _dataAccessProducto = dataAccessProducto;
         }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductoModel>>> GetAllProductos() {

            var productos = await _dataAccessProducto.GetAll() ?? null;

            if (productos is null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoModel>> GetProductoById(int id)
        {
            var producto = await _dataAccessProducto.GetOne(id) ?? null;
            if (producto is null) 
            {
                return NotFound();
            }
            return Ok(producto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] ProductoModel producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El objeto que se envía como parámetro no es válido");
            }
            try{
    
                await _dataAccessProducto.Add(producto);
                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit(int id, ProductoModel producto)
        {
            if (id != producto.id_producto)
            {
                return BadRequest("El objeto no es válido");
            }
            try
            {
                await _dataAccessProducto.Update(producto);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id){
            try
            {
                await _dataAccessProducto.Delete(id);
                return Ok();
                
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}