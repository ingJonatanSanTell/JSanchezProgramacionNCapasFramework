﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        string Saludar(string nombre);

        [OperationContract]
        int Suma(int numeroUno, int numeroDos);

        [OperationContract]
        int Resta(int numeroUno, int numeroDos);

        [OperationContract]
        int Multiplicacion(int numeroUno, int numeroDos);

        [OperationContract]
        double Divicion(double numeroUno, double numeroDos);
    }
}
