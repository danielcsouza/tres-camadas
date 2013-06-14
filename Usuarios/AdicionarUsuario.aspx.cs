using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegraNegocios;

namespace Usuarios
{
    public partial class AdicionarUsuario : System.Web.UI.Page
    {
        string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
            retorno = objUsuario.AdicionarUsuario(txtNome.Text.ToString(), txtLogin.Text.ToString(), txtSenha.Text.ToString());

            switch (retorno)
            {
                case "sucesso":
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Cadastro realizado com sucesso','success');", true);
                  break;

                case "erro":
                  ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Erro ao realizar cadastro','error');", true);
                  break;

                case "vazio":
                  ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Não deixe campos vazios','erro');", true);
                  break;
            }

        }
    }
}