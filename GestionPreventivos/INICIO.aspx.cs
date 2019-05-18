using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GestionPreventivos
{
    public partial class INICIO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

      

        protected void Button1_Click1(object sender, EventArgs e)
        {
           if(TextBox1.Text == "MILTON" && TextBox2.Text =="MILTON")
            {
                MessageBox.Show("BIENVENIDO");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                MessageBox.Show("DATOS INCORRECTOS");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
    }
}