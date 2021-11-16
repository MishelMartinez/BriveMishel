using BriveExam.Clases;
using BriveExam.Data.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Business.BL.Product
{
    public class ProductBL
    {
        private ProductoDL productDL;
        public ProductBL()
        {
            productDL = new ProductoDL();

        }

        public List<ProductoCLS> GetProductos()
        {

            return productDL.GetProductos();
        }

            public void AddProducto(ProductoCLS producto)
        {
            productDL.AddProducto(producto);
        }


        public ProductoCLS GetProductoId(int Id)
        {
            return productDL.GetProductoId(Id);
        }

        public void EditarProducto(ProductoCLS producto)
        {
            productDL.EditarProducto(producto);
        }

        public void EliminarProducto(int Id)
        {
            productDL.EliminarProducto(Id);
        }
    }
}

