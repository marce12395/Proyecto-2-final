using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Reparaciones
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public void AgregarReparacion(int equipoID, DateTime fechaSolicitud, string estado)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES (@equipoID, @fechaSolicitud, @estado)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@equipoID", equipoID);
                comando.Parameters.AddWithValue("@fechaSolicitud", fechaSolicitud);
                comando.Parameters.AddWithValue("@estado", estado);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarReparacion(int reparacionID, int equipoID, DateTime fechaSolicitud, string estado)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Reparaciones SET EquipoID=@equipoID, FechaSolicitud=@fechaSolicitud, Estado=@estado WHERE ReparacionID=@reparacionID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                comando.Parameters.AddWithValue("@equipoID", equipoID);
                comando.Parameters.AddWithValue("@fechaSolicitud", fechaSolicitud);
                comando.Parameters.AddWithValue("@estado", estado);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public void EliminarReparacion(int reparacionID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Reparaciones WHERE ReparacionID=@reparacionID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

   
        public DataTable ConsultarReparaciones()
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT ReparacionID, EquipoID, FechaSolicitud, Estado FROM Reparaciones", conexion))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }
    }
}