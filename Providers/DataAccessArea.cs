using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;

namespace api_stock.Providers{
    public class DataAccessArea : IDataAccessRepository<AreaModel>
    {
        private readonly DataAccessContext _context;
        public DataAccessArea(DataAccessContext context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<AreaModel>> GetAll()=>
            await (from areas in _context.tbl_area
                   select areas).ToListAsync();

        public override Task Add(AreaModel TEntity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<AreaModel> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(AreaModel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}