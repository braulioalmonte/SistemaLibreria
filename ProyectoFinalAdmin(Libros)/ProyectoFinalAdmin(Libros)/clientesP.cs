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
    public partial class clientesP : Form
    {

        int idCliente;
        string nombreCliente, apellidoCliente, telefonoCliente, miembro;
        datosclientes datosClientes = new datosclientes();

        public clientesP()
        {
            InitializeComponent();
            comboBox1.Items.Add("Si");
            comboBox1.Items.Add("No");
        }

        //Funcion Agregar
        private void button5_Click(object sender, EventArgs e)
        {
            idCliente = Int32.Parse(textBox5.Text);
            nombreCliente = textBox6.Text;
            apellidoCliente = textBox7.Text;
            telefonoCliente = textBox8.Text;
            miembro = comboBox1.Text;

            datosClientes.registarCliente(idCliente, nombreCliente, apellidoCliente, telefonoCliente, miembro);
            MessageBox.Show("Cliente Agregado");
            clear();
            fillgrid();
        }

        //Funcion Editar
        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView2.SelectedCells[0] as DataGridViewCell;
            int idCliente = (int)cell.Value;


            nombreCliente = textBox6.Text;
            apellidoCliente = textBox7.Text;
            telefonoCliente = textBox8.Text;
            miembro = comboBox1.Text;

            datosClientes.editarCliente(idCliente, nombreCliente, apellidoCliente, telefonoCliente, miembro);

            MessageBox.Show("Cliente Editado");
            clear();
            fillgrid();
        }

        //Funcion buscar
        private void button1_Click(object sender, EventArgs e)
        {
            idCliente = Int32.Parse(textBox5.Text);
            dataGridView2.DataSource = datosClientes.searchgrid(idCliente);
        }

        private void clientesP_Load(object sender, EventArgs e)
        {
            fillgrid();
        }

        //Funcion Eliminar
        private void button7_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dataGridView2.SelectedCells[0] as DataGridViewCell;
            int idClienteE = (int)cell.Value;

            datosClientes.eliminarCliente(idClienteE);

            MessageBox.Show("Cliente Borrado");
            clear();
            fillgrid();
        }

        //Llenar la tabla
        public void fillgrid()
        {
            dataGridView2.DataSource = datosClientes.fillgrid();
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
