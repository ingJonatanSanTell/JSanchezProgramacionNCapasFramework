using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
        //ADD
        [OperationContract]
        SL.Result Add(ML.Producto producto);

        //UPDATE
        [OperationContract]
        SL.Result Update(ML.Producto producto);

        //DELETE
        [OperationContract]
        SL.Result Delete(int IdProducto);

        //GETALL
        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL.Result GetALL();

        //GETBYID
        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        SL.Result GetById(int IdProducto);
    }
}
