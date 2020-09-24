using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.Providers.Interfaces;
using api_stock.DataAccess;
using api_stock.enums;
using System;

namespace api_stock.Providers{
    public class DataAccessEmpleado : IDataAccessEmpleado
    {
        private readonly DataAccessContext _context;
        public DataAccessEmpleado(DataAccessContext context)
        {
            _context = context;
        }
        public IEnumerable<EmpleadoModel> GetAllEmpleados()
        {
            return from em in _context.tbl_empleado
                    select new EmpleadoModel {
                        id_empleado = em.id_empleado,
                        nombre = em.nombre,
                        dni = em.dni
                    };
        }
    }
}