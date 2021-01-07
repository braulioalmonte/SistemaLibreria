using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProyectoFinalAdmin_Libros_
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        //Boton para salir de la aplicacion
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton login
        private void label3_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        //Boton de red social para twitter
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/bsoftware3");
        }

        //Boton de red social para instagram
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/b.softwareproject/");
        }
    }
}
