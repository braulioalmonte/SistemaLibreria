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
    public partial class retornarlibrosP : Form
    {

        int idRetorno, idPrestamo, idLibro, idCliente, multa;
        string fechaRetorno;

        datosretornados datosRetornados = new datosretornados();

        public retornarlibrosP()
        {
            InitializeComponent();

        }

        //Este metodo hace que la base de datos extraiga las ID de los prestamos, clientes y libros registrados para insertarlos en un combobox
        private void retornarlibrosP_Load(object sender, EventArgs e)
        {
            fillgrid();

            string con = $"Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True";

            string comandoprestamos = "select * from prestados;";
            SqlConnection conn = new SqlConnection(con);
            SqlDataAdapter adaptPrestados = new SqlDataAdapter(comandoprestamos, conn);

            DataTable prestados = new DataTable();
            adaptPrestados.Fill(prestados);
            comboBox1.DisplayMember = "idPrestamo";

            comboBox1.DataSource = prestados;


            string comandoLibros = "select * from libros;";
            SqlDataAdapter adaptLibros = new SqlDataAdapter(comandoLibros, conn);

            DataTable libros = new DataTable();
            adaptLibros.Fill(libros);
            comboBox2.DisplayMember = "idLibro";

            comboBox2.DataSource = libros;


            string comandoCliente = "select * from cliente;";
            SqlDataAdapter adaptCliente = new SqlDataAdapter(comandoCliente, conn);

            DataTable cliente = new DataTable();
            adaptCliente.Fill(cliente);
            comboBox3.DisplayMember = "idCliente";

            comboBox3.DataSource = cliente;

        }

        //Funcion agregar
        private void button11_Click(object sender, EventArgs e)
        {
            idRetorno = Int32.Parse(textBox16.Text);
            idPrestamo = Int32.Parse(comboBox1.Text);
            idLibro = Int32.Parse(comboBox2.Text);
            idCliente = Int32.Parse(comboBox3.Text);
            fechaRetorno = dateTimePicker1.Value.ToString();
            multa = Int32.Parse(textBox20.Text);

            datosRetornados.registarRetorno(idRetorno, idPrestamo, idLibro, idCliente, fechaRetorno, multa);
            MessageBox.Show("Retorno Agregado");
            fillgrid();

        }

        //Funcion buscar
        private void button1_Click(object sender, EventArgs e)
        {
            idRetorno = Int32.Parse(textBox16.Text);
            dataGridView4.DataSource = datosRetornados.searchgrid(idRetorno);
        }

        //Funcion editar
        private void button12_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView4.SelectedCells[0] as DataGridViewCell;
            int idRetornoE = (int)cell.Value;


            idPrestamo = Int32.Parse(comboBox1.Text);
            idLibro = Int32.Parse(comboBox2.Text);
            idCliente = Int32.Parse(comboBox3.Text);
            fechaRetorno = dateTimePicker1.Value.ToString();
            multa = Int32.Parse(textBox20.Text);

            datosRetornados.editarRetorno(idRetornoE, idPrestamo, idLibro, idCliente, fechaRetorno, multa);

            MessageBox.Show("Retorno Editado");
            clear();
            fillgrid();
        }

        //Funcion eliminar
        private void button13_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dataGridView4.SelectedCells[0] as DataGridViewCell;
            int idRetornoE = (int)cell.Value;

            datosRetornados.eliminarPrestamo(idRetornoE);

            MessageBox.Show("Retorno Borrado");
            clear();
            fillgrid();
        }

        //Llenar la tabla
        public void fillgrid()
        {
            dataGridView4.DataSource = datosRetornados.fillgrid();
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
