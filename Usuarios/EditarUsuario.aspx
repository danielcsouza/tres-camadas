<%@ Page Title="" Language="C#" MasterPageFile="~/modelo.master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Usuarios.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudo" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              $("#form").validate({
                  rules: {
                      <%=txtNome.UniqueID %>:{required:true},
                    <%=txtLogin.UniqueID %>:{required:true},
                    <%=txtSenha.UniqueID %>:{required:true}

                },
                messages: {
                    <%=txtNome.UniqueID %>:{required:"Qual seu nome?"},
                    <%=txtLogin.UniqueID %>:{required:"Digite um login"},
                    <%=txtSenha.UniqueID %>:{required:"Escolha uma senha"}
                }
            });
        });
  </script>
  <div class="span12">
 <fieldset><legend>Editando Cadastro</legend>
  <div class="control-group">
    <label class="control-label" for="Nome">Nome</label>
    <div class="controls">
       <asp:TextBox ID="txtNome" runat="server" placeholder="Digite seu nome"></asp:TextBox>
    </div>
  </div>
  <div class="control-group">
    <label class="control-label" for="Login">Login</label>
    <div class="controls">
       <asp:TextBox ID="txtLogin" runat="server" placeholder="Escolha um login de acesso"></asp:TextBox>
    </div>
  </div>
  <div class="control-group">
    <label class="control-label" for="Senha">Senha</label>
    <div class="controls">
       <asp:TextBox ID="txtSenha" runat="server" placeholder="Escolha uma senha de acesso" TextMode="Password"></asp:TextBox>
        <asp:HiddenField ID="hdtxtCodUsuario" runat="server" />
    </div>
  </div>
   <div class="form-actions">
     <asp:Button ID="btnEnviar" runat="server" Text="Editar" CssClass="btn btn-large btn-inverse" OnClick="btnEnviar_Click" />
</div>

</asp:Content>
