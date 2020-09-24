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
    public class ProductoController : ControllerBase{
        private readonly IDataAccessProducto _dataAccessProducto;
         public ProductoController(IDataAccessProducto dataAccessProducto)
         {
             _dataAccessProducto = dataAccessProducto;
         }
        [HttpGet]
        public IEnumerable<ProductoModel> GetAllProductos(){
            return _dataAccessProducto.GetAllProductos();
        }
    }
}