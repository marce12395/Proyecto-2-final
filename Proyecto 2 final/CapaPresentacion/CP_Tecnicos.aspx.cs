using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Tecnicos : System.Web.UI.Page
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
                var cl = new CL_Tecnicos();
                gvTecnicos.DataSource = cl.ConsultarTecnicos();
                gvTecnicos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al consultar: " + ex.Message;
            }
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {
                var cl = new CL_Tecnicos();
                cl.AgregarTecnico(txtNombre.Text.Trim(), txtCorreo.Text.Trim());

                lblMensaje.Text = "Técnico agregado correctamente.";
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
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int tecnicoID))
                {
                    lblMensaje.Text = "El TecnicoID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Tecnicos();
                cl.ModificarTecnico(tecnicoID, txtNombre.Text.Trim(), txtCorreo.Text.Trim());

                lblMensaje.Text = "Técnico modificado correctamente.";
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
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int tecnicoID))
                {
                    lblMensaje.Text = "El TecnicoID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Tecnicos();
                cl.EliminarTecnico(tecnicoID);

                lblMensaje.Text = "Técnico eliminado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }
    }
}