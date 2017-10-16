<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="FacturarForm.aspx.cs" Inherits="BarberShop.UI.Formularios.FacturarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <%--<a href="../../Content/Img/Contactanos.png" target="_blank">--%>
            <img src="../../Content/Img/Contactanos.png" class="img-responsive center-block" />

            <!-- input Factura Id---->
            <div class="text-center">
                <div>
                    <label for="facturarId">Id Factura</label>
                </div>
            </div>

            <div class="text-center">
                <asp:textbox id="facturaIdTextBox" runat="server" height="33px" width="190px"></asp:textbox>
                <asp:button id="Buscar" cssclass="btn btn-danger btn-md " runat="server" text="Buscar" width="120px" validationgroup="buscar" onclick="Buscar_Click" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" controltovalidate="facturaIdTextBox" errormessage="֎" font-bold="True" font-italic="True" forecolor="Red" validationgroup="buscar"></asp:requiredfieldvalidator>

            </div>


            <!------input fecha--->

            <%--<asp:textbox id="FechaTextbox" class="text-right" runat="server" height="23px" width="225px"></asp:textbox>--%>


            <!---------input del nombre del cliente-------->
            <div class="text-center">
                <div>
                    <label for="NombreCliente">Nombre Cliente</label>
                </div>
            </div>

            <div class="text-center">
                <asp:dropdownlist id="DropDownListClientes" runat="server" height="33px" width="190px"></asp:dropdownlist>
                <asp:button id="ButtonAgregarCliente" cssclass="btn btn-danger btn-md " runat="server" text="Agregar" width="120px" />
                <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" controltovalidate="DropDownListClientes" errormessage="֎" font-bold="True" font-italic="True" forecolor="Red" validationgroup="buscar"></asp:requiredfieldvalidator>

            </div>

            <!----input forma de pago--->
            <div class="text-center">
                <div>
                    <label for="formaPago">Forma de Pago&nbsp; </label>
                </div>
            </div>

            <div class="text-center">
                <asp:textbox id="PagoTextBox" runat="server" width="310px" height="33px"></asp:textbox>
                <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" controltovalidate="PagoTextBox" errormessage="֎" font-bold="True" font-italic="True" forecolor="Red" validationgroup="buscar"></asp:requiredfieldvalidator>

            </div>


            <!-----comentario------->

            <div class="text-center">

                <label for="Comentario">Comentario</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <textarea id="TextAreaComentario" name="S1" rows="3"></textarea>
                <!----input de descuento------->

                &nbsp;&nbsp;<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

 
            </div>

            <!-------descuento------>
            <div class="text-center">
                <label for="Descuento">% Descuento</label>
                <asp:textbox id="DescuentoTextBox" runat="server" height="33px"></asp:textbox>
                <br />
            </div>

            <!----impuesto----->
            <div class="text-center">

                <label for="Impuesto">ITBIS</label>

                <asp:textbox id="TextBox2" runat="server" height="33px"></asp:textbox>
            </div>






        </div>
    </div>

</asp:Content>
