<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="PeluquerosForm.aspx.cs" Inherits="BarberShop.UI.Formularios.PeluquerosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class=" text-center">Registro Peluqueros <span class="glyphicon glyphicon-scissors"></span></h1>
    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--input del id-->
            <div class="text-center">
                <div>
                    <label for="id_peluquero">Id Peluquero</label>
                </div>
            </div>
            <div class="text-center">

                <asp:TextBox ID="idTextbox" runat="server" Width="205px" Height="33px"></asp:TextBox>&nbsp
                     <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md " runat="server" Text="Buscar" OnClick="Buscar_Click" ValidationGroup="buscar" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="֎" ValidationGroup="buscar" ControlToValidate="idTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del nombre-->
            <div class="text-center">
                <div>
                    <label for="Nombres">Nombre</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="NombreTextbox" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="NombreTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del telefono-->
            <div class="text-center">
                <div>
                    <label for="Telefono">Telefono</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="TelefonoTextBox" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="TelefonoTextBox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del sexo-->
            <div class="text-center">
                <div>
                    <label for="sexo">Sexo</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="SexoTextBox" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="SexoTextBox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del fecha-->
            <div class="text-center">
                <div>
                    <label for="sexo">Fecha</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="FechaTextBox1" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="FechaTextBox1" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <br />
            <br />



            <!--botones del formulario-->

            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" OnClick="Nuevo_Click" />&nbsp&nbsp
                    <asp:Button ID="guardar" CssClass="btn btn-danger btn-md " runat="server" Text="Guardar" OnClick="guardar_Click" ValidationGroup="guardar" />&nbsp;&nbsp&nbsp
                    <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" OnClick="Eliminar_Click" />
            </div>

        </div>
    </div>


</asp:Content>
