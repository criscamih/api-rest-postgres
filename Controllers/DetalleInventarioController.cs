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
using api_stock.Providers.Interfaces;

namespace api_stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleInventarioController : ControllerBase{
        private readonly IDetalleInventario _dataAccessProvider;
        public DetalleInventarioController(IDetalleInventario dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InventarioDetalleModel>> GetInventarioDetalle(int id)
        {
            var inventario = await _dataAccessProvider.GetInventarioDetalle(id) ?? null;
            if (inventario is null) 
            {
                return NotFound();
            }
            return Ok(inventario);

        }
    }
}