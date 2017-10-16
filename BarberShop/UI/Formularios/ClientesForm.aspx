<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ClientesForm.aspx.cs" Inherits="BarberShop.UI.Formularios.ClientesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Registro Clientes<span class="glyphicon glyphicon-user"></span></h1>

    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--id del cliente-->
            <div class="text-center">
                <div>
                    <label for="id cliente">Id Cliente</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="idClienteTextbox" runat="server" Width="190px" Height="33px"></asp:TextBox>
                <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md " runat="server" Text="Buscar" Width="105px" OnClick="Buscar_Click"  ValidationGroup="buscar"  />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="֎" ValidationGroup="buscar" ControlToValidate="idClienteTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>



            <!--Nombre del cliente-->
            <div class="text-center">
                <div >
                    <label for="nombre">Nombre</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="NombreClienteTextbox" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="NombreClienteTextbox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>



            <!--Apellidos del Cliente-->
            <div class="text-center">
                <div>
                    <label for="apellidos">Apellidos</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="ApellidosTextBox1" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="ApellidosTextBox1" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <!--direccion-->
            <div class="text-center">
                <div>
                    <label for="direccion">Direccion</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="DireccionTextBox2" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="DireccionTextBox2" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <!--Cedula-->
            <div class="text-center">
                <div>
                    <label for="cedula">Cedula</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="CedulaTextBox3" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="CedulaTextBox3" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <!--Email-->
            <div class="text-center">
                <div>
                    <label for="email">Email</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox type="email" ID ="EmailTextBox4" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="EmailTextBox4" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>


            <!--fecha-->
            <div class="text-center">
                <div>
                    <label for="fecha">Fecha</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="FechaTextBox5" runat="server" Width="300px" Height="33px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="FechaTextBox5" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />

            <!--botones del formulario-->

            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" OnClick="Nuevo_Click2"    />&nbsp&nbsp
                <asp:Button ID="Guardar" CssClass="btn btn-danger btn-md " runat="server" Text="Guardar" OnClick="Guardar_Click" ValidationGroup="guardar"   />&nbsp&nbsp
                <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" OnClick="Eliminar_Click"   />
            </div>

            <br />

        </div>
    </div>



</asp:Content>
