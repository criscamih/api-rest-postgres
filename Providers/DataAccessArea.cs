using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.Providers.Interfaces;
using api_stock.DataAccess;
using api_stock.enums;
using System;

namespace api_stock.Providers{
    public class DataAccessArea : IDataAccessArea
    {
        private readonly DataAccessContext _context;
        public DataAccessArea(DataAccessContext context)
        {
            _context = context;
        }
        public IEnumerable<AreaModel> GetAllAreas()
        {
            return from ar in _context.tbl_area
                   select new AreaModel
                   {
                       id_area = ar.id_area,
                       nombre = ar.nombre,
                       descripcion = ar.descripcion
                   };
        }
    }
}