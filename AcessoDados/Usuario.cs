using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AcessoDados
{
    public class Usuarios
    {
        bool retorno;
        DataTable ListaUsuarios, DadosUsuario;

        /// <summary>
        /// Método para alteração dos dados do proprio usuario do sistema
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="Nome"></param>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns>Retorna booleano se executou com sucesso a alteracao ou nao</returns>
        public bool EditarUsuario(int CodigoUsuario, string Nome, string Login, string Senha)
        {
            retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {
                    SqlCommand sql = new SqlCommand();
                    sql.CommandText = "UPDATE USUARIOS SET usu_nome=@nome, usu_login=@login, usu_senha=@senha WHERE " +
                                      " (usu_codigo = @codigo)";

                    sql.Parameters.AddWithValue("@codigo", CodigoUsuario);
                    sql.Parameters.AddWithValue("@nome", Nome);
                    sql.Parameters.AddWithValue("@login", Login);
                    sql.Parameters.AddWithValue("@senha", Senha);

                    con.Open();
                    sql.Connection = con;
                    sql.ExecuteNonQuery();

                    retorno = true;

                    con.Close();
                }
            }
            catch (SqlException sql)
            {

                throw new Exception("Erro ao executar código" + sql.Message);

            }

            return retorno;


        }
        /// <summary>
        /// Método para exibição dos dados do usuario atual
        /// </summary>
        /// <param name="codigo">Codigo do usuario</param>
        /// <returns>Retorna um DataTable com os dados do usuario passado</returns>
        public DataTable ListarUsuario(int codigo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {

                    SqlDataAdapter dados = new SqlDataAdapter("SELECT * FROM USUARIOS WHERE(usu_codigo = @codigo)", con);
                    dados.SelectCommand.Parameters.AddWithValue("@codigo", codigo);
                    dados.SelectCommand.CommandType = CommandType.Text;

                    con.Open();

                    ListaUsuarios = new DataTable();

                    dados.Fill(ListaUsuarios);

                    con.Close();

                }
            }
            catch (SqlException sqls)
            {
                throw new Exception("Erro ao executar código" + sqls.Message);
            }

            return ListaUsuarios;


        }

        /// <summary>
        /// Método de acesso ao sistema
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns>Retorna um DataTable com os dados de usuario, caso os dados de acesso estejam errados retorna
        /// um datatable vazio e eu testo na camada de negocios</returns>
        public DataTable AcessarSistema(string Login, string Senha)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {

                    SqlDataAdapter dados = new SqlDataAdapter("SELECT * FROM USUARIOS WHERE(usu_login = @login) AND (usu_senha=@senha)", con);
                    dados.SelectCommand.Parameters.AddWithValue("@login", Login);
                    dados.SelectCommand.Parameters.AddWithValue("@senha", Senha);
                    dados.SelectCommand.CommandType = CommandType.Text;

                    con.Open();

                    DadosUsuario = new DataTable();
                    dados.Fill(DadosUsuario);


                    con.Close();

                }
            }
            catch (SqlException sqls)
            {
                throw new Exception("Erro ao executar código" + sqls.Message);
            }

            return DadosUsuario;
        }

        /// <summary>
        /// Método para add usuario
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns>Retorna variavel booleana</returns>
        public bool AdicionarUsuario(string Nome, string Login, string Senha)
        {
            retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {

                    SqlCommand sql = new SqlCommand("INSERT INTO USUARIOS (usu_nome, usu_login, usu_senha)VALUES(@nome,@login,@senha)");

                    sql.Parameters.AddWithValue("@nome", Nome);
                    sql.Parameters.AddWithValue("@login", Login);
                    sql.Parameters.AddWithValue("@senha", Senha);

                    sql.CommandType = CommandType.Text;

                    sql.Connection = con;

                    con.Open();

                    sql.ExecuteNonQuery();

                    retorno = true;
                    con.Close();

                }
            }
            catch (SqlException sqls)
            {
                throw new Exception("Erro ao executar código" + sqls.Message);
            }

            return retorno;
        }
        /// <summary>
        /// Método de Exclusão de usuário
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <returns>Variável booelana</returns>
        public bool ExcluirUsuario(int CodigoUsuario)
        {
            retorno = false;
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {
                    SqlCommand sql = new SqlCommand();
                    sql.CommandText = "DELETE FROM  USUARIOS WHERE (usu_codigo = @codigo)";

                    sql.Parameters.AddWithValue("@codigo", CodigoUsuario);

                    con.Open();
                    sql.Connection = con;
                    sql.ExecuteNonQuery();

                    retorno = true;

                    con.Close();
                }
            }
            catch (SqlException sql)
            {

                throw new Exception("Erro ao executar código" + sql.Message);

            }

            return retorno;
        }


        /// <summary>
        /// Método para exibição dos dados 
        /// </summary>
        /// <param name="codigo">Codigo do usuario</param>
        /// <returns>Retorna um DataTable com os dados do usuario passado</returns>

        public DataTable ListarTodosUsuarios()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AcessoDados.Acesso.StringConexao))
                {

                    SqlDataAdapter dados = new SqlDataAdapter("SELECT * FROM USUARIOS", con);
                    dados.SelectCommand.CommandType = CommandType.Text;

                    con.Open();

                    ListaUsuarios = new DataTable();

                    dados.Fill(ListaUsuarios);

                    con.Close();

                }
            }
            catch (SqlException sqls)
            {
                throw new Exception("Erro ao executar código" + sqls.Message);
            }

            return ListaUsuarios;

        }



    }
}
