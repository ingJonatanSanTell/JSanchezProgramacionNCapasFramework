using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        //INSERTAR 
        static public void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("INGRESA LOS DATOS DEL PRODUCTO");

            Console.WriteLine("COLCA EL NOMBRE DEL PRODUCTO");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("COLCA EL PRECIO UNITARIO DEL PRODUCTO");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("COLCA EL STOCK DEL PRODUCTO");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("COLCA LA DESCRIPCION DEL PRODUCTO");
            producto.Descripcion = Console.ReadLine();
            //agregar proveedor
            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("COLCA EL ID DEL PROVEEDOR");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            //agregar departamento
            producto.Departamento = new ML.Departamento();
            Console.WriteLine("COLCA EL ID DEL DEPARTAMENTO");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());


            //INSERTAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Producto.Add(producto);



            if (result.Correct)
            {
                Console.WriteLine("SE INSERTO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL INSERTAR EL PRODUCTO \n" + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        //ACTUALIZAR
        static public void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("INGRESA LOS DATOS A ACTUALIZAR");

            Console.WriteLine("COLOCA EL ID DEL PRODUCTO A MODIFICAR");
            producto.IdProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("COLCA EL NOMBRE DEL PRODUCTO");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("COLCA EL PRECIO UNITARIO DEL PRODUCTO");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("COLCA EL STOCK DEL PRODUCTO");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("COLCA LA DESCRIPCION DEL PRODUCTO");
            producto.Descripcion = Console.ReadLine();
            //agregar proveedor
            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("COLCA EL ID DEL PROVEEDOR");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            //agregar departamento
            producto.Departamento = new ML.Departamento();
            Console.WriteLine("COLCA EL ID DEL DEPARTAMENTO");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());


            //ACTUALIZAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("SE ACTUALIZO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL ACTUALIZAR EL PRODUCTO \n" + result.ErrorMessage);
            }
            Console.ReadLine();

        }

        //ELIMINAR
        static public void Delete()
        {

            Console.WriteLine("COLOCA EL ID DEL PRODUCTO A ELIMINAR");
            int IdProducto = int.Parse(Console.ReadLine());


            //ELIMINAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Producto.Delete(IdProducto);


            if (result.Correct)
            {
                Console.WriteLine("SE ELIMINO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL ELIMINAR EL PRODUCTO \n" + result.ErrorMessage);
            }
            Console.ReadLine();

        }

        //MOSTRAR GETALL
        static public void GetAll()
        {

            //MOSTRAR GET ALL YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Producto.GetAll();


            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("EL ID DEL PRODUCTO ES: " + producto.IdProducto);
                    Console.WriteLine("EL NOMBRE DEL PRODUCTO ES: " + producto.Nombre);
                    Console.WriteLine("EL PRECIO UNITARIO DEL PRODUCTO ES: " + producto.PrecioUnitario);
                    Console.WriteLine("EL STOCK DEL PRODUCTO ES: " + producto.Stock);
                    Console.WriteLine("LA DESCRIPCION DEL PRODUCTO ES: " + producto.Descripcion);
                    Console.WriteLine("EL ID DEL PROVEEDOR ES: " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("EL ID DEL DEPARTAMENTO ES: " + producto.Departamento.IdDepartamento);
                    Console.WriteLine("EL NOMBRE DEL PROVEEDOR ES: " + producto.Proveedor.Nombre);
                    Console.WriteLine("EL TELEFONO DEL PROVEEDOR ES: " + producto.Proveedor.Telefono);
                    Console.WriteLine("EL NOMBRE DEL DEPARTAMENTO ES: " + producto.Departamento.Nombre);
                    Console.WriteLine("EL ID DEL AREA ES: " + producto.Departamento.Area.IdArea);
                    Console.WriteLine("EL NOMBRE DEL AREA ES: " + producto.Departamento.Area.Nombre);
                    Console.WriteLine("----------------------------------------------------------------------------------");

                }
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR " + result.ErrorMessage);
            }
        }

        //MOSTRAR CON GETBYID
        static public void GetById()
        {
            Console.WriteLine("COLOCA EL ID DEL PRODUCTO A VISUALIZAR");
            int IdProducto = int.Parse(Console.ReadLine());

            //ACTUALIZAR BYID YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Producto.GetById(IdProducto);

            if (result.Correct)
            {
                ML.Producto producto = (ML.Producto)result.Object; //unboxing

                Console.WriteLine("EL ID DEL PRODUCTO ES: " + producto.IdProducto);
                Console.WriteLine("EL NOMBRE DEL PRODUCTO ES: " + producto.Nombre);
                Console.WriteLine("EL PRECIO UNITARIO DEL PRODUCTO ES: " + producto.PrecioUnitario);
                Console.WriteLine("EL STOCK DEL PRODUCTO ES: " + producto.Stock);
                Console.WriteLine("LA DESCRIPCION DEL PRODUCTO ES: " + producto.Descripcion);
                Console.WriteLine("EL ID DEL PROVEEDOR ES: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("EL ID DEL DEPARTAMENTO ES: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("EL NOMBRE DEL PROVEEDOR ES: " + producto.Proveedor.Nombre);
                Console.WriteLine("EL TELEFONO DEL PROVEEDOR ES: " + producto.Proveedor.Telefono);
                Console.WriteLine("EL NOMBRE DEL DEPARTAMENTO ES: " + producto.Departamento.Nombre);
                Console.WriteLine("EL ID DEL AREA ES: " + producto.Departamento.Area.IdArea);
                Console.WriteLine("EL NOMBRE DEL AREA ES: " + producto.Departamento.Area.Nombre);
                Console.WriteLine("----------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR " + result.ErrorMessage);
            }
        }
    }
}
