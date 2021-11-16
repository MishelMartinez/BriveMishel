using BriveExam.Clases;
using BriveExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Data.Inventario
{
    public class InventarioDL
    {
        public List<InventarioCLS> GetInventorio()
        {
            List<InventarioCLS> list = new List<InventarioCLS>();
            using (briveExamContext db = new briveExamContext())
            {
                list = (from inventario in db.Inventarios
                        join producto in db.Productos

                        on inventario.IdProducto equals
                        producto.IdProducto
                        join sucursal in db.Sucursals
                        on inventario.IdSucursal equals
                        sucursal.IdSucursal
                        select new InventarioCLS
                        {
                            IdInventario = inventario.IdInventario,
                            Stock = inventario.Stock,
                            NombreProducto = producto.NombreProducto,
                            NombreSucursal = sucursal.NombreSucursal,
                            IdSucursal = sucursal.IdSucursal,
                            IdProducto = producto.IdProducto

                        }).ToList();

            }

            return list;
        }

        public List<ProductoCLS> GetProductos()
        {
            List<ProductoCLS> list = new List<ProductoCLS>();
            using (briveExamContext db = new briveExamContext())
            {
                list = (from product in db.Productos
                        select new ProductoCLS
                        {
                            IdProducto = product.IdProducto,
                            NombreProducto = product.NombreProducto,
                            Sku = product.Sku

                        }).ToList();

            }

            return list;
        }


        public List<SucursalCLS> GetSucursals()
        {
            List<SucursalCLS> list = new List<SucursalCLS>();
            using (briveExamContext db = new briveExamContext())
            {
                list = (from branch in db.Sucursals
                        select new SucursalCLS
                        {
                            IdSucursal = branch.IdSucursal,
                            NombreSucursal = branch.NombreSucursal,
                            Direccion = branch.Direccion,
                            Telefono = branch.Telefono

                        }).ToList();

            }

            return list;
        }


        public void AddInventario (InventarioCLS model)
        {
            BriveExam.Models.Inventario inventario = new Models.Inventario();
            using (briveExamContext db = new briveExamContext())
            {
                inventario.IdProducto = model.IdProducto;
                inventario.IdSucursal = model.IdSucursal;
                inventario.Stock = model.Stock;

                db.Inventarios.Add(inventario);
                db.SaveChanges();

            }


         }



        public InventarioCLS GetInventarioId(int Id)
        {
            InventarioCLS inventario = new InventarioCLS();
            using (briveExamContext db = new briveExamContext())
            {
                inventario = (from s in db.Inventarios
                            where s.IdInventario == Id
                            select new InventarioCLS
                            {
                                IdInventario = s.IdInventario,
                                IdSucursal = s.IdSucursal,
                                IdProducto = s.IdProducto,
                                Stock = s.Stock


                            }).First();
            }

            return inventario;

        }
        public void EditarInventario(InventarioCLS inventario)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Inventario model = db.Inventarios.Where(s => s.IdInventario == inventario.IdInventario).First();
                model.IdProducto = inventario.IdProducto;
                model.IdSucursal = inventario.IdSucursal;
                model.Stock = inventario.Stock;

                db.SaveChanges();
            }
        }

        public void EliminarInventario(int Id)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Inventario model = db.Inventarios.Where(s => s.IdInventario == Id).First();
                db.Inventarios.Remove(model);
                db.SaveChanges();

            }
        }
    }
}
