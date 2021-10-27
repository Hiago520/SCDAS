using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_AADAS.Classes
{
    class Funcionarios
    {
        //Método para inserir dados na Tabela Funcionários
        public static void inserir ( string nomeFunc, string programaFunc, string celularFunc, string cargoFunc, string loginFunc, string passwordFunc, string emailFunc, string tipoFunc, string cpfFunc)
        {
            string sql = @"insert into funcionarios values (null,@Nome, @ProgramaProjeto, @Celular, @Cargo, @Login, @Senha, @Email, @tipo, @cpf)";

            MySqlCommand cmd = new MySqlCommand(sql, Classes.Conexao.conn);

           
            cmd.Parameters.AddWithValue("Nome", nomeFunc);
            cmd.Parameters.AddWithValue("ProgramaProjeto", programaFunc);
            cmd.Parameters.AddWithValue("Celular", celularFunc);
            cmd.Parameters.AddWithValue("Cargo", cargoFunc);
            cmd.Parameters.AddWithValue("Login", loginFunc);
            cmd.Parameters.AddWithValue("Senha", passwordFunc);
            cmd.Parameters.AddWithValue("Email", emailFunc);
            cmd.Parameters.AddWithValue("tipo", tipoFunc);
            cmd.Parameters.AddWithValue("cpf", cpfFunc);

            cmd.ExecuteNonQuery();
        }

        // Método para Atualizar dados na Tabela Funcionários
        public static void atualizar(string nomeFunc, string programaFunc, string celularFunc, string cargoFunc, string loginFunc, string passwordFunc, string emailFunc, string tipoFunc, string cpfFunc, int codigo)
        {

            string sql = @"update funcionarios set Nome=@Nome, ProgramaProjeto=@ProgramaProjeto, Celular=@Celular, Cargo=@Cargo, Login=@Login, Senha=@Senha, Email=@Email, tipo=@tipo, cpf=@cpf where Codigo=@Codigo";

            MySqlCommand cmd = new MySqlCommand(sql, Classes.Conexao.conn);

            cmd.Parameters.AddWithValue("Nome", nomeFunc);
            cmd.Parameters.AddWithValue("ProgramaProjeto", programaFunc);
            cmd.Parameters.AddWithValue("Celular", celularFunc);
            cmd.Parameters.AddWithValue("Cargo", cargoFunc);
            cmd.Parameters.AddWithValue("Login", loginFunc);
            cmd.Parameters.AddWithValue("Senha", passwordFunc);
            cmd.Parameters.AddWithValue("Email", emailFunc);
            cmd.Parameters.AddWithValue("tipo", tipoFunc);
            cmd.Parameters.AddWithValue("cpf", cpfFunc);
            cmd.Parameters.AddWithValue("Codigo", codigo);

            cmd.ExecuteNonQuery();

        }
        // Método para Excluir dados na Tabela Funcionários
        public static void excluir (int codigo_func)
        {
            string sql = @"delete from funcionarios where Codigo=@Codigo";

            MySqlCommand cmd = new MySqlCommand(sql, Conexao.conn);
            cmd.Parameters.AddWithValue("Codigo", codigo_func);
            cmd.ExecuteNonQuery();
        }

    }
}
