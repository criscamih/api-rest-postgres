using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  api_stock.Models;
using System.Text;
using api_stock.common.interfaces;

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
        public async Task<IEnumerable<AreaModel>> GetAllAreas() => await _dataAccessArea.GetAll();
    }
}