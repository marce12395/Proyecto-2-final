using Proyecto_2_final.CapaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Cliente
    {
        public void AgregarCliente(int usuarioID, string nombre, string correo, string telefono)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "INSERT INTO Cliente (UsuarioID, Nombre, CorreoElectronico, Telefono) VALUES (@id, @nombre, @correo, @telefono)", conexion))
            {
                comando.Parameters.AddWithValue("@id", usuarioID);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@telefono", telefono);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public DataTable ConsultarClientes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "SELECT UsuarioID, Nombre, CorreoElectronico, Telefono FROM Cliente", conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    
        public void ModificarCliente(int usuarioID, string nombre, string correo, string telefono)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Cliente SET Nombre=@nombre, CorreoElectronico=@correo, Telefono=@telefono WHERE UsuarioID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", usuarioID);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@telefono", telefono);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        
        public void EliminarCliente(int usuarioID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("DELETE FROM Cliente WHERE UsuarioID=@id", conexion))
            {
                comando.Parameters.AddWithValue("@id", usuarioID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


     
    }
}