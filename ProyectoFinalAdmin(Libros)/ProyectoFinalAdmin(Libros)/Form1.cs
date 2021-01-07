using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoFinalAdmin_Libros_
{
    public partial class Form1 : Form
    {
        string nombreUsuario, passwordUsuario;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            signup signup = new signup();
            signup.Show();
        }

        //Boton Login
        private void label2_Click(object sender, EventArgs e)
        {
            nombreUsuario = textBox1.Text;
            passwordUsuario = textBox2.Text;

            //Aqui el programa se conecta con la base de datos y compara los valores de los textBox y verifica que sean compatibles con los valores en la base de datos
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
            string query = $"Select * from usuario where nombreUsuario = '{nombreUsuario}' and passwordUsuario = '{passwordUsuario}';";
            SqlDataAdapter adaptUsuario = new SqlDataAdapter(query, con);
            DataTable usuarios = new DataTable();
            adaptUsuario.Fill(usuarios);

            //Este método toma el valor del nombre de usuario y lo muestra en la esquina superior del dashboard una vez logeado
            if (usuarios.Rows.Count == 1)
            {
                
                dashboard dashboard1 = new dashboard(nombreUsuario);
                this.Hide();
                dashboard1.Show();
            }

            else
            {
                MessageBox.Show("Revisa tus credenciales");
            }

        }

    
    }
}
