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
    public class TipoProductoController : ControllerBase{
         private readonly IDataAccessRepository<TipoProductoModel> _dataAccessTP;
         public TipoProductoController(IDataAccessRepository<TipoProductoModel> dataAccessTP)
         {
             _dataAccessTP = dataAccessTP;
         }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AreaModel>>> GetAllTipos()
        {
            var tipos = await _dataAccessTP.GetAll() ?? null;

            if (tipos is null)
            {
                return NotFound();
            }

            return Ok(tipos);
        }
    }
}