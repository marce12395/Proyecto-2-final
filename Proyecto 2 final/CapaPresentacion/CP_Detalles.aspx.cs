using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final.CapaPresentacion
{
    public partial class CP_Detalles : System.Web.UI.Page
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
                var cl = new CL_Detalle();
                gvTecnicos.DataSource = cl.ConsultarTodos();
                gvTecnicos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al consultar: " + ex.Message;
            }
        }
     
     
       

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNombre.Text.Trim(), out int reparacionID))
                {
                    lblMensaje.Text = "El ReparacionID debe ser un número válido.";
                    return;
                }

                if (!DateTime.TryParse(fechaI.Text.Trim(), out DateTime fechaInicio))
                {
                    lblMensaje.Text = "La fecha de inicio no es válida.";
                    return;
                }

                DateTime? fechaFin = null;
                if (DateTime.TryParse(fechaE.Text.Trim(), out DateTime fechaEntrega))
                {
                    fechaFin = fechaEntrega;
                }

                var cl = new CL_Detalle();
                cl.AgregarDetalle(reparacionID, txtdescripcion.Text.Trim(), fechaInicio, fechaFin);

                lblMensaje.Text = "Detalle agregado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int detalleID) ||
                    !int.TryParse(txtNombre.Text.Trim(), out int reparacionID))
                {
                    lblMensaje.Text = "Los IDs deben ser números válidos.";
                    return;
                }

                if (!DateTime.TryParse(fechaI.Text.Trim(), out DateTime fechaInicio))
                {
                    lblMensaje.Text = "La fecha de inicio no es válida.";
                    return;
                }

                DateTime? fechaFin = null;
                if (DateTime.TryParse(fechaE.Text.Trim(), out DateTime fechaEntrega))
                {
                    fechaFin = fechaEntrega;
                }

                var cl = new CL_Detalle();
                cl.ModificarDetalle(detalleID, reparacionID, txtdescripcion.Text.Trim(), fechaInicio, fechaFin);

                lblMensaje.Text = "Detalle modificado correctamente.";
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
                if (!int.TryParse(txtUsuarioID.Text.Trim(), out int detalleID))
                {
                    lblMensaje.Text = "El DetalleID debe ser un número válido.";
                    return;
                }

                var cl = new CL_Detalle();
                cl.EliminarDetalle(detalleID);

                lblMensaje.Text = "Detalle eliminado correctamente.";
                LlenarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }
        }
    }
}