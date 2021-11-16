using BriveExam.Clases;
using BriveExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Data.Producto
{
    public class ProductoDL
    {
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


        public void AddProducto(ProductoCLS producto)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Producto model = new Models.Producto();

                model.NombreProducto = producto.NombreProducto;
                model.Sku = producto.Sku;
        

                db.Productos.Add(model);
                db.SaveChanges();

            }
        }



        public ProductoCLS GetProductoId(int Id)
        {
            ProductoCLS producto = new ProductoCLS();
            using (briveExamContext db = new briveExamContext())
            {
                producto = (from s in db.Productos
                            where s.IdProducto == Id
                            select new ProductoCLS
                            {
                                IdProducto = s.IdProducto,
                                NombreProducto = s.NombreProducto,
                                Sku = s.Sku
                              

                            }).First();
            }

            return producto;

        }
        public void EditarProducto(ProductoCLS producto)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Producto model = db.Productos.Where(s => s.IdProducto == producto.IdProducto).First();
                model.NombreProducto = producto.NombreProducto;
                model.Sku = producto.Sku;
                
                db.SaveChanges();
            }
        }

        public void EliminarProducto(int Id)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Producto model = db.Productos.Where(s => s.IdProducto == Id).First();
                db.Productos.Remove(model);
                db.SaveChanges();

            }
        }

    }
}
