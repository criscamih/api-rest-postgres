using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;

namespace api_stock.Providers{
    public class DataAccessProveedor : IDataAccessRepository<ProveedorModel>
    {
        private readonly DataAccessContext _context;
        public DataAccessProveedor(DataAccessContext context)
        {
            _context = context;
        }

        public override async Task Add(ProveedorModel proveedor)
        {
            try
            {
                _context.tbl_proveedor.Add(proveedor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task Delete(int id)
        {
            try
            {
                var proveedor = _context.tbl_proveedor.FirstOrDefault(p => p.id_proveedor == id);
                _context.tbl_proveedor.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override async Task<IEnumerable<ProveedorModel>> GetAll() =>
                await (from proveedores in _context.tbl_proveedor
                       select proveedores
                ).ToListAsync();

        public override async Task<ProveedorModel> GetOne(int id) =>
                await (from proveedor in _context.tbl_proveedor
                        where proveedor.id_proveedor == id 
                        select proveedor).FirstOrDefaultAsync();

        public override async Task Update(ProveedorModel proveedor)
        {
            try
            {
                _context.Entry(proveedor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}