﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class UsuarioNegocio
    {
            public void eliminar(int id)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearQuery("delete from Usuarios where id =" + id);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public bool verificar(Usuario usuario)
            {
                AccesoDatos datos = new AccesoDatos();
  
                try
                {
               
                datos.setearQuery("select Count(nombreDeUsuario) from Usuarios where nombreDeUsuario = @nombreDeUsuario");
                datos.agregarParametro("@nombreDeUsuario", usuario.nombreDeUsuario);
                datos.conexion.Open();
                Int32 count = Convert.ToInt32(datos.comando.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }




            }

                catch (Exception ex)
                {
                    throw ex;
                }
            
            }

        public bool verificarlogin(string nombreUsuario , string clave )
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearQuery("select clave from Usuarios where nombreDeUsuario = @nombreDeUsuario");
                datos.agregarParametro("@nombreDeUsuario", nombreUsuario);
                datos.agregarParametro("@clave", clave);
                datos.conexion.Open();
               
                    var resultado = datos.comando.ExecuteScalar();
                if (resultado != DBNull.Value && resultado != null)
                {
                    string password = Convert.ToString(resultado);
                    if (password == clave)
                    {
                        return true;
                    }

                }


                return false;

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int obteneridPorSession(string nombreDeUsuario)
        {
           

            AccesoDatos datos = new AccesoDatos();
            try
            {
                int resultado;

                datos.setearQuery("select id from Usuarios where nombreDeUsuario = @nombreDeUsuario");
                datos.agregarParametro("@nombreDeUsuario", nombreDeUsuario);
                datos.ejecutarLector();
                datos.lector.Read();
                resultado = datos.lector.GetInt32(0);



                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }



        }

        public int obteneridVendedor(int idPublicacion)
        {
            

            AccesoDatos datos = new AccesoDatos();
            try
            {
                int resultado;

                datos.setearQuery("select idUsuario from Publicaciones where id = @id");
                datos.agregarParametro("@id", idPublicacion);
                datos.ejecutarLector();
                datos.lector.Read();
                resultado = datos.lector.GetInt32(0);



                return resultado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }


          
        }

      
        public void logearUsuario(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearQuery("Update Usuarios set estado=@estado Where id=@Id");
                datos.agregarParametro("@estado", true);
                datos.agregarParametro("@Id", id);

                datos.ejecutarAccion();

               
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

      





        public void agregar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {               
                        datos.setearQuery("insert into Usuarios (nombreDeUsuario,clave,dni,nombre,apellido,email,telefono,estado)values(@nombreDeUsuario,@clave,@dni,@nombre,@apellido,@email,@telefono,@estado)");
                        datos.agregarParametro("@nombreDeUsuario", usuario.nombreDeUsuario);
                        datos.agregarParametro("clave", usuario.clave);
                        datos.agregarParametro("@dni", usuario.dni);
                        datos.agregarParametro("@nombre", usuario.nombre);
                        datos.agregarParametro("@apellido", usuario.apellido);
                        datos.agregarParametro("@email", usuario.email);
                        datos.agregarParametro("@telefono", usuario.nroTelefono);
                        datos.agregarParametro("@estado", false);
                        datos.ejecutarAccion();
                 
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Usuario Usuario)
            {
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearQuery("Update Usuarios set nombre=@Nombre Where id=@Id");
                    datos.agregarParametro("@Nombre", Usuario.nombre);
                    datos.agregarParametro("@Id", Usuario.id);

                    datos.ejecutarAccion();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public void cerrarSesion(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Update Usuarios set estado=0 Where id=@Id");
                datos.agregarParametro("@Id", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> listarPorNombre(string nombre)
            {
                List<Usuario> lista = new List<Usuario>();
                Usuario aux;
                AccesoDatos datos = new AccesoDatos();
                try
                {
                    datos.setearQuery("SELECT * FROM Usuarios where nombreDeUsuario = @nombreDeUsuario");
                    datos.agregarParametro("@nombreDeUsuario", nombre);
                    datos.ejecutarLector();
                    while (datos.lector.Read())
                    {
                        aux = new Usuario();
                        aux.id = datos.lector.GetInt32(0);
                        aux.nombreDeUsuario = datos.lector.GetString(1);
                        aux.clave = datos.lector.GetString(2);
                        aux.nombre = datos.lector.GetString(3);
                        aux.apellido = datos.lector.GetString(4);
                        aux.email = datos.lector.GetString(5);
                        aux.nroTelefono = datos.lector.GetInt32(6);
                        aux.estado = datos.lector.GetBoolean(7);

                        lista.Add(aux);
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                    datos = null;
                }

            }
        }
    }

