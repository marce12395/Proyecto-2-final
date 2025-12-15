using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Equipos : System.Web.UI.Page
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
            try
            {
                var cl = new CL_Equipos();
                gvequipo.DataSource = cl.ConsultarEquipos();
                gvequipo.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al consultar: " + ex.Message;
            }
        }

      

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int equipoID) ||
                    !int.TryParse(txtu.Text.Trim(), out int usuarioID))
                {
                    lblMensaje.Text = "Los IDs deben ser números válidos.";
                    return;
                }

                var cl = new CL_Equipos();
                cl.ModificarEquipo(equipoID, usuarioID, txtNombre.Text.Trim(), txtCorreo.Text.Trim());

                lblMensaje.Text = "Equipo modificado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int equipoID))
                {
                    lblMensaje.Text = "El EquipoID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Equipos();
                cl.EliminarEquipo(equipoID);

                lblMensaje.Text = "Equipo eliminado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtu.Text.Trim(), out int usuarioID))
                {
                    lblMensaje.Text = "El UsuarioID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Equipos();
                cl.AgregarEquipo(usuarioID, txtNombre.Text.Trim(), txtCorreo.Text.Trim());

                lblMensaje.Text = "Equipo agregado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
            }
        }
    }
}