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
    public class ProductStockController : ControllerBase{
        private readonly IDataAccessProvider _dataAccessProvider;

        public ProductStockController(IDataAccessProvider provider){
            _dataAccessProvider = provider;
        }

        [HttpGet]
        public IEnumerable<InventarioDetalleModel> GetAllProducts(){

            return _dataAccessProvider.GetAllProducts();
        }

        [HttpGet("{id}")]
        public InventarioDetalleModel GetProductById(int id){
            return _dataAccessProvider.GetProductById(id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] InventarioModel inventario)
        {
            if(ModelState.IsValid){
                inventario.codigo_serial = GetSerialNumber(10);
                inventario.fecha = DateTime.Now;
                _dataAccessProvider.AddInventarioRecord(inventario);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] InventarioModel inventario){
            if(ModelState.IsValid){
                inventario.fecha = DateTime.Now;
                _dataAccessProvider.UpdateInventario(inventario);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductFromInventario(int id){
            var producto = _dataAccessProvider.GetProductById(id);
            if (producto == null){
                return NotFound();
            }
            _dataAccessProvider.DeleteInventario(id);
            return Ok();
        }

        private string GetSerialNumber(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }
    }
}