using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;

namespace api_stock.Providers{
    public class DataAccessTP : IDataAccessRepository<TipoProductoModel>
    {
        private readonly DataAccessContext _context;
        public DataAccessTP(DataAccessContext context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<TipoProductoModel>> GetAll() =>
            await (from tipos in _context.tbl_tipo_producto
                   select tipos).ToListAsync();
        public override Task Add(TipoProductoModel TEntity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<TipoProductoModel> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(TipoProductoModel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}