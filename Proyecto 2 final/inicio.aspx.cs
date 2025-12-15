using Proyecto_2_final.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


       
        

        protected void bingresar_Click1(object sender, EventArgs e)
        {
            int existe = CL_Usuario.ValidarUsuario(tusuario.Text.Trim(), tclave.Text.Trim());

            if (existe == 1)
            {

                Session["UsuarioNombre"] = CapaDatos.CD_Usuario.nombre;

                Response.Redirect("Principal.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o clave incorrectos.";
            }

        }

        protected void bagregar_Click(object sender, EventArgs e)
        {
            try
            {
                var cl = new CL_Usuario();
                cl.AgregarUsuario(tusuario.Text.Trim(), tclave.Text.Trim(), tnombre.Text.Trim());
                lblMensaje.Text = "Usuario agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
            }

        }

        protected void beliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var cl = new CL_Usuario();
                cl.EliminarUsuarioPorCorreo(tusuario.Text.Trim());
                lblMensaje.Text = "Usuario eliminado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar: " + ex.Message;
            }

        }
    }
}