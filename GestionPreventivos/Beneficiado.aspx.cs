﻿using System;
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
    public partial class Beneficiado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (EXistePrivado(TextBox1.Text) == true)
            {
                if (ExisteExpediente(TextBox2.Text) == true)
                {
                    if (Coincidencia(CodigoPrivado(TextBox1.Text), TextBox2.Text))
                    {

                        InsetarBenefcio(CodigoPrivado(TextBox1.Text), TextBox2.Text, TextBox3.Text,
                            TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text);
                        MessageBox.Show("DATOS REGISTRADOS");
                    }
                    else
                    {
                        MessageBox.Show("LOS DATOS NO COINCIDEN");
                    }
                    
                }
                else
                {
                    MessageBox.Show("NO EXITE EL EXPEDIENTE");
                }
            }
            else
            {
                MessageBox.Show("NO EXISTE EL USUARIO");
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
        public Boolean ExisteExpediente(String Nombre)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEEXPEDIENTE"; //Stored Procedure Name
            comxx.Parameters.Add("@EXPEDIENTE", SqlDbType.NVarChar).Value = Nombre;
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
        public void InsetarBenefcio(int PRIVADO, String EXPEDIENTE, String REDENCIA1, String REDENCIA2,
            String LIBERTARC, String BUENACONDUCTA, String TOTALCORPORAL, String OBSERVACIONES)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "INSERTAR_BENEFICIO"; //Stored Procedure Name
            comxx.Parameters.Add("@PRIVADO", SqlDbType.NVarChar).Value = PRIVADO;
            comxx.Parameters.Add("@EXPEDIENTE", SqlDbType.NVarChar).Value = EXPEDIENTE;
            comxx.Parameters.Add("@REDENCIA1", SqlDbType.NVarChar).Value = REDENCIA1;
            comxx.Parameters.Add("@REDENCIA2", SqlDbType.NVarChar).Value = REDENCIA2;
            comxx.Parameters.Add("@LIBERTARC", SqlDbType.NVarChar).Value = LIBERTARC;
            comxx.Parameters.Add("@BUENACONDUCTA", SqlDbType.NVarChar).Value = BUENACONDUCTA;
            comxx.Parameters.Add("@TOTALCORPORAL", SqlDbType.NVarChar).Value = TOTALCORPORAL;
            comxx.Parameters.Add("@OBSERVACIONES", SqlDbType.NVarChar).Value = OBSERVACIONES;
            comxx.ExecuteNonQuery();
            conxx.Close();
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
        public Boolean Coincidencia(int privado,string Expediente)
        {
            SqlConnection conxx = new SqlConnection("Data Source=.;Initial Catalog = BDONG;Trusted_Connection=true;");
            conxx.Open();
            SqlCommand comxx = new SqlCommand(); // Create a object of SqlCommand class
            comxx.Connection = conxx; //Pass the connection object to Command
            comxx.CommandType = CommandType.StoredProcedure; // We will use stored procedure.
            comxx.CommandText = "EXISTEEXPEDIENTE2"; //Stored Procedure Name
            comxx.Parameters.Add("@EXPEDIENTE", SqlDbType.NVarChar).Value = Expediente;
            comxx.Parameters.Add("@PRIVADO", SqlDbType.NVarChar).Value = privado;
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