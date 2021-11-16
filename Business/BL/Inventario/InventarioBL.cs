using BriveExam.Clases;
using BriveExam.Data.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Business.BL.Inventario
{
    public class InventarioBL
    {
        private InventarioDL inventarioDL;
        public InventarioBL()
        {
            inventarioDL = new InventarioDL();

        }
        public List<InventarioCLS> GetInventorio()
        {
            return inventarioDL.GetInventorio();
        }


        public List<ProductoCLS> GetProductos()
        {
            return inventarioDL.GetProductos();
        }

        public List<SucursalCLS> GetSucursals()
        {
            return inventarioDL.GetSucursals();
        }

        public void AddInventario(InventarioCLS model)
        {
            inventarioDL.AddInventario(model);
        }

        public InventarioCLS GetInventarioId(int Id)
        {
            return inventarioDL.GetInventarioId(Id);
        }

        public void EditarInventario(InventarioCLS producto)
        {
            inventarioDL.EditarInventario(producto);
        }

        public void EliminarInventario(int Id)
        {
            inventarioDL.EliminarInventario(Id);
        }
    }
}
