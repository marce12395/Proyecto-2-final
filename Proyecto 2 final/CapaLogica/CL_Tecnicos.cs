using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_2_final.CapaLogica
{
    public class CL_Tecnicos
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

  
        public void AgregarTecnico(string nombre, string especialidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tecnicos (Nombre, Especialidad) VALUES (@nombre, @especialidad)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@especialidad", especialidad);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

       
        public void ModificarTecnico(int tecnicoID, string nombre, string especialidad)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tecnicos SET Nombre=@nombre, Especialidad=@especialidad WHERE TecnicoID=@tecnicoID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@tecnicoID", tecnicoID);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@especialidad", especialidad);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

    
        public void EliminarTecnico(int tecnicoID)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tecnicos WHERE TecnicoID=@tecnicoID";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@tecnicoID", tecnicoID);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }


        public DataTable ConsultarTecnicos()
        {
            var dt = new DataTable();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("SELECT TecnicoID, Nombre, Especialidad FROM Tecnicos", conexion))
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
            }
            return dt;
        }
    }
}