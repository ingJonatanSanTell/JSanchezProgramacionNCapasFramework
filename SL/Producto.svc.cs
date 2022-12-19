using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public SL.Result Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL.Result Update(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Update(producto);
            return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL.Result Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.Delete(IdProducto);
            return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL.Result GetALL()
        {
            ML.Result result = BL.Producto.GetAll();
            return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }

        public SL.Result GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);
            return new SL.Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object, Objects = result.Objects };
        }
    }
}
