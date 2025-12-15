using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

       
        private void LlenarGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT UsuarioID, Nombre, CorreoElectronico, Telefono FROM Cliente", conexion))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvClientes.DataSource = dt;
                gvClientes.DataBind();
            }
        }

        
           

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int usuarioID))
                {
                    lblMensaje.Text = "El UsuarioID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Cliente();
                cl.AgregarCliente(usuarioID, txtNombre.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim());
                lblMensaje.Text = "Cliente agregado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
            }

        }


        protected void btnModificar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int usuarioID))
                {
                    lblMensaje.Text = "El UsuarioID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Cliente();
                cl.ModificarCliente(usuarioID, txtNombre.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim());
                lblMensaje.Text = "Cliente modificado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar: " + ex.Message;
            }

        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int usuarioID))
                {
                    lblMensaje.Text = "El UsuarioID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Cliente();
                cl.EliminarCliente(usuarioID);
                lblMensaje.Text = "Cliente eliminado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }

        }
    }
}