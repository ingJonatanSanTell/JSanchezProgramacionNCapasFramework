using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //INSERTAR 
        static public void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("INGRESA LOS DATOS DEL USUARIO");
            Console.WriteLine("COLCA SU NOMBRE DE USUARIO");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("COLCA SU NOMBRE");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("COLCA SU APELLIDO PATERNO");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("COLCA SU APELLIDO MATERNO");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("COLCA SU EMAIL");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("COLCA SU CONTRASEÑA");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("COLCA SU FECHA DE NACIMIENTO");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("COLCA SU SEXO");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("COLCA SU TELEFONO");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("COLCA SU CELULAR");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("COLCA SU CURP");
            usuario.CURP = Console.ReadLine();
            //agregar rol
            usuario.Rol = new ML.Rol();
            Console.WriteLine("COLCA SU NUMERO DE ROL");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            //agregar direccion
            usuario.Direccion = new ML.Direccion();
            Console.WriteLine("COLCA EL NOMBRE DE SU CALLE");
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("COLCA EL NUMERO INTERIOR DE SU HOGAR EN CASO DE TENER");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("COLCA EL NUMERO EXTERIOR DE SU HOGAR");
            usuario.Direccion.NumeroExterior = Console.ReadLine();
            //agregar colonia
            usuario.Direccion.Colonia = new ML.Colonia();
            Console.WriteLine("COLCA EL ID DE LA COLONIA");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());
            


            //INSERTAR NORMAL
            //ML.Result result = BL.Usuario.Add(usuario);

            //INSERT CON SP
            //ML.Result result = BL.Usuario.AddSP(usuario);

            //INSERTAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.AddEF(usuario);

            //INSERTAR YA CON LINQ
            //ML.Result result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("SE INSERTO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL INSERTAR EL USUARIO \n" + result.ErrorMessage);
            }
            Console.ReadLine();
        }

        //ACTUALIZAR
        static public void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("INGRESA LOS DATOS A ACTUALIZAR");
            Console.WriteLine("COLOCA EL ID DEL USUARIO A MODIFICAR");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("COLCA SU NOMBRE DE USUARIO");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("COLCA SU NOMBRE");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("COLCA SU APELLIDO PATERNO");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("COLCA SU APELLIDO MATERNO");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("COLCA SU EMAIL");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("COLCA SU CONTRASEÑA");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("COLCA SU FECHA DE NACIMIENTO");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("COLCA SU SEXO");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("COLCA SU TELEFONO");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("COLCA SU CELULAR");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("COLCA SU CURP");
            usuario.CURP = Console.ReadLine();
            //agregar rol
            usuario.Rol = new ML.Rol();
            Console.WriteLine("COLCA SU NUMERO DE ROL");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            //agregar direccion
            usuario.Direccion = new ML.Direccion();
            Console.WriteLine("COLCA EL NOMBRE DE SU CALLE");
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("COLCA EL NUMERO INTERIOR DE SU HOGAR EN CASO DE TENER");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("COLCA EL NUMERO EXTERIOR DE SU HOGAR");
            usuario.Direccion.NumeroExterior = Console.ReadLine();
            //agregar colonia
            usuario.Direccion.Colonia = new ML.Colonia();
            Console.WriteLine("COLCA EL ID DE LA COLONIA");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //Console.WriteLine("COLCA UNA IMAGEN");
            //usuario.Imagen = Byte.Parse(Console.ReadLine());

            //ACTUALIZAR NORMAL
            //ML.Result result = BL.Usuario.Update(usuario);

            //ACTUALIZAR CON SP
            //ML.Result result = BL.Usuario.UpdateSP(usuario);

            //ACTUALIZAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.UpdateEF(usuario);

            //ACTUALIZAR YA CON ENTITY FRAMEWORK
            //ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("SE ACTUALIZO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL ACTUALIZAR EL USUARIO \n" + result.ErrorMessage);
            }
            Console.ReadLine();

        }

        //ELIMINAR
        static public void Delete()
        {

            Console.WriteLine("COLOCA EL ID DEL USUARIO A ELIMINAR");
            int IdUsuario = int.Parse(Console.ReadLine());

            //ELIMINAR NORMAL
            //ML.Result result = BL.Usuario.Delete(IdUsuario);

            //ELIMINAR CON SP
            //ML.Result result = BL.Usuario.DeleteSP(IdUsuario);

            //ELIMINAR YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            //ELIMINAR YA CON ENTITY FRAMEWORK
            //ML.Result result = BL.Usuario.DeleteLINQ(IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("SE ELIMINO CORRECTAMENTE");
            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR AL ELIMINAR EL USUARIO \n" + result.ErrorMessage);
            }
            Console.ReadLine();

        }

        //MOSTRAR GETALL
        static public void GetAll()
        {
            //MOSTRAR GET ALL
            //ML.Result result = BL.Usuario.GetAll();

            //MOSTRAR GET ALL SP
            //ML.Result result = BL.Usuario.GetAllSP();

            //MOSTRAR GET ALL YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.GetAllEF();

            //MOSTRAR GET ALL YA CON LINQ
            //ML.Result result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("EL ID DEL USUARIO ES: " + usuario.IdUsuario);
                    Console.WriteLine("EL USERNAME DEL USUARIO ES: " + usuario.UserName);
                    Console.WriteLine("EL NOMBRE DEL USUARIO ES: " + usuario.Nombre);
                    Console.WriteLine("EL APELLIDO PATERNO DEL USUARIO ES: " + usuario.ApellidoPaterno);
                    Console.WriteLine("EL APELLIDO MATERNO DEL USUARIO ES: " + usuario.ApellidoMaterno);
                    Console.WriteLine("LA CONTRASEÑA DEL USUARIO ES: " + usuario.Password);
                    Console.WriteLine("LA FECHA DE NACIMIENTO DEL USUARIO ES: " + usuario.FechaNacimiento);
                    Console.WriteLine("EL SEXO DEL USUARIO ES: " + usuario.Sexo);
                    Console.WriteLine("EL TELEFONO DEL USUARIO ES: " + usuario.Telefono);
                    Console.WriteLine("EL CELULAR DEL USUARIO ES: " + usuario.Celular);
                    Console.WriteLine("LA CURP DEL USUARIO ES: " + usuario.CURP);
                    Console.WriteLine("EL NUMERO DE ROL DEL USUARIO ES: " + usuario.Rol.IdRol);
                    Console.WriteLine("EL NOMBRE DE ROL DEL USUARIO ES: " + usuario.Rol.Nombre);
                    Console.WriteLine("EL ID DE LA DIRECCION ES: " + usuario.Direccion.IdDireccion);
                    Console.WriteLine("LA CALLE DE LA DIRECCION ES: " + usuario.Direccion.Calle);
                    Console.WriteLine("EL NUMERO INTERIOR DE LA DIRECCION ES: " + usuario.Direccion.NumeroInterior);
                    Console.WriteLine("EL NUMERO EXTERIOR DE LA DIRECCION ES: " + usuario.Direccion.NumeroExterior);
                    Console.WriteLine("EL ID DE LA COLONIA ES: " + usuario.Direccion.Colonia.IdColonia);
                    Console.WriteLine("EL NOMBRE DE LA COLONIA ES: " + usuario.Direccion.Colonia.Nombre);
                    Console.WriteLine("EL CODIGO POSTAL DE LA COLONIA ES: " + usuario.Direccion.Colonia.CodigoPostal);
                    Console.WriteLine("EL ID DEL MUNICIPIO ES: " + usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    Console.WriteLine("EL NOMBRE DEL MUNICIPIO ES " + usuario.Direccion.Colonia.Municipio.Nombre);
                    Console.WriteLine("EL ID DEL ESTADO ES: " + usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    Console.WriteLine("EL NOMBRE DEL ESTADO ES: " + usuario.Direccion.Colonia.Municipio.Estado.Nombre);
                    Console.WriteLine("EL ID DEL PAIS ES: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    Console.WriteLine("EL NOMBRE DEL PAIS ES: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre);
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
            Console.WriteLine("COLOCA EL ID DEL USUARIO A VISUALIZAR");
            int IdUsuario = int.Parse(Console.ReadLine());

            //ACTUALIZAR BYID
            //ML.Result result = BL.Usuario.GetById(IdUsuario);

            //ACTUALIZAR BYID CON SP
            //ML.Result result = BL.Usuario.GetByIdSP(IdUsuario);

            //ACTUALIZAR BYID YA CON ENTITY FRAMEWORK
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);

            //ACTUALIZAR BYID YA CON ENTITY FRAMEWORK
            //ML.Result result = BL.Usuario.GetByIdLINQ(IdUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object; //unboxing

                Console.WriteLine("EL ID DEL USUARIO ES: " + usuario.IdUsuario);
                Console.WriteLine("EL USERNAME DEL USUARIO ES: " + usuario.UserName);
                Console.WriteLine("EL NOMBRE DEL USUARIO ES: " + usuario.Nombre);
                Console.WriteLine("EL APELLIDO PATERNO DEL USUARIO ES: " + usuario.ApellidoPaterno);
                Console.WriteLine("EL APELLIDO MATERNO DEL USUARIO ES: " + usuario.ApellidoMaterno);
                Console.WriteLine("LA CONTRASEÑA DEL USUARIO ES: " + usuario.Password);
                Console.WriteLine("LA FECHA DE NACIMIENTO DEL USUARIO ES: " + usuario.FechaNacimiento);
                Console.WriteLine("EL SEXO DEL USUARIO ES: " + usuario.Sexo);
                Console.WriteLine("EL TELEFONO DEL USUARIO ES: " + usuario.Telefono);
                Console.WriteLine("EL CELULAR DEL USUARIO ES: " + usuario.Celular);
                Console.WriteLine("LA CURP DEL USUARIO ES: " + usuario.CURP);
                Console.WriteLine("EL NUMERO DE ROL DEL USUARIO ES: " + usuario.Rol.IdRol);
                Console.WriteLine("EL NOMBRE DE ROL DEL USUARIO ES: " + usuario.Rol.Nombre);
                Console.WriteLine("EL ID DE LA DIRECCION ES: " + usuario.Direccion.IdDireccion);
                Console.WriteLine("LA CALLE DE LA DIRECCION ES: " + usuario.Direccion.Calle);
                Console.WriteLine("EL NUMERO INTERIOR DE LA DIRECCION ES: " + usuario.Direccion.NumeroInterior);
                Console.WriteLine("EL NUMERO EXTERIOR DE LA DIRECCION ES: " + usuario.Direccion.NumeroExterior);
                Console.WriteLine("EL ID DE LA COLONIA ES: " + usuario.Direccion.Colonia.IdColonia);
                Console.WriteLine("EL NOMBRE DE LA COLONIA ES: " + usuario.Direccion.Colonia.Nombre);
                Console.WriteLine("EL CODIGO POSTAL DE LA COLONIA ES: " + usuario.Direccion.Colonia.CodigoPostal);
                Console.WriteLine("EL ID DEL MUNICIPIO ES: " + usuario.Direccion.Colonia.Municipio.IdMunicipio);
                Console.WriteLine("EL NOMBRE DEL MUNICIPIO ES " + usuario.Direccion.Colonia.Municipio.Nombre);
                Console.WriteLine("EL ID DEL ESTADO ES: " + usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                Console.WriteLine("EL NOMBRE DEL ESTADO ES: " + usuario.Direccion.Colonia.Municipio.Estado.Nombre);
                Console.WriteLine("EL ID DEL PAIS ES: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                Console.WriteLine("EL NOMBRE DEL PAIS ES: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre);
                Console.WriteLine("----------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("OCURRIO UN ERROR " + result.ErrorMessage);
            }
        }



    }

}
