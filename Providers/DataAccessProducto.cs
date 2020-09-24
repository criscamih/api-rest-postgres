using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.Providers.Interfaces;
using api_stock.DataAccess;
using api_stock.enums;
using System;

namespace api_stock.Providers{
    public class DataAccessProducto : IDataAccessProducto
    {
        private readonly DataAccessContext _context;
        public DataAccessProducto(DataAccessContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductoModel> GetAllProductos()
        {
            return from pro in _context.tbl_producto
                   select new ProductoModel
                   {
                       id_producto = pro.id_producto,
                       nombre = pro.nombre,
                       descripcion = pro.descripcion,
                       valor = pro.valor
                   };
        }
    }
}