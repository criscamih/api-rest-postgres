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
    public class EmpleadoController : ControllerBase{

        private readonly IDataAccessEmpleado _dataAccessEmpleado;
         public EmpleadoController(IDataAccessEmpleado dataAccessEmpleado)
         {
             _dataAccessEmpleado = dataAccessEmpleado;
         }
        [HttpGet]
        public IEnumerable<EmpleadoModel> GetAllEmpleados(){
            return _dataAccessEmpleado.GetAllEmpleados();
        }
    }
}