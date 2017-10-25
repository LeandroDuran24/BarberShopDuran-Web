<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="UsuariosForm.aspx.cs" Inherits="BarberShop.UI.Formularios.UsuariosForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Registro Usuarios <span class="glyphicon glyphicon-user"></span></h1>
    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--input del id-->
            <div class="text-center">
                <div>
                    <label for="id_Usuario">Id Usuario</label>
                </div>
            </div>
            <div class="text-center">

                <asp:TextBox ID="idTextbox" runat="server" Width="190px" Height="33px" ForeColor="Black" onkeypress="return soloNumeros(event)"></asp:TextBox>&nbsp
                     <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md " runat="server" Text="Buscar" OnClick="Buscar_Click" Width="105px" ValidationGroup="buscar" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="idTextbox" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>
            </div>

            <!--input del nombre-->
            <div class="text-center">
                <div>
                    <label for="Nombres">Nombres</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="NombreTextbox" runat="server" Width="300px" Height="33px" onkeypress="return soloLetras(event)"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextbox" ErrorMessage="֎" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            </div>

            <!--input del email-->
            <div class="text-center">
                <div>
                    <label for="Email">Email</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="emailTextbox" runat="server" Width="300px" Height="33px" onkeypress="return soloLetras(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailTextbox" ErrorMessage="֎" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>
            </div>

            <!--input de fecha-->
            <div class="text-center">
                <div>
                    <label for="fecha">Fecha</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="fecha" runat="server" Width="300px" Height="33px" TextMode="Date"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="fecha" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" BackColor="White" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>


            <!--input del tipo-->
            <div class="text-center">
                <div>
                    <label for="tipo_Email">Tipo Email</label>
                </div>
            </div>
            <div class="text-center">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="300px" Height="33px">
                    <asp:ListItem Value="Admintrador">Admin</asp:ListItem>
                    <asp:ListItem>Usuario</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownList1" ErrorMessage="֎" Font-Bold="True" Font-Italic="False" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>
            </div>

            <!--input del clave-->

            <div class="text-center">
                <div>
                    <label for="contrasena">Contraseña</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox type="password" ID="claveTextbox" runat="server" Width="300px" Height="33px" onkeypress="return soloNumeros(event)"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="claveTextbox" ErrorMessage="֎" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>
            </div>

            <!--input del confirmar-->
            <div class="text-center">
                <div>
                    <label for="confirmar_Contraseña">Confirmar Contraseña</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox Type="password" ID="confTextbox" runat="server" Width="300px" Height="33px" onkeypress="return soloNumeros(event)"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="confTextbox" ErrorMessage="֎" Font-Bold="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            </div>
            <br />


            <!--botones del formulario-->

            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" OnClick="Nuevo_Click" />&nbsp&nbsp
                    <asp:Button ID="Button1" CssClass="btn btn-danger btn-md " runat="server" OnClick="Button1_Click" Text="Guardar" ValidationGroup="guardar" />&nbsp&nbsp
                    <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" OnClick="Eliminar_Click" />
            </div>
            <br />


        </div>
    </div>


</asp:Content>
