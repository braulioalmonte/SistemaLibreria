using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinalAdmin_Libros_
{
    class datosretornados
    {
        //Connection string para comunicacion con la base de datos
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
        SqlCommand comando;

        //Metodo para registrar retorno
        public void registarRetorno(int idRetorno, int idPrestamo, int idLibro, int idCliente, string fechaRetornado, int multa)
        {
            con.Open();

            string lineaComando = $"insert into retornar values('{idRetorno}', '{idPrestamo}', '{idLibro}', '{idCliente}', '{fechaRetornado}', '{multa}');";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para editar retorno
        public void editarRetorno(int idRetorno, int idPrestamo, int idLibro, int idCliente, string fechaRetornado, int multa)
        {
            con.Open();

            string lineaComando = $"update retornar set idPrestamo = '{idPrestamo}', idLibro = '{idLibro}', idCliente = '{idCliente}', fechaRetornado = '{fechaRetornado}', multa = '{multa}' where idRetorno = '{idRetorno}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();
        }

        //Metodo para eliminar retorno
        public void eliminarPrestamo(int idRetorno)
        {
            con.Open();

            string lineaComando = $"delete from retornar where idRetorno = '{idRetorno}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para llenar la tabla cada vez que sea llamada
        public DataTable fillgrid()
        {
            con.Open();
            string lineacomando = $"select * from retornar;";
            comando = new SqlCommand(lineacomando, con);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable table = new DataTable();

            data.Fill(table);

            con.Close();

            return table;
        }

        //Metodo para buscar por el valor deseado
        public DataTable searchgrid(int idRetorno)
        {
            con.Open();
            string lineacomando = $"select * from retornar where idRetorno = '{idRetorno}';";
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
