<%@ Page Title="" Language="C#" MasterPageFile="~/modelo.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Usuarios.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudo" runat="server">
    <h1>Listagem de Usuários</h1>
    <hr />
    <asp:Label ID="lblNothing" runat="server" Font-Size="Larger" Visible="False"></asp:Label>
    <div class="span12">

        <asp:Repeater ID="rptLista" runat="server">
            <ItemTemplate>
                <div class="span4 well well-small">
                    <b>Código:</b> <%#Eval("usu_codigo") %><br />
                    <b>Nome:</b> <%#Eval("usu_nome") %><br />
                    <b>Login:</b> <%#Eval("usu_login") %>
                    <br /><br />
                    <a href="EditarUsuario.aspx?cod=<%#Eval("usu_codigo") %>">Editar</a>&nbsp; | <a href="ExcluirUsuario.aspx?cod=<%#Eval("usu_codigo") %>">Excluir</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
