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
    public class DataAccessEstado : IDataAccessRepository<EstadoModel>
    {
        private readonly DataAccessContext _context;

        public DataAccessEstado(DataAccessContext context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<EstadoModel>> GetAll() =>
                        await(from estados in _context.tbl_estado
                                select estados
                        ).ToListAsync();

        public override Task Add(EstadoModel TEntity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public override Task<EstadoModel> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(EstadoModel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}