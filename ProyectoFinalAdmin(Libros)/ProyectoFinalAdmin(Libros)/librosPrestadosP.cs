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
    public partial class librosPrestadosP : Form
    {
        int idPrestamo, idLibro, idCliente;
        
        string fechaPrestamo, fechaRetornado, vendido;
        datosprestamos datosPrestamos = new datosprestamos();

        public librosPrestadosP()
        {
            InitializeComponent();
        }
        //Este metodo hace que la base de datos extraiga las ID de los clientes y libros registrados para insertarlos en un combobox
        private void librosPrestadosP_Load(object sender, EventArgs e)
        {
            fillgrid();

            string con = $"Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True";

            string comandolibros = "select * from libros;";
            SqlConnection conn = new SqlConnection(con);
            SqlDataAdapter adaptLibro = new SqlDataAdapter(comandolibros, conn);

            DataTable libros = new DataTable();
            adaptLibro.Fill(libros);
            comboBox1.DisplayMember = "idLibro";

            comboBox1.DataSource = libros;

            string comandoCliente = "select * from cliente;";
            SqlDataAdapter adaptCliente = new SqlDataAdapter(comandoCliente, conn);

            DataTable cliente = new DataTable();
            adaptCliente.Fill(cliente);
            comboBox2.DisplayMember = "idCliente";

            comboBox2.DataSource = cliente;

            comboBox3.Items.Add("Si");
            comboBox3.Items.Add("No");
        }


        //Funcion agregar
        private void button8_Click(object sender, EventArgs e)
        {
            idPrestamo = Int32.Parse(textBox10.Text);
            idLibro = Int32.Parse(comboBox1.Text);
            idCliente = Int32.Parse(comboBox2.Text);
            fechaPrestamo = dateTimePicker1.Value.ToString();
            fechaRetornado = dateTimePicker2.Value.ToString() ;
            vendido = comboBox3.Text;

            datosPrestamos.registrarPrestamo(idPrestamo, idLibro, idCliente, fechaPrestamo, fechaRetornado, vendido);
            MessageBox.Show("Prestamo Agreado");
            fillgrid();
            
        }

        //Funcion buscar
        private void button1_Click(object sender, EventArgs e)
        {
            idPrestamo = Int32.Parse(textBox10.Text);
            dataGridView3.DataSource = datosPrestamos.searchgrid(idPrestamo);
        }

        //Funcion Editar
        private void button9_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dataGridView3.SelectedCells[0] as DataGridViewCell;
            int idPrestamoE = (int)cell.Value;


            idLibro = Int32.Parse(comboBox2.Text);
            idCliente = Int32.Parse(comboBox1.Text);
            fechaPrestamo = dateTimePicker1.Value.ToString();
            fechaRetornado = dateTimePicker2.Value.ToString();
            vendido = comboBox3.Text;

            datosPrestamos.editarPrestamo(idPrestamoE, idLibro, idCliente, fechaPrestamo, fechaRetornado, vendido);

            MessageBox.Show("Prestamo Editado");
            clear();
            fillgrid();
        }

        //Funcion Eliminar
        private void button10_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dataGridView3.SelectedCells[0] as DataGridViewCell;
            int idPrestamoE = (int)cell.Value;

            datosPrestamos.eliminarPrestamo(idPrestamoE);

            MessageBox.Show("Prestamo Borrado");
            clear();
            fillgrid();
        }

        //Llenar la tabla
        public void fillgrid()
        {
            dataGridView3.DataSource = datosPrestamos.fillgrid();
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
