<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ReservacionForm.aspx.cs" Inherits="BarberShop.UI.Formularios.ReservacionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class=" text-center">Registro de Reservaciones <span class="glyphicon glyphicon-calendar"></span></h1>

    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--input del id-->
            <div class="text-center">
                <div>
                    <label for="id_Turno">Id Reservacion</label>
                </div>
            </div>
            <div class="text-center">

                <asp:TextBox ID="idTextbox" runat="server" Width="190px" Height="33px" TextMode="Number"></asp:TextBox>&nbsp
                     <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md " runat="server" Text="Buscar" Width="105px" OnClick="Buscar_Click1" />
            </div>

            <!--input del nombre cliente-->
            <div class="text-center">
                <div>
                    <label for="Nombres">Nombre Cliente</label>
                </div>
            </div>
            <div class="text-center">
                <asp:DropDownList ID="DropDownListCliente" runat="server" Width="300px" Height="33px">
                </asp:DropDownList>
            </div>

            <!--input del Nombre Peluquero-->
            <div class="text-center">
                <div>
                    <label for="peluquero">Nombre Peluquero</label>
                </div>
            </div>
            <div class="text-center">
                <asp:DropDownList ID="DropDownListPeluquero" runat="server" Width="300px" Height="33px">
                </asp:DropDownList>
            </div>

            <!--input de fecha desde-->
            <div class="text-center">
                <div>
                    <label for="fecha_desde">Fecha Desde</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="FechaDesde" runat="server" Width="300px" Height="33px" TextMode="Date"></asp:TextBox>
            </div>

            <!--input de fecha Hasta-->
            <div class="text-center">
                <div>
                    <label for="fecha_Hasta">Fecha Hasta</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="fechaHasta" runat="server" Width="300px" Height="33px" TextMode="Date"></asp:TextBox>
            </div>


            <br />


            <!--botones del formulario-->

            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" OnClick="Nuevo_Click" />&nbsp&nbsp
                <asp:Button ID="guardar" CssClass="btn btn-danger btn-md " runat="server" Text="Guardar" OnClick="guardar_Click" />&nbsp;&nbsp&nbsp
                <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" />
            </div>

        </div>
    </div>
    <br />
    <br />

</asp:Content>
