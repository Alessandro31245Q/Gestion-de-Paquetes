<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MP.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Capa_Presentacion.UI.Autenticacion.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container box">
        <h1 class="text-center">Formulario de Registro de Usuarios</h1>
        <br />
        <asp:Label runat="server" ID="lblMensaje" Text=""></asp:Label>


            <div class="field">
                <p class="control has-icons-left">
                    <asp:TextBox runat="server" ID="nombreTextBox" CssClass="input is-success" placeholder="Nombre" required></asp:TextBox>
                    <span class="icon is-small is-left">
                        <i class="fas fa-user"></i>
                    </span>
                </p>
            </div>

            <div class="field">
                <p class="control has-icons-left">
                    <asp:TextBox runat="server" ID="direccionTextBox" CssClass="input is-success" placeholder="Dirección" required></asp:TextBox>
                    <span class="icon is-small is-left">
                        <i class="fas fa-map-marker"></i>
                    </span>
                </p>
            </div>

            <div class="field">
                <p class="control has-icons-left">
                    <asp:TextBox runat="server" ID="identificacionTextBox" CssClass="input is-success" placeholder="Identificación" required></asp:TextBox>
                    <span class="icon is-small is-left">
                        <i class="fas fa-id-card"></i>
                    </span>
                </p>
            </div>

            <div class="field">
                <p class="control has-icons-left">
                    <asp:TextBox runat="server" ID="usuarioTextBox" CssClass="input is-success" placeholder="Usuario" required></asp:TextBox>
                    <span class="icon is-small is-left">
                        <i class="fas fa-user"></i>
                    </span>
                </p>
            </div>

            <div class="field">
                <p class="control has-icons-left">
                    <asp:TextBox runat="server" ID="claveTextBox" CssClass="input is-success" TextMode="Password" placeholder="Clave" required></asp:TextBox>
                    <span class="icon is-small is-left">
                        <i class="fas fa-lock"></i>
                    </span>
                </p>
            </div>

  

            <div class="buttons">
                <asp:Button runat="server" ID="Registrar" CssClass="button is-success" OnClick="Registrar_Click" Text="Registrarse" />
                <asp:Button runat="server" ID="Cancelar" CssClass="button is-light" Text="Cancelar" PostBackUrl="/UI/Index.aspx" />
            </div>

    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.3/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>
