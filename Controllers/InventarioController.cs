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
    public class InventarioController : ControllerBase{
        private readonly IDataAccessProvider _dataAccessProvider;

        public InventarioController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("{id}")]
        public InventarioModel GetInventarioById(int id){
            return _dataAccessProvider.GetInventarioById(id);
        }
    }
}