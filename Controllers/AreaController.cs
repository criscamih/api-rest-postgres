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
    public class AreaController : ControllerBase{
         private readonly IDataAccessRepository<AreaModel> _dataAccessArea;
         public AreaController(IDataAccessRepository<AreaModel> dataAccessArea)
         {
             _dataAccessArea = dataAccessArea;
         }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AreaModel>>> GetAllAreas()
        {
            var areas = await _dataAccessArea.GetAll() ?? null;

            if (areas is null)
            {
                return NotFound();
            }

            return Ok(areas);
        }
    }
}