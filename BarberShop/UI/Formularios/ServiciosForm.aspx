<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ServiciosForm.aspx.cs" Inherits="BarberShop.UI.Formularios.ServiciosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Registro Servicios <span class="glyphicon glyphicon-cog"></span></h1>

    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--input del id-->
            <div class="text-center">
                <div>
                    <label for="id_peluquero">Id Servicio</label>
                </div>
            </div>
            <div class="text-center">

                <asp:TextBox ID="idTextbox" runat="server" Width="190px" Height="33px" onkeypress="return soloNumeros(event)"></asp:TextBox>&nbsp
                     <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md" runat="server" Text="Buscar" OnClick="Buscar_Click" ValidationGroup="buscar" Width="105px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="֎" ValidationGroup="buscar" ControlToValidate="idTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del nombre-->
            <div class="text-center">
                <div>
                    <label for="Nombres">Nombre</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="NombreTextbox" runat="server" Width="300px" Height="33px" onkeypress="return soloLetras(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="NombreTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <!--input del costo-->
            <div class="text-center">
                <div>
                    <label for="costo">Costo </label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="CostoTextBox1" runat="server" Width="300px" Height="33px" onkeypress="return soloNumeros(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="CostoTextBox1" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />


            <!--botones del formulario-->

            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" OnClick="Nuevo_Click" />&nbsp&nbsp
                    <asp:Button ID="guardar" CssClass="btn btn-danger btn-md " runat="server" Text="Guardar" OnClick="guardar_Click" ValidationGroup="guardar" />&nbsp;&nbsp&nbsp
                    <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" OnClick="Eliminar_Click" />
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />


        </div>
    </div>
    <br />
    <br />


    <!------------------script ----------------->
    <script src="/../../Content/Script.js"></script>
</asp:Content>
