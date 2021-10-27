using MySql.Data.MySqlClient;
using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_AADAS.Classes
{
    class Conexao
    {
        public static MySqlConnection conn;

        private static string conexao = "Server=localhost;Port=3306; Database=projeto_aadas; Uid=root; Pwd=@Dris1107;";

        //Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=projeto_aadas; User=root; Password=@Dris1107; Option=3;



        public static void Conectar()
        {
            conn = new MySqlConnection(conexao);
            conn.Open();
        }

        public static void desconectar()
        {
            conn.Close();
        }

    }
}
