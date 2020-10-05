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
    public class EmpleadoController : ControllerBase{

        private readonly IDataAccessRepository<EmpleadoModel> _dataAccessEmpleado;
         public EmpleadoController(IDataAccessRepository<EmpleadoModel> dataAccessEmpleado)
         {
             _dataAccessEmpleado = dataAccessEmpleado;
         }
        [HttpGet]
        public async Task<IEnumerable<EmpleadoModel>> GetAllEmpleados() => await _dataAccessEmpleado.GetAll();
    }
}