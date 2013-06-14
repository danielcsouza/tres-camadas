using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AcessoDados;
using System.Web.UI;

namespace RegraNegocios
{
    /// <summary>
    /// Classe herdando do page para que posssa trabalhar com a criação de 
    /// session nesta camada de regras de negocios
    /// </summary>

    public class Usuarios : Page
    {
        DataTable DadosUsuario;
        string retorno;
        bool sucesso;

        /// <summary>
        /// Método para listar os dados de um determinado usuário
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public DataTable ListarUsuario(int codigo)
        {
            if (codigo > 0)
            {
                AcessoDados.Usuarios usuario = new AcessoDados.Usuarios();
                DadosUsuario = usuario.ListarUsuario(codigo);

            }

            return DadosUsuario;
        }
        /// <summary>
        /// Método de acesso ao sistema através de Login e senha
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>

        public string AcessarSistema(string Login, string Senha)
        {
            if (Login != "" && Senha != "")
            {
                AcessoDados.Usuarios logar = new AcessoDados.Usuarios();
                DadosUsuario = logar.AcessarSistema(Login, Senha);

                if (DadosUsuario.Rows.Count > 0)
                {
                    foreach (DataRow coluna in DadosUsuario.Rows)
                    {
                        Session["CodUsuario"] = coluna["usu_codigo"];
                        Session["NomeUsuario"] = coluna["usu_nome"];

                        retorno = "sucesso";

                    }

                }
                else
                {
                    retorno = "nao_encontrou";
                }
            }
            else
            {

                retorno = "vazio";
            }

            return retorno;
        }

        /// <summary>
        /// Método de  para adicionar usuario
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        public string AdicionarUsuario(string Nome, string Login, string Senha)
        {
            if (String.IsNullOrEmpty(Nome) || String.IsNullOrEmpty(Login) || String.IsNullOrEmpty(Senha))
            {
                retorno = "vazio";
            }
            else
            {
                AcessoDados.Usuarios user = new AcessoDados.Usuarios();
                sucesso = user.AdicionarUsuario(Nome, Login, Senha);

                retorno = (sucesso) ? "sucesso" : "erro";

            }

            return retorno;
        }
        /// <summary>
        /// Método de Edição de dados do usuário
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="Nome"></param>
        /// <param name="Login"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        public bool EditarUsuario(int CodigoUsuario, string Nome, string Login, string Senha)
        {
            AcessoDados.Usuarios user = new AcessoDados.Usuarios();
            sucesso = user.EditarUsuario(CodigoUsuario, Nome, Login, Senha);

            return sucesso;
        }
        /// <summary>
        /// Método de Exclusão do usuário
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <returns></returns>
        public bool ExcluirUsuario(int CodigoUsuario)
        {
            if (CodigoUsuario > 0)
            {
                AcessoDados.Usuarios user = new AcessoDados.Usuarios();
                sucesso = user.ExcluirUsuario(CodigoUsuario);
            }
            else
            {
                sucesso = false;
            }
            return sucesso;
        }
        /// <summary>
        /// Método que lista todos os usuários
        /// </summary>
        /// <returns>Retorna um DataTable com todos os usuários</returns>
        public DataTable ListarTodosUsuarios()
        {
            AcessoDados.Usuarios objUsuario = new AcessoDados.Usuarios();
            DadosUsuario = objUsuario.ListarTodosUsuarios();
            return DadosUsuario;
        }
    }
}
