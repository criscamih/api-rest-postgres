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
    public class EstadoController : ControllerBase{
        private readonly IDataAccessEstado _dataAccessEstado;
         public EstadoController(IDataAccessEstado dataAccessEstado)
         {
             _dataAccessEstado = dataAccessEstado;
         }
        [HttpGet]
        public IEnumerable<EstadoModel> GetAllEstados(){
            return _dataAccessEstado.GetAllEstados();
        }
    }
}