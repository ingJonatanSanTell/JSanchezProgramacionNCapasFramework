using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Globalization;

namespace BL
{
    static public class Usuario
    {
        //AGREGAR ADD CON ENTITY FRAMEWORK
        static public ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL INSERTAR EL USUARIO";
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
        static public ML.Result DeleteEF(int IdUsuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ELIMINAR EL USUARIO";
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
        static public ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ACTUALIZAR EL USUARIO";
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
        static public ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll().ToList();


                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var objUsuario in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            ML.Rol rol = new ML.Rol();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.NombreUsuario;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.Email = objUsuario.Email;
                            usuario.Password = objUsuario.Password;
                            usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Sexo = objUsuario.Sexo;
                            usuario.Telefono = objUsuario.Telefono;
                            usuario.Celular = objUsuario.Celular;
                            usuario.CURP = objUsuario.CURP;
                            //rol
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = objUsuario.IdRol;
                            usuario.Rol.Nombre = objUsuario.NombreRol;
                            //direccion
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                            usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                            usuario.Direccion.NumeroExterior = objUsuario.NumeroInterior;
                            //colonia
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                            //munucipio
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;
                            //estado
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;
                            //pais
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;

                            result.Objects.Add(usuario);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA USUARIO NO TIENE DATOS";
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
        static public ML.Result GetByIdEF(int IdUsuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetById(IdUsuario).Single();


                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.NombreUsuario;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        //rol
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol;
                        usuario.Rol.Nombre = objUsuario.NombreRol;
                        //direccion
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroInterior;
                        //colonia
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = objUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;
                        //munucipio
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;
                        //estado
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.NombreEstado;
                        //pais
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.NombrePais;


                        result.Object = usuario; //BOXING
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA USUARIO NO TIENE DATOS";
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

        //GETALL CON LINQ
        static public ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = (from usuarios in context.Usuarios select usuarios).ToList();


                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var objUsuario in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.Nombre;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.Email = objUsuario.Email;
                            usuario.Password = objUsuario.Password;
                            usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy HH-mm-ssss");
                            usuario.Sexo = objUsuario.Sexo;
                            usuario.Telefono = objUsuario.Telefono;
                            usuario.Celular = objUsuario.Celular;
                            usuario.CURP = objUsuario.CURP;
                            usuario.Rol.IdRol = usuario.Rol.IdRol;


                            result.Objects.Add(usuario);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA USUARIO NO TIENE DATOS";
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

        //GETBYID CON LINQ
        static public ML.Result GetByIdLINQ(int IdUsuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {

                    var objUsuario = (from usuarios in context.Usuarios where usuarios.IdUsuario == IdUsuario select usuarios).Single();


                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy HH-mm-ssss");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;
                        usuario.Rol.IdRol = usuario.Rol.IdRol;


                        result.Object = usuario; //BOXING
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR LA TABLA USUARIO NO TIENE DATOS";
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

        //ADD CON LINQ
        static public ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {

                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Nombre = usuario.Nombre;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.CURP = usuario.CURP;
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;



                    context.Usuarios.Add(usuarioLINQ);

                    context.SaveChanges();

                    result.Correct = true;
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

        //DELETE CON LINQ
        static public ML.Result DeleteLINQ(int IdUsuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = (from usuarios in context.Usuarios where usuarios.IdUsuario == IdUsuario select usuarios).First();

                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ELIMINAR EL USUARIO";
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

        //UPDATE CON LINQ
        static public ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JSanchezProgramacionNCapasEntities context = new DL_EF.JSanchezProgramacionNCapasEntities())
                {
                    var query = (from usuarios in context.Usuarios where usuarios.IdUsuario == usuario.IdUsuario select usuarios).SingleOrDefault();

                    if (query != null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        int rowAffect = context.SaveChanges();
                        if (rowAffect > 0)
                        {
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ACTUALIZAR EL USUARIO";
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

        //AGREGAR ADD
        static public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "INSERT INTO [Usuario]([UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[Password],[FechaNacimiento],[Sexo],[Telefono],[Celular],[CURP])VALUES(@UserName,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@Password,@FechaNacimiento,@Sexo,@Telefono,@Celular,@CURP)";

                    SqlParameter[] collection = new SqlParameter[11];
                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.VarChar);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;



                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL INSERTAR";
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

        //ELIMINAR DELETE
        static public ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ELIMINAR";
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

        //ACTUALIZAR UPDATE
        static public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UPDATE [Usuario] SET [UserName] = @UserName,[Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Email] = @Email,[Password] = @Password,[FechaNacimiento] = @FechaNacimiento,[Sexo] = @Sexo,[Telefono] = @Telefono,[Celular] = @Celular,[CURP] = @CURP WHERE [IdUsuario] = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[12];
                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.VarChar);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;
                    collection[11] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[11].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ACTUALIZAR";
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

        //GETALL
        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdUsuario],[UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[Password],[FechaNacimiento],[Sexo],[Telefono],[Celular],[CURP] FROM [Usuario]";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();


                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "LA TABLA USUARIO NO CONTIENE DATOS";
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

        //GETBYID
        static public ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdUsuario],[UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[Password],[FechaNacimiento],[Sexo],[Telefono],[Celular],[CURP] FROM [Usuario] WHERE IdUsuario = @IdUsuario ";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {

                        DataRow row = usuarioTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.UserName = row[1].ToString();
                        usuario.Nombre = row[2].ToString();
                        usuario.ApellidoPaterno = row[3].ToString();
                        usuario.ApellidoMaterno = row[4].ToString();
                        usuario.Email = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.FechaNacimiento = row[7].ToString();
                        usuario.Sexo = row[8].ToString();
                        usuario.Telefono = row[9].ToString();
                        usuario.Celular = row[10].ToString();
                        usuario.CURP = row[11].ToString();

                        result.Object = usuario; //BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "LA TABLA USUARIO NO CONTIENE DATOS CON ESE ID";
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

        //GETALL CON SP
        static public ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento = row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();


                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "LA TABLA USUARIO NO CONTIENE DATOS";
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

        //GETBYID CON SP
        static public ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioGetById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {

                        DataRow row = usuarioTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.UserName = row[1].ToString();
                        usuario.Nombre = row[2].ToString();
                        usuario.ApellidoPaterno = row[3].ToString();
                        usuario.ApellidoMaterno = row[4].ToString();
                        usuario.Email = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.FechaNacimiento = row[7].ToString();
                        usuario.Sexo = row[8].ToString();
                        usuario.Telefono = row[9].ToString();
                        usuario.Celular = row[10].ToString();
                        usuario.CURP = row[11].ToString();

                        result.Object = usuario; //BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "LA TABLA USUARIO NO CONTIENE DATOS CON ESE ID";
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

        //AGREGAR ADD CON SP
        static public ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UsuarioAdd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[11];
                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.VarChar);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;



                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL INSERTAR";
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

        //ELIMINAR DELETE
        static public ML.Result DeleteSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ELIMINAR";
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

        //ACTUALIZAR UPDATE
        static public ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[12];
                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.VarChar);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;
                    collection[11] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[11].Value = usuario.IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "OCURRIO UN ERROR AL ACTUALIZAR";
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
