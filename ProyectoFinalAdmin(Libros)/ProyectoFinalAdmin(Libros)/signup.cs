using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalAdmin_Libros_
{
    public partial class signup : Form
    {

        string nombreUsuario, passwordUsuario, emailUsuario;
        datosusuario datosUsuario = new datosusuario();

        public signup()
        {
            InitializeComponent();
        }

        //Boton cerrar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton registrar
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();

            agregarUsuario();
        }

        //Funcion agregar usuario
        public void agregarUsuario()
        {
            nombreUsuario = textBox1.Text;
            passwordUsuario = textBox2.Text;
            emailUsuario = textBox4.Text;

            datosUsuario.registarUsuario(nombreUsuario, passwordUsuario, emailUsuario);
        }
    }
}
