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
    public class DataAccessEmpleado : IDataAccessRepository<EmpleadoModel>
    {
        private readonly DataAccessContext _context;
        public DataAccessEmpleado(DataAccessContext context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<EmpleadoModel>> GetAll()=>
                    await (from empleados in _context.tbl_empleado
                           select empleados).ToListAsync();

        public override Task Add(EmpleadoModel TEntity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public override Task<EmpleadoModel> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Update(EmpleadoModel TEntity)
        {
            throw new NotImplementedException();
        }
    }
}