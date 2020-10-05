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
    public class ProductoController : ControllerBase{
        private readonly IDataAccessRepository<ProductoModel> _dataAccessProducto;
         public ProductoController(IDataAccessRepository<ProductoModel>  dataAccessProducto)
         {
             _dataAccessProducto = dataAccessProducto;
         }
        [HttpGet]
        public async Task<IEnumerable<ProductoModel>> GetAllProductos() => await _dataAccessProducto.GetAll();
        
    }
}