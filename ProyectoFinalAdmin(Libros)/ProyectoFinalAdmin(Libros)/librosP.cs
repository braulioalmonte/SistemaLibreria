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
    public partial class librosP : Form
    {
        int idLibro;
        string  tituloLibro, autorLibro, precioLibro /*portadaLibro*/;
        datoslibros datosLibros = new datoslibros();
      

        private void librosP_Load(object sender, EventArgs e)
        {
            fillgrid();
        }

        //Funcion eliminar
        private void button3_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dataGridView1.SelectedCells[0] as DataGridViewCell;
            int idLibro = (int)cell.Value;

            datosLibros.eliminarLibro(idLibro);

            MessageBox.Show("Libro Borrado");
            clear();
            fillgrid();

        }

        public librosP()
        {
            InitializeComponent();
        }

        //Funcion agregar
        private void button1_Click(object sender, EventArgs e)
        {

            idLibro = Int32.Parse(textBox1.Text);
            tituloLibro = textBox2.Text;
            autorLibro = textBox3.Text;
            precioLibro = textBox4.Text;
            
            datosLibros.registarLibro(idLibro, tituloLibro, autorLibro, precioLibro /*portadaLibro*/);
            MessageBox.Show("Libro Agregado");
            clear();
            fillgrid();
           

        }

        //Funcion buscar
        private void button5_Click(object sender, EventArgs e)
        {

            tituloLibro = textBox2.Text;
            dataGridView1.DataSource = datosLibros.searchgrid(tituloLibro);

        }

        //Funcion Editar
        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView1.SelectedCells[0] as DataGridViewCell;
            int idLibroE = (int)cell.Value;


            tituloLibro = textBox2.Text;
            autorLibro = textBox3.Text;
            precioLibro = textBox4.Text;

            datosLibros.editarLibro(idLibroE, tituloLibro, autorLibro, precioLibro);

            MessageBox.Show("Libro Editado");
            clear();
            fillgrid();
        }

        //Llenar la tabla
        public void fillgrid()
        {
            dataGridView1.DataSource = datosLibros.fillgrid();
        }

        //Limpiar los campos
        public void clear()
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox)
                {
                    tool.Text = "";
                }
            }
        }
    }
}
