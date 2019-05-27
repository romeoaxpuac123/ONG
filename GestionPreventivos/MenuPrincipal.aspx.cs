using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GestionPreventivos
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Codigo_Usuario"] == null)
            {
                Response.Redirect("INICIO.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("RegistroPrivado.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("RegistroDelito.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("RegistroCentroPreventivo.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("InformeDeProceso.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("Beneficiado.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AREA EN PROCESO");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("Proceso.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Session["Codigo_Usuario"] = "MILTON";
            Response.Redirect("Beneficiado.aspx");
        }
    }
}