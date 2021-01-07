using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinalAdmin_Libros_
{
    class datosusuario
    {
        //Connection string para comunicacion con la base de datos
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True");
        SqlCommand comando;

        //Metodo para registrar usuario
        public void registarUsuario(string nombreUsuario, string passwordUsuario, string emailUsuario)
        {
            con.Open();

            string lineaComando = $"insert into usuario values('{nombreUsuario}', '{passwordUsuario}', '{emailUsuario}');";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();

            con.Close();

        }

        //El sistema está diseñado enfocado en que el/los administrador/es tienen acceso directo a la base de datos, solo asi se pueden borrar usuarios, haciendolo mas seguro
    }
}
