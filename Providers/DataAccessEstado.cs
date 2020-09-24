using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.Providers.Interfaces;
using api_stock.DataAccess;
using api_stock.enums;
using System;

namespace api_stock.Providers{
    public class DataAccessEstado : IDataAccessEstado
    {
        private readonly DataAccessContext _context;

        public DataAccessEstado(DataAccessContext context)
        {
            _context = context;
        }
        public IEnumerable<EstadoModel> GetAllEstados()
        {
            return from es in _context.tbl_estado
                    select new EstadoModel{
                        id_estado = es.id_estado,
                        nombre = es.nombre,
                        descripcion = es.descripcion
                    };
        }
    }
}