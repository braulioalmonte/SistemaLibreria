using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinalAdmin_Libros_
{

    class datoslibros
    {
        //Connection string para comunicacion con la base de datos
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
        SqlCommand comando;

        //Metodo para registrar libros
        public void registarLibro(int idLibro, string tituloLibro, string autorLibro, string precioLibro/*, string portadaLibro*/)
        {
            con.Open();

            string lineaComando = $"insert into libros values('{idLibro}', '{tituloLibro}', '{autorLibro}', '{precioLibro}');";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para editar libros
        public void editarLibro(int idLibro, string tituloLibro, string autorLibro, string precioLibro/*, string portadaLibro*/)
        {
            con.Open();

            string lineaComando = $"update libros set tituloLibro = '{tituloLibro}', autorLibro = '{autorLibro}', precioLibro = '{precioLibro}' where idLibro = '{idLibro}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();
        }

        //Metodo para eliminar libros
        public void eliminarLibro(int idLibro)
        {
            con.Open();

            string lineaComando = $"delete from libros where idLibro = '{idLibro}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para llenar la tabla cada vez que sea llamada
        public DataTable fillgrid()
        {
            con.Open();
            string lineacomando = $"select * from libros;";
            comando = new SqlCommand(lineacomando, con);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable table = new DataTable();

            data.Fill(table);

            con.Close();

            return table;
        }

        //Metodo para buscar por el valor deseado
        public DataTable searchgrid(string tituloLibro)
        {
            con.Open();
            string lineacomando = $"select * from libros where tituloLibro like '%{tituloLibro}%';";
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
