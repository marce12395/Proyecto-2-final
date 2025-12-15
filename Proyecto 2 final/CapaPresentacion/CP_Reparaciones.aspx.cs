using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Reparaciones : System.Web.UI.Page
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
                var cl = new CL_Reparaciones();
                gvreparaciones.DataSource = cl.ConsultarReparaciones();
                gvreparaciones.DataBind();
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
                if (!int.TryParse(txtequipo.Text.Trim(), out int equipoID))
                {
                    lblMensaje.Text = "El EquipoID debe ser un número válido.";
                    return;
                }

                if (!DateTime.TryParse(fechaS.Text.Trim(), out DateTime fechaSolicitud))
                {
                    lblMensaje.Text = "La fecha de solicitud no es válida.";
                    return;
                }

                var cl = new CL_Reparaciones();
                cl.AgregarReparacion(equipoID, fechaSolicitud, txtestado.Text.Trim());

                lblMensaje.Text = "Reparación agregada correctamente.";
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
                if (!int.TryParse(txtreparacionID.Text.Trim(), out int reparacionID) ||
                    !int.TryParse(txtequipo.Text.Trim(), out int equipoID))
                {
                    lblMensaje.Text = "Los IDs deben ser números válidos.";
                    return;
                }

                if (!DateTime.TryParse(fechaS.Text.Trim(), out DateTime fechaSolicitud))
                {
                    lblMensaje.Text = "La fecha de solicitud no es válida.";
                    return;
                }

                var cl = new CL_Reparaciones();
                cl.ModificarReparacion(reparacionID, equipoID, fechaSolicitud, txtestado.Text.Trim());

                lblMensaje.Text = "Reparación modificada correctamente.";
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
                if (!int.TryParse(txtreparacionID.Text.Trim(), out int reparacionID))
                {
                    lblMensaje.Text = "El ReparacionID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Reparaciones();
                cl.EliminarReparacion(reparacionID);

                lblMensaje.Text = "Reparación eliminada correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }
    }
}