using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    static public class Producto
    {
        //AGREGAR ADD CON ENTITY FRAMEWORK
        static public ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL INSERTAR EL PRODUCTO";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //ELIMINAR DELETE CON ENTITY FRAMEWORK
        static public ML.Result Delete(int IdProducto)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.ProductoDelete(IdProducto);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ELIMINAR EL PRODUCTO";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //ACTUALIZAR UPDATE CON ENTITY FRAMEWORK
        static public ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ACTUALIZAR EL PRODUCTO";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

        //GETALL CON ENTITY FRAMEWORK
        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetAll().ToList();


                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var objProducto in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = objProducto.IdProducto;
                            producto.Nombre = objProducto.NombreProducto;
                            producto.PrecioUnitario = objProducto.PrecioUnitario;
                            producto.Stock = objProducto.Stock;
                            producto.Descripcion = objProducto.Descripcion;
                            //proveedor
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = objProducto.IdProveedor.Value;
                            producto.Proveedor.Nombre = objProducto.NombreProveedor;
                            producto.Proveedor.Telefono = objProducto.Telefono;
                            //departamento
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = objProducto.IdDepartamento.Value;
                            producto.Departamento.Nombre = objProducto.NombreDepartamento;
                            //area
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = objProducto.IdArea.Value;
                            producto.Departamento.Area.Nombre = objProducto.NombreArea;   

                            result.Objects.Add(producto);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA PRODUCTO NO TIENE DATOS";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        //GETBYID CON ENTITY FRAMEWORK
        static public ML.Result GetById(int IdProducto)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var objProducto = context.ProductoGetById(IdProducto).Single();


                    if (objProducto != null)
                    {

                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = objProducto.IdProducto;
                        producto.Nombre = objProducto.NombreProducto;
                        producto.PrecioUnitario = objProducto.PrecioUnitario;
                        producto.Stock = objProducto.Stock;
                        producto.Descripcion = objProducto.Descripcion;
                        //proveedor
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = objProducto.IdProveedor.Value;
                        producto.Proveedor.Nombre = objProducto.NombreProveedor;
                        producto.Proveedor.Telefono = objProducto.Telefono;
                        //departamento
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.IdDepartamento = objProducto.IdDepartamento.Value;
                        producto.Departamento.Nombre = objProducto.NombreDepartamento;
                        //area
                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.IdArea = objProducto.IdArea.Value;
                        producto.Departamento.Area.Nombre = objProducto.NombreArea;


                        result.Object = producto; //BOXING
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA PRODUCTO NO TIENE DATOS";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
