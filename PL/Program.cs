using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n ---------- COLOCA UNA OPCION DEL MENU ---------- \n\nOPCION (1): MOSTRAR CON GETALL \n\nOPCION (2): MOSTRAR CON GETBYID \n\nOPCION (3): INSERTAR \n\nOPCION (4): ACTUALIZAR \n\nOPCION (5): ELIMINAR \n\nOPCION (6): SALIR \n------------------------------------------");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        PL.Producto.GetAll();
                        break;

                    case 2:
                        PL.Producto.GetById();
                        break;

                    case 3:
                        PL.Producto.Add();
                        break;

                    case 4:
                        PL.Producto.Update();
                        break;

                    case 5:
                        PL.Producto.Delete();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;
                }
            } while (opcion != 6);
            Console.ReadKey();
        }
    }
}