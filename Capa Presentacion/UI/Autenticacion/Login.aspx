<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Capa_Presentacion.UI.Autenticacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container box">
       <asp:Label runat="server" ID="lblMensaje" Text=""></asp:Label>
    <h1 class="text-center">Inicio de Sesion</h1>
    <br />
    <div class="field">
        <p class="control has-icons-left has-icons-right">
            <asp:TextBox runat="server" ID="usuarioTextBox" CssClass="input is-success" placeholder="Email"></asp:TextBox>
            <span class="icon is-small is-left">
                <i class="fas fa-envelope"></i>
            </span>
            <span class="icon is-small is-right">
                <i class="fas fa-check"></i>
            </span>
        </p>
    </div>
    <div class="field">
        <p class="control has-icons-left">
            <asp:TextBox runat="server" ID="claveTextBox" CssClass="input is-success" TextMode="Password" placeholder="Password"></asp:TextBox>
            <span class="icon is-small is-left">
                <i class="fas fa-lock"></i>
            </span>
        </p>
    </div>
    <div class="buttons">
        <asp:Button runat="server" ID="IniciarSesion" CssClass="button is-success" Text="Ingresar" OnClick="IniciarSesion_Click" />
        <asp:Button runat="server" ID="Cancelar" CssClass="button is-light" Text="Cancelar" />
    </div>
</div>

</asp:Content>
