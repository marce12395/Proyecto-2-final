using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Asignaciones : System.Web.UI.Page
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
                var cl = new CL_Asignaciones();
                gvTecnicos.DataSource = cl.ConsultarAsignaciones();
                gvTecnicos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al consultar: " + ex.Message;
            }
        }

        protected void btnModificar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int asignacionID) ||
                    !int.TryParse(txtNombre.Text.Trim(), out int reparacionID) ||
                    !int.TryParse(txtCorreo.Text.Trim(), out int tecnicoID))
                {
                    lblMensaje.Text = "Los IDs deben ser números válidos.";
                    return;
                }

                if (!DateTime.TryParse(fechaA.Text.Trim(), out DateTime fechaAsignacion))
                {
                    lblMensaje.Text = "La fecha de asignación no es válida.";
                    return;
                }

                var cl = new CL_Asignaciones();
                cl.ModificarAsignacion(asignacionID, reparacionID, tecnicoID, fechaAsignacion);

                lblMensaje.Text = "Asignación modificada correctamente.";
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
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int asignacionID))
                {
                    lblMensaje.Text = "El AsignacionID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Asignaciones();
                cl.EliminarAsignacion(asignacionID);

                lblMensaje.Text = "Asignación eliminada correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNombre.Text.Trim(), out int reparacionID) ||
                    !int.TryParse(txtCorreo.Text.Trim(), out int tecnicoID))
                {
                    lblMensaje.Text = "Los IDs deben ser números válidos.";
                    return;
                }

                if (!DateTime.TryParse(fechaA.Text.Trim(), out DateTime fechaAsignacion))
                {
                    lblMensaje.Text = "La fecha de asignación no es válida.";
                    return;
                }

                var cl = new CL_Asignaciones();
                cl.AgregarAsignacion(reparacionID, tecnicoID, fechaAsignacion);

                lblMensaje.Text = "Asignación agregada correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
            }
        }
    }
}