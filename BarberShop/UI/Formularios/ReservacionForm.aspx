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

                <asp:textbox id="idTextbox" runat="server" width="190px" height="33px" textmode="Number"></asp:textbox>
                &nbsp
                     <asp:button id="Buscar" cssclass="btn btn-danger btn-md " runat="server" text="Buscar" width="105px" onclick="Buscar_Click1" />
            </div>

            <!--input del nombre cliente-->
            <div class="text-center">
                <div>
                    <label for="Nombres">Nombre Cliente</label>
                </div>
            </div>
            <div class="text-center">
                <asp:dropdownlist id="DropDownListCliente" runat="server" width="300px" height="33px">
                </asp:dropdownlist>
            </div>

            <!--input del Nombre Peluquero-->
            <div class="text-center">
                <div>
                    <label for="peluquero">Nombre Peluquero</label>
                </div>
            </div>
            <div class="text-center">
                <asp:dropdownlist id="DropDownListPeluquero" runat="server" width="300px" height="33px">
                </asp:dropdownlist>
            </div>

            <!--input de fecha desde-->
            <div class="text-center">
                <div>
                    <label for="fecha_desde">Hora Desde</label>
                </div>
            </div>
            <div class="text-center">
                <asp:textbox type="time" id="FechaDesde" runat="server" width="300px" height="33px"></asp:textbox>
            </div>

            <!--input de fecha Hasta-->
            <div class="text-center">
                <div>
                    <label for="fecha_Hasta">Hora Hasta</label>
                </div>
            </div>
            <div class="text-center">
                <asp:textbox type="time" id="fechaHasta" runat="server" width="300px" height="33px"></asp:textbox>
            </div>

            <!--input de fecha -->
            <div class="text-center">
                <div>
                    <label for="fecha">Fecha</label>
                </div>
            </div>
            <div class="text-center">
                <asp:textbox id="FechaTextbox" runat="server" width="300px" height="33px"></asp:textbox>
            </div>


            <br />


            <!--botones del formulario-->

            <div class="text-center">

                <asp:button id="Nuevo" cssclass="btn btn-danger btn-md " runat="server" text="Nuevo" onclick="Nuevo_Click" />
                &nbsp&nbsp
                <asp:button id="guardar" cssclass="btn btn-danger btn-md " runat="server" text="Guardar" onclick="guardar_Click" />
                &nbsp;&nbsp&nbsp
                <asp:button id="Eliminar" cssclass="btn btn-danger btn-md " runat="server" text="Eliminar" />
            </div>

        </div>
    </div>
    <br />
    <br />

</asp:Content>
