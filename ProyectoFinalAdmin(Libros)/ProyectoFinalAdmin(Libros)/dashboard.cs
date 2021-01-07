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
    public partial class dashboard : Form
    {
        

        public dashboard(string nombreUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(300,50);
            label7.Text = nombreUsuario;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        //Pantalla libros
        private void label2_Click(object sender, EventArgs e)
        {
            //Este bucle tiene la funcion de que en caso de que haya cualquier otra ventana abierta, se cierren, menos la del dashboard y la pantalla actual
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        if (Application.OpenForms[i].Name != "LibrosP")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }

                }

            }

            //Esta funcion evita que se abra mas de una ventana del mismo tipo
            librosP libros = new librosP();
            int libroscount = Application.OpenForms.OfType<librosP>().Count();
            if(libroscount <= 1)
            {
                libros.Show();
            }
           
            libros.StartPosition = FormStartPosition.Manual;
            libros.Location = new Point(533, 144);

        }
        //Nota, a partir de aqui las funciones son iguales para todas las pantallas

        //Pantalla dashboard
        private void label1_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        if (Application.OpenForms[i].Name != "dashboardP")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }

                }

            }
            dashboardP dashboard = new dashboardP();
            dashboard.Show();
            dashboard.StartPosition = FormStartPosition.Manual;
            dashboard.Location = new Point(533, 144);

        }

        //Pantalla Clientes
        private void label3_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        if (Application.OpenForms[i].Name != "clientesP")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }

                }

            }
            clientesP clientes = new clientesP();
            clientes.Show();
            clientes.StartPosition = FormStartPosition.Manual;
            clientes.Location = new Point(533, 144);
        }


        //Pantalla Libros Prestados
        private void label5_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        if (Application.OpenForms[i].Name != "librosPrestadosP")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }

                }

            }
            librosPrestadosP librosPrestados = new librosPrestadosP();
            librosPrestados.Show();
            librosPrestados.StartPosition = FormStartPosition.Manual;
            librosPrestados.Location = new Point(533, 144);
        }

        //Pantalla Retornar Libros
        private void label4_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        if (Application.OpenForms[i].Name != "retornarlibrosP")
                        {
                            Application.OpenForms[i].Close();
                        }
                    }

                }

            }
            retornarlibrosP retornarlibros = new retornarlibrosP();
            retornarlibros.Show();
            retornarlibros.StartPosition = FormStartPosition.Manual;
            retornarlibros.Location = new Point(533, 144);
            
        }

        //Boton logout
        private void label6_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "PantallaPrincipal")
                {
                    Application.OpenForms[i].Close();
                }

            }
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //Boton de la imagen del libro, este limpia la pantalla para que aparezca la pantalla principal
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "dashboard")
                {
                    if (Application.OpenForms[i].Name != "PantallaPrincipal")
                    {
                        Application.OpenForms[i].Close();
                    }
                        
                }
                   
            }
        }

        //Metodo para cambiar la opcion del menu en la cual se encuentre el mouse
        private void hoverIn_changecolor(object sender, EventArgs e)
        {
            Panel pan = sender as Panel;
            pan.BackColor = Color.FromArgb(0, 192, 192);
        }

        //Metodo para cambiar la opcion del menu del cual el mouse no se encuentre una vez salga del area de la funcion anterior
        private void hoverout_changecolor(object sender, EventArgs e)
        {
            Panel pan = sender as Panel;
            pan.BackColor = Color.FromArgb(128, 128, 255);
        }
    }
}
