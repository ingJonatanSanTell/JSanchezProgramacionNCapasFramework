using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public String Nombre { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public String Descripcion { get; set; }
        public ML.Proveedor Proveedor { get; set; }
        public ML.Departamento Departamento { get; set; }
    }
}
