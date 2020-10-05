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
    public class EstadoController : ControllerBase{
        private readonly IDataAccessRepository<EstadoModel> _dataAccessEstado;
         public EstadoController(IDataAccessRepository<EstadoModel>  dataAccessEstado)
         {
             _dataAccessEstado = dataAccessEstado;
         }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EstadoModel>>> GetAllEstados()
        {
            var estados = await _dataAccessEstado.GetAll() ?? null;

            if (estados is null)
            {
                return NotFound();
            }

            return Ok(estados);
        }
        
    }
}