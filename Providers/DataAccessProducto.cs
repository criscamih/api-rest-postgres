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

        public override async Task Add(ProductoModel producto)
        {
            try
            {
                _context.tbl_producto.Add(producto);
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
                var producto = _context.tbl_producto.FirstOrDefault(p => p.id_producto == id);
                _context.tbl_producto.Remove(producto);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public override async Task<ProductoModel> GetOne(int id) => 
            await (from producto in _context.tbl_producto
                    where producto.id_producto == id
                    select producto).FirstOrDefaultAsync();

        public override async Task Update(ProductoModel producto)
        {
            try
            {
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}