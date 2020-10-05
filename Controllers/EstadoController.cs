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
    public class EstadoController : ControllerBase{
        private readonly IDataAccessRepository<EstadoModel> _dataAccessEstado;
         public EstadoController(IDataAccessRepository<EstadoModel>  dataAccessEstado)
         {
             _dataAccessEstado = dataAccessEstado;
         }
        [HttpGet]
        public async Task<IEnumerable<EstadoModel>> GetAllEstados() => await _dataAccessEstado.GetAll();
        
    }
}