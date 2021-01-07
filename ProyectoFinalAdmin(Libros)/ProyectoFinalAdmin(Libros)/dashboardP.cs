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
    public partial class dashboardP : Form
    {
        public dashboardP()
        {
            InitializeComponent();
        }

        //Este metodo extrae datos de todas las tablas de base de datos en forma de una cuenta de numero de registros, para luego mostrarlos en pantalla
        private void dashboardP_Load(object sender, EventArgs e)
        {

            string con = $"Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True";

            //Cuenta de prestados del dashboard
            string comandoprestamosCount = "select count(*) from prestados where vendido = 'no';";
            SqlConnection conn = new SqlConnection(con);
            SqlDataAdapter adaptPrestadosCount = new SqlDataAdapter(comandoprestamosCount, conn);

            DataTable prestadosCount = new DataTable();
            adaptPrestadosCount.Fill(prestadosCount);
            label16.Text = prestadosCount.Rows[0][0].ToString();

            //Cuenta vendidos del dashboard
            string comandovendidosCount = "select count(*) from prestados where vendido = 'si';";
            SqlDataAdapter adaptvendidosCount = new SqlDataAdapter(comandovendidosCount, conn);

            DataTable vendidosCount = new DataTable();
            adaptvendidosCount.Fill(vendidosCount);
            label1.Text = vendidosCount.Rows[0][0].ToString();

            //Cuenta libros del dashboard
            string comandoLibrosCount = "select count(*) from libros;";
            SqlDataAdapter adaptLibrosCount = new SqlDataAdapter(comandoLibrosCount, conn);

            DataTable librosCount = new DataTable();
            adaptLibrosCount.Fill(librosCount);
            label13.Text = librosCount.Rows[0][0].ToString();

            //Cuenta clientes del dashboard
            string comandoClienteCount = "select count(*) from cliente where miembro = 'no';";
            SqlDataAdapter adaptClienteCount = new SqlDataAdapter(comandoClienteCount, conn);

            DataTable clienteCount = new DataTable();
            adaptClienteCount.Fill(clienteCount);

            label14.Text = clienteCount.Rows[0][0].ToString();

            //Cuenta miembros del dashboard
            string comandoMiembroCount = "select count(*) from cliente where miembro = 'si';";
            SqlDataAdapter adaptMiembroCount = new SqlDataAdapter(comandoMiembroCount, conn);

            DataTable miembroCount = new DataTable();
            adaptMiembroCount.Fill(miembroCount);

            label3.Text = miembroCount.Rows[0][0].ToString();

            //Cuenta los retornados del dashboard
            string comandoRetornadosCount = "select count(*) from retornar;";
            SqlDataAdapter adaptRetornadosCount = new SqlDataAdapter(comandoRetornadosCount, conn);

            DataTable retornardosCount = new DataTable();
            adaptRetornadosCount.Fill(retornardosCount);

            label15.Text = retornardosCount.Rows[0][0].ToString();

        }
    }
}
