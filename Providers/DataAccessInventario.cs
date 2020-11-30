using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.DataAccess;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_stock.common.interfaces;


namespace api_stock.Providers{
    public class DataAccessInventario : IDataAccessRepository<InventarioModel>
    {
        private readonly DataAccessContext _context;

        public DataAccessInventario(DataAccessContext context)
        {
            _context = context;
        }
        public override async Task Add(InventarioModel inventario)
        {
            try
            {
                _context.tbl_inventario.Add(inventario);
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
                var inventario = _context.tbl_inventario.FirstOrDefault(inv => inv.id_inventario == id);
                _context.tbl_inventario.Remove(inventario);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override async Task<IEnumerable<InventarioModel>> GetAll() => 
            await (from inventarios in _context.tbl_inventario
                    select inventarios).ToListAsync();

        public override async Task<InventarioModel> GetOne(int id) => 
            await (from inventario in _context.tbl_inventario
                    where inventario.id_inventario == id
                    select inventario).FirstOrDefaultAsync();

        public override async Task Update(InventarioModel inventario)
        {
            try
            {
                _context.Entry(inventario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

       
    }
}