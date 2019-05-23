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
    public partial class InformeDeProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (EXistePrivado(TextBox1.Text) == false)
            {
                MessageBox.Show("NO EXISTE EL PRIVADO");
            }
            else
            {
                if ((TextBox1.Text == "") || (TextBox2.Text == "") || (TextBox3.Text == "") || (TextBox4.Text == "") || TextBox5.Text == "")
                {
                    MessageBox.Show("DATOS INCORRECTOS");

                }
                else
                {
                    RegistrarProceso(CodigoDelito(ListBox1.Text), CodigoPrivado(TextBox1.Text),
                        TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);

                    InsertarPena(CodigoPrivado(TextBox1.Text), TextBox2.Text, TextBox6.Text,
                        TextBox7.Text, TextBox8.Text);
                    MessageBox.Show("DATOS REGISTRADOS");
                }
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
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
        public void RegistrarProceso(int DELITO,int PRIVADO, String EXPEDIENTE,String EJECUTORIA, String JUZGADO, String SALA)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "INSERTARINFORME"; //Stored Procedure Name
            comxx.Parameters.Add("@DELITO ", SqlDbType.NVarChar).Value = DELITO;
            comxx.Parameters.Add("@EXPEDIENTE", SqlDbType.NVarChar).Value = EXPEDIENTE;
            comxx.Parameters.Add("@PRIVADO", SqlDbType.NVarChar).Value = PRIVADO;
            comxx.Parameters.Add("@EJECUTORIA ", SqlDbType.NVarChar).Value = EJECUTORIA;
            comxx.Parameters.Add("@JUZGADO", SqlDbType.NVarChar).Value = JUZGADO;
            comxx.Parameters.Add("@SALA", SqlDbType.NVarChar).Value = SALA;
            comxx.ExecuteNonQuery();
            conxx.Close();

        }
        public int CodigoDelito(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEDEL"; //Stored Procedure Name
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
        public void InsertarPena(int PRIVADO, String EXPEDIENTE, String PRISION, String MULTA, String TIEMPOCUMPLIDO)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "INSERTARPENA"; //Stored Procedure Name
            comxx.Parameters.Add("@PRIVADO", SqlDbType.NVarChar).Value = PRIVADO;
            comxx.Parameters.Add("@EXPEDIENTE", SqlDbType.NVarChar).Value = EXPEDIENTE;
            comxx.Parameters.Add("@PRISION", SqlDbType.NVarChar).Value = PRISION;
            comxx.Parameters.Add("@MULTA ", SqlDbType.NVarChar).Value = MULTA;
            comxx.Parameters.Add("@TIEMPOCUMPLIDO", SqlDbType.NVarChar).Value = TIEMPOCUMPLIDO;
            comxx.ExecuteNonQuery();
            conxx.Close();
        }
    }
}