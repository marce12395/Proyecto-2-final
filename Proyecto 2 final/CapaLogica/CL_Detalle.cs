using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Detalle
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public void AgregarDetalle(int reparacionID, string descripcion, DateTime fechaInicio, DateTime? fechaFin)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Detalle (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES (@reparacionID, @descripcion, @fechaInicio, @fechaFin)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", (object)fechaFin ?? DBNull.Value);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarDetalle(int detalleID, int reparacionID, string descripcion, DateTime fechaInicio, DateTime? fechaFin)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Detalle SET ReparacionID=@reparacionID, Descripcion=@descripcion, FechaInicio=@fechaInicio, FechaFin=@fechaFin WHERE DetalleID=@detalleID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@detalleID", detalleID);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", (object)fechaFin ?? DBNull.Value);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public void EliminarDetalle(int detalleID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Detalle WHERE DetalleID=@detalleID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@detalleID", detalleID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

       
        public DataTable ConsultarDetallesPorReparacion(int reparacionID)
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT DetalleID, ReparacionID, Descripcion, FechaInicio, FechaFin FROM Detalle WHERE ReparacionID=@reparacionID", conexion))
            {
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ConsultarTodos()
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT DetalleID, ReparacionID, Descripcion, FechaInicio, FechaFin FROM Detalle", conexion))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }
    }
}