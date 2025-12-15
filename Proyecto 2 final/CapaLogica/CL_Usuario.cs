using Proyecto_2_final.CapaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Usuario
    {
        public static int ValidarUsuario(string usuario, string clave)
        {
            CD_Usuario.Usuario = usuario;
            CD_Usuario.clave = clave;

            int existe = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT correo, clave, nombre FROM usuario WHERE correo = @correo AND clave = @clave", conexion))
            {
               
                comando.Parameters.AddWithValue("@correo", CD_Usuario.Usuario);
                comando.Parameters.AddWithValue("@clave", CD_Usuario.clave);


                conexion.Open();
                using (SqlDataReader registro = comando.ExecuteReader())
                {
                    if (registro.Read())
                    {
                        CD_Usuario.nombre = registro["nombre"].ToString();
                        existe = 1;
                    }
                }

            }
            return existe;
        }



        public void AgregarUsuario(string correo, string clave, string nombre)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("INSERT INTO Usuario (correo, clave, nombre) VALUES (@correo, @clave, @nombre)", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@clave", clave);
                comando.Parameters.AddWithValue("@nombre", nombre);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int usuarioID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("DELETE FROM Usuario WHERE UsuarioID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", usuarioID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

      
        public void EliminarUsuarioPorCorreo(string correo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("DELETE FROM Usuario WHERE correo=@correo", conexion))
            {
                comando.Parameters.AddWithValue("@correo", correo);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}