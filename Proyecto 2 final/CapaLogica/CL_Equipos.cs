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
    public class CL_Equipos
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

      
        public void AgregarEquipo(int usuarioID, string tipo, string modelo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Equipos (UsuarioID, Tipo, Modelo) VALUES (@usuarioID, @tipo, @modelo)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@usuarioID", usuarioID);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@modelo", modelo);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

  
        public void ModificarEquipo(int equipoID, int usuarioID, string tipo, string modelo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Equipos SET UsuarioID=@usuarioID, Tipo=@tipo, Modelo=@modelo WHERE EquipoID=@equipoID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@equipoID", equipoID);
                comando.Parameters.AddWithValue("@usuarioID", usuarioID);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@modelo", modelo);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarEquipo(int equipoID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Equipos WHERE EquipoID=@equipoID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@equipoID", equipoID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

       
        public DataTable ConsultarEquipos()
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT EquipoID, UsuarioID, Tipo, Modelo FROM Equipos", conexion))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }
    }
}