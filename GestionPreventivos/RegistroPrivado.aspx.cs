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
    public partial class RegistroPrivado : System.Web.UI.Page
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
            DateTime thisDay = DateTime.Today;
            if (ExisteUsuario(TextBox1.Text, CodigoCentroCarcelario(ListBox1.Text))==false)
            {

                if (ListBox2.Text == "FICHA" || ListBox3.Text == "COMPUTO")
                {
                    MessageBox.Show("SELECCIONE CORRECTAMENTE FICHA O COMPUTO");
                }
                else
                {
                    InsertarPrivado(NumeroExpediente(CodigoCentroCarcelario(ListBox1.Text), thisDay.Year),
                   thisDay.Year, TextBox1.Text, TextBox2.Text, TextBox3.Text, CodigoCentroCarcelario(ListBox1.Text),
                   ListBox2.Text, ListBox3.Text);

                    MessageBox.Show("PRIVADO REGISTRADO");
                }
            }
            else
            {
                MessageBox.Show("ERROR PRIVADO YA EXISTE");
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            ListBox1.DataBind();
            ListBox2.DataBind();
            ListBox3.DataBind();
            Response.Redirect("RegistroPrivado.aspx");

        }

        public int CodigoCentroCarcelario(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "CODIGOSEDE"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = Nombre; comxx.ExecuteNonQuery();
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    return readerxx.GetInt32(0);

                }
            }
            return 1;
        }
        public int NumeroExpediente(int CentroCarcelario, int anio)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "TOTALEXPEDIENTES"; //Stored Procedure Name
            comxx.Parameters.Add("@ANIO", SqlDbType.NVarChar).Value = anio;
            comxx.Parameters.Add("@PREVENTIVO", SqlDbType.NVarChar).Value = CentroCarcelario;
            comxx.ExecuteNonQuery();
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    return  readerxx.GetInt32(0) + 1;
                    
                }
            }
            conxx.Close();
            return 1;
        }
        public void InsertarPrivado(int NoInicialExp, int ANIOEXP, String NOMBRE,String TELEFONO,String DIRECCION,int CPREVENTIVO, String Ficha, String Computo)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "NUEVOPRIVADO"; //Stored Procedure Name
            comxx.Parameters.Add("@NoInicialExp", SqlDbType.NVarChar).Value = NoInicialExp;
            comxx.Parameters.Add("@ANIOEXP", SqlDbType.NVarChar).Value = ANIOEXP;
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = NOMBRE;
            comxx.Parameters.Add("@TELEFONO ", SqlDbType.NVarChar).Value = TELEFONO;
            comxx.Parameters.Add("@DIRECCION", SqlDbType.NVarChar).Value = DIRECCION;
            comxx.Parameters.Add("@CPREVENTIVO", SqlDbType.NVarChar).Value = CPREVENTIVO;
            comxx.Parameters.Add("@FICHA", SqlDbType.NVarChar).Value = Ficha;
            comxx.Parameters.Add("@COMPUTO", SqlDbType.NVarChar).Value = Computo;
            comxx.ExecuteNonQuery();                
            conxx.Close();
            
        }
        public Boolean ExisteUsuario(String Nombre, int sede)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEPRIVADO"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            comxx.Parameters.Add("@CODIGOSEDE", SqlDbType.NVarChar).Value = sede;
            comxx.ExecuteNonQuery();
            SqlDataReader readerxx = comxx.ExecuteReader();
            int codigo = 0;
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    codigo = readerxx.GetInt32(0);

                }
            }
            conxx.Close();
            if (codigo > 0)
                return true;
            return false;
        }

        
    }
}