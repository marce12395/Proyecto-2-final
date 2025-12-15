using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_2_final
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioNombre"] != null)
            {
                Lbnombre.Text = "Bienvenido/a, " + Session["UsuarioNombre"].ToString();
            }
            else
            {
                Response.Redirect("inicio.aspx");
            }
        }



        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}