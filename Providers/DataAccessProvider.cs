using api_stock.Models;
using System.Collections.Generic;
using System.Linq;
using api_stock.Providers.Interfaces;
using api_stock.DataAccess;
using api_stock.enums;
using System;

namespace api_stock.Providers{
    public class DataAccessProvider : IDataAccessProvider{

        private readonly DataAccessContext _context;
        public DataAccessProvider(DataAccessContext context)
        {
            _context = context;
        }

        public void AddInventarioRecord(InventarioModel inventario)
        {
            _context.tbl_inventario.Add(inventario);
            _context.SaveChanges();
        }

        public void DeleteInventario(int id)
        {
            var inventario = _context.tbl_inventario.FirstOrDefault(inv => inv.id_inventario == id);
            _context.tbl_inventario.Remove(inventario);
            _context.SaveChanges();
        }

        public IEnumerable<InventarioDetalleModel> GetAllProducts()
        {

            return from inv in _context.tbl_inventario
                   join prop in _context.tbl_producto
                   on inv.id_producto equals prop.id_producto
                   join pv in _context.tbl_proveedor
                   on prop.id_proveedor equals pv.id_proveedor
                   join em in _context.tbl_empleado
                   on inv.id_empleado equals em.id_empleado
                   join ar in _context.tbl_area
                   on inv.id_area equals ar.id_area
                   select new InventarioDetalleModel
                   {
                       nombre = prop.nombre,
                       descripcion = prop.descripcion,
                       tipo = prop.id_tipo_producto == 1 ? Enum.GetName(typeof(TipoProducto), TipoProducto.tecnologico) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(TipoProducto), TipoProducto.miscelaneo) : Enum.GetName(typeof(TipoProducto), TipoProducto.inmueble),
                       serial = inv.codigo_serial,
                       valor = prop.valor,
                       fecha = inv.fecha,
                       estado = inv.id_estado == 1 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.activo) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.reparado) : Enum.GetName(typeof(EstadoProducto), EstadoProducto.no_funcional)
                   };
        }

        public InventarioDetalleModel GetProductById(int id)
        {
            return (from inv in _context.tbl_inventario
                    join prop in _context.tbl_producto
                    on inv.id_producto equals prop.id_producto
                    join pv in _context.tbl_proveedor
                    on prop.id_proveedor equals pv.id_proveedor
                    join em in _context.tbl_empleado
                    on inv.id_empleado equals em.id_empleado
                    join ar in _context.tbl_area
                    on inv.id_area equals ar.id_area
                    where inv.id_inventario == id
                    select new InventarioDetalleModel
                    {
                        nombre = prop.nombre,
                        descripcion = prop.descripcion,
                        tipo = prop.id_tipo_producto == 1 ? Enum.GetName(typeof(TipoProducto), TipoProducto.tecnologico) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(TipoProducto), TipoProducto.miscelaneo) : Enum.GetName(typeof(TipoProducto), TipoProducto.inmueble),
                        serial = inv.codigo_serial,
                        valor = prop.valor,
                        fecha = inv.fecha,
                        estado = inv.id_estado == 1 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.activo) : prop.id_tipo_producto == 2 ? Enum.GetName(typeof(EstadoProducto), EstadoProducto.reparado) : Enum.GetName(typeof(EstadoProducto), EstadoProducto.no_funcional)
                    }).FirstOrDefault();
        }

        public void UpdateInventario(InventarioModel inventario)
        {
            _context.tbl_inventario.Update(inventario);
            _context.SaveChanges();
        }
    }
}