using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinalAdmin_Libros_
{
    class datosclientes
    {   
        //Connection string para comunicacion con la base de datos
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
        SqlCommand comando;

        //Metodo para registrar cliente
        public void registarCliente(int idCliente, string nombreCliente, string apellidoCliente, string telefonoCliente, string miembro/*, string portadaLibro*/)
        {
            con.Open();

            string lineaComando = $"insert into cliente values('{idCliente}', '{nombreCliente}', '{apellidoCliente}', '{telefonoCliente}', '{miembro}');";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //Metodo para editar cliente
        public void editarCliente(int idCliente, string nombreCliente, string apellidoCliente, string telefonoCliente, string miembro)
        {
            con.Open();

            string lineaComando = $"update cliente set nombreCliente = '{nombreCliente}', apellidoCliente = '{apellidoCliente}', telefonoCliente = '{telefonoCliente}', miembro = '{miembro}' where idCliente = '{idCliente}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();
        }

        //Metodo para eliminar cliente
        public void eliminarCliente(int idCliente)
        {
            con.Open();

            string lineaComando = $"delete from cliente where idCliente = '{idCliente}';";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }


        //Metodo para llenar la tabla cada vez que se cargue
        public DataTable fillgrid()
        {
            con.Open();
            string lineacomando = $"select * from cliente;";
            comando = new SqlCommand(lineacomando, con);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable table = new DataTable();

            data.Fill(table);

            con.Close();

            return table;
        }

        //Metodo para buscar por el valor deseado
        public DataTable searchgrid(int idCliente)
        {
            con.Open();
            string lineacomando = $"select * from cliente where idCliente like '%{idCliente}%';";
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
