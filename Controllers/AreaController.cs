using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  api_stock.Models;
using api_stock.Providers.Interfaces;
using System.Text;

namespace api_stock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase{
         private readonly IDataAccessArea _dataAccessArea;
         public AreaController(IDataAccessArea dataAccessArea)
         {
             _dataAccessArea = dataAccessArea;
         }
        [HttpGet]
        public IEnumerable<AreaModel> GetAllAreas(){
            return _dataAccessArea.GetAllAreas();
        }
    }
}