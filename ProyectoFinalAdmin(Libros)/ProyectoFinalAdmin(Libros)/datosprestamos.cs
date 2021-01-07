using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinalAdmin_Libros_
{
    class datosprestamos
    {
        //Connection string para comunicacion con la base de datos
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
        SqlCommand comando;

        //Metodo para registrar prestamos
        public void registrarPrestamo(int idPrestamo, int idCliente, int idLibro, string fechaPrestamo, string fechaRetornado, string vendido)
        {
            con.Open();

            string lineaComando = $"insert into prestados values('{idPrestamo}', '{idCliente}', '{idLibro}', '{fechaPrestamo}', '{fechaRetornado}', '{vendido}');";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para editar prestamos
        public void editarPrestamo(int idPrestamo, int idCliente, int idLibro, string fechaPrestamo, string fechaRetornado, string vendido)
        {
            con.Open();

            string lineaComando = $"update prestados set idCliente = '{idCliente}', idLibro = '{idLibro}', fechaPrestado = '{fechaPrestamo}', fechaRetornado = '{fechaRetornado}', vendido = '{vendido}' where idPrestamo = '{idPrestamo}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();
        }

        //Metodo para eliminar prestamos
        public void eliminarPrestamo(int idPrestamo)
        {
            con.Open();

            string lineaComando = $"delete from prestados where idPrestamo = '{idPrestamo}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para llenar la tabla cada vez que sea llamada
        public DataTable fillgrid()
        {
            con.Open();
            string lineacomando = $"select * from prestados;";
            comando = new SqlCommand(lineacomando, con);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable table = new DataTable();

            data.Fill(table);

            con.Close();

            return table;
        }

        //Metodo para buscar por el valor deseado
        public DataTable searchgrid(int idPrestamo)
        {
            con.Open();
            string lineacomando = $"select * from prestados where idPrestamo = '{idPrestamo}';";
            comando = new SqlCommand(lineacomando, con);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable table = new DataTable();

            data.Fill(table);

            con.Close();

            return table;
        }

    }
}
