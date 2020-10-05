using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using api_stock.enums;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;

namespace api_stock.Providers{
    public class DataAccessProducto : IDataAccessRepository<ProductoModel>
    {
        private readonly DataAccessContext _context;
        public DataAccessProducto(DataAccessContext context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<ProductoModel>> GetAll() =>
            await (
                from productos in _context.tbl_producto
                select productos
            ).ToListAsync();

        public override Task Add(ProductoModel TEntity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public override Task<ProductoModel> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(ProductoModel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}