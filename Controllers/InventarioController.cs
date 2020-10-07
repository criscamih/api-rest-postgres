using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  api_stock.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using api_stock.common.interfaces;

namespace api_stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase{
        private readonly IDataAccessRepository<InventarioModel> _dataAccessProvider;

        public InventarioController(IDataAccessRepository<InventarioModel>  dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InventarioModel>>> GetAllInventarios()
        {

            var inventarios = await _dataAccessProvider.GetAll() ?? null;

            if (inventarios is null)
            {
                return NotFound();
            }

            return Ok(inventarios);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InventarioModel>> GetInventarioById(int id)
        {
            var inventario = await _dataAccessProvider.GetOne(id) ?? null;
            if (inventario is null) 
            {
                return NotFound();
            }
            return Ok(inventario);

        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] InventarioModel inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El objeto que se envía como parámetro no es válido");
            }
            try
            {
                inventario.codigo_serial = GetSerialNumber(10);
                inventario.fecha = DateTime.Now;
                await _dataAccessProvider.Add(inventario);
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
        public async Task<IActionResult> Edit(int id, InventarioModel inventario)
        {
            if (id != inventario.id_inventario)
            {
                return BadRequest("El objeto no es válido");
            }
            try
            {
                inventario.fecha = DateTime.Now;
                await _dataAccessProvider.Update(inventario);
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
                await _dataAccessProvider.Delete(id);
                return Ok();
                
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
        private string GetSerialNumber(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            
            return res.ToString();
        }
    }
}