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
    public class ProveedorController : ControllerBase{
        private readonly IDataAccessRepository<ProveedorModel> _dataAccessproveedor;
         public ProveedorController(IDataAccessRepository<ProveedorModel>  dataAccessproveedor)
         {
             _dataAccessproveedor = dataAccessproveedor;
         }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProveedorModel>>> GetAllproveedors() {

            var proveedores = await _dataAccessproveedor.GetAll() ?? null;

            if (proveedores is null)
            {
                return NotFound();
            }

            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProveedorModel>> GetproveedorById(int id)
        {
            var proveedor = await _dataAccessproveedor.GetOne(id) ?? null;
            if (proveedor is null) 
            {
                return NotFound();
            }
            return Ok(proveedor);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] ProveedorModel proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El objeto que se envía como parámetro no es válido");
            }
            try{
    
                await _dataAccessproveedor.Add(proveedor);
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
        public async Task<IActionResult> Edit(int id, ProveedorModel proveedor)
        {
            if (id != proveedor.id_proveedor)
            {
                return BadRequest("El objeto no es válido");
            }
            try
            {
                await _dataAccessproveedor.Update(proveedor);
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
                await _dataAccessproveedor.Delete(id);
                return Ok();
                
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}