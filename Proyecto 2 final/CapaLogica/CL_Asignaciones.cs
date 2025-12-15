using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Asignaciones
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

     
        public void AgregarAsignacion(int reparacionID, int tecnicoID, DateTime fechaAsignacion)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES (@reparacionID, @tecnicoID, @fechaAsignacion)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                comando.Parameters.AddWithValue("@tecnicoID", tecnicoID);
                comando.Parameters.AddWithValue("@fechaAsignacion", fechaAsignacion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

      
        public void ModificarAsignacion(int asignacionID, int reparacionID, int tecnicoID, DateTime fechaAsignacion)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Asignaciones SET ReparacionID=@reparacionID, TecnicoID=@tecnicoID, FechaAsignacion=@fechaAsignacion WHERE AsignacionID=@asignacionID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@asignacionID", asignacionID);
                comando.Parameters.AddWithValue("@reparacionID", reparacionID);
                comando.Parameters.AddWithValue("@tecnicoID", tecnicoID);
                comando.Parameters.AddWithValue("@fechaAsignacion", fechaAsignacion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

   
        public void EliminarAsignacion(int asignacionID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Asignaciones WHERE AsignacionID=@asignacionID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@asignacionID", asignacionID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

    
        public DataTable ConsultarAsignaciones()
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(
                "SELECT a.AsignacionID, a.FechaAsignacion, r.ReparacionID, t.TecnicoID, t.Nombre, t.Especialidad " +
                "FROM Asignaciones a " +
                "INNER JOIN Reparaciones r ON a.ReparacionID = r.ReparacionID " +
                "INNER JOIN Tecnicos t ON a.TecnicoID = t.TecnicoID", conexion))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }
    }
}