using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GestionPreventivos
{
    public partial class RegistroCentroPreventivo : System.Web.UI.Page
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
            if (ExistenciaSede((TextBox1.Text)) == false)
            {
                RegistrarSede(TextBox1.Text, TextBox2.Text);
                MessageBox.Show(TextBox1.Text + " Registrado");
                TextBox2.Text = "";
                TextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("DELITO PREVIAMENTE REGISTRADO");
                TextBox2.Text = "";
                TextBox1.Text = "";
            }
        }
        public Boolean ExistenciaSede(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTECP"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            comxx.ExecuteNonQuery();
            String Resultado = "";
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    Resultado = readerxx.GetString(1);
                    break;
                }
            }
            conxx.Close();
            if (Resultado != "")
            {
                return true;
            }

            return false;
        }

        public void RegistrarSede(String nombre, String direccion)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "NUEVOCP"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = nombre;
            comxx.Parameters.Add("@DIRECCION", SqlDbType.NVarChar).Value = direccion;
            comxx.ExecuteNonQuery();
            conxx.Close();
        }
    }
}