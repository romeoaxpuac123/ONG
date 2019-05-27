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
    public partial class RegistroBeneficiario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (EXistePrivado(TextBox1.Text) == true)
            {
                InsetarBeneficiario(CodigoPrivado(TextBox1.Text), TextBox2.Text, TextBox3.Text, TextBox4.Text);
                MessageBox.Show("INFORMACIÓN REGISTRADA");
            }
            else
            {
                MessageBox.Show("NO EXISTE EL PRIVADO EN LA BD");
            }
        }
        public int CodigoPrivado(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEPRIVADO2"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            comxx.ExecuteNonQuery();
            SqlDataReader readerxx = comxx.ExecuteReader();
            if (readerxx.HasRows)
            {
                while (readerxx.Read())
                {
                    return readerxx.GetInt32(0);

                }
            }
            conxx.Close();
            return 1;
        }
        public Boolean EXistePrivado(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEPRIVADO2"; //Stored Procedure Name
            comxx.Parameters.Add("@NOMBRE", SqlDbType.NVarChar).Value = Nombre;
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
        public void InsetarBeneficiario(int Privado, String Beneficiario,
            string telefono, string direccion)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "INSERTARBENEFICIARIO"; //Stored Procedure Name
            comxx.Parameters.Add("@CODIGO_PRIVADO", SqlDbType.NVarChar).Value = Privado;
            comxx.Parameters.Add("@NOMBRE_BENEFICIARIO", SqlDbType.NVarChar).Value = Beneficiario;
            comxx.Parameters.Add("@DIRECCION ", SqlDbType.NVarChar).Value = telefono;
            comxx.Parameters.Add("@TELEFONO ", SqlDbType.NVarChar).Value = direccion;
        comxx.ExecuteNonQuery();
            conxx.Close();
        }

    }
}