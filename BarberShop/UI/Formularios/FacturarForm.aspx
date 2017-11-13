<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="FacturarForm.aspx.cs" Inherits="BarberShop.UI.Formularios.FacturarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">


            <div>

                <img src="../../Content/Img/Contactanos.png" class="img-responsive center-block" />
                <label for="Fecha" id="fecha">Fecha: </label>
                <asp:Label ID="LabelFecha" runat="server" Text=" "></asp:Label>
                <br />
                <label for="Atendido" id="atendido">Atendido Por: </label>
                <asp:Label ID="LabelAtentido" runat="server" Text=""></asp:Label>


            </div>
            <!-- input Factura Id---->
            <div class="text-center">
                <div>
                    <label for="facturarId">Id Factura</label>
                </div>
            </div>

            <div class="text-center">
                <asp:TextBox ID="facturaIdTextBox" runat="server" Height="33px" Width="190px" TextMode="Number"></asp:TextBox>
                <asp:Button ID="Buscar" CssClass="btn btn-danger btn-md " runat="server" Text="Buscar" Width="120px" ValidationGroup="buscar" OnClick="Buscar_Click" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="facturaIdTextBox" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="buscar"></asp:RequiredFieldValidator>

            </div>



            <!---------input del nombre del cliente-------->
            <div class="text-center">
                <div>
                    <label for="NombreCliente">Nombre Cliente</label>
                </div>
            </div>

            <div class="text-center">
                <asp:DropDownList ID="DropDownListClientes" runat="server" Height="33px" Width="190px">
                    <asp:ListItem Value="0"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="ButtonAgregarCliente" CssClass="btn btn-danger btn-md " runat="server" Text="Agregar" Width="120px" OnClick="ButtonAgregarCliente_Click" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownListClientes" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            </div>

            <!----input forma de pago--->
            <div class="text-center">
                <div>
                    <label for="formaPago">Forma de Pago </label>
                </div>
            </div>

            <div class="text-center">
                <asp:DropDownList ID="DropDownListPago" runat="server" Height="33px" Width="315px" CausesValidation="true">
                    <asp:ListItem Value="Contado">Contado</asp:ListItem>
                    <asp:ListItem>Credito</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListPago" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            </div>


            <!-----comentario------->

            <div class="text-center">
                <div>
                    <label for="Comentario">Comentario</label>
                </div>
            </div>
            <div class="text-center">
                <asp:TextBox ID="ComentarioTextBox" runat="server" Width="314px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ComentarioTextBox" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="guardar"></asp:RequiredFieldValidator>

            </div>




            <!-------descuento e Itbis------>
            <div class="text-center">
                <div>
                    <label for="Descuento">% Descuento</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <label for="Descuento">&nbsp;</label>
                </div>
            </div>

            <div class="text-center">
                <asp:TextBox ID="DescuentoTextBox" runat="server" Width="183px" Height="33px" TextMode="Number"></asp:TextBox>&nbsp;
                <asp:Button ID="ButtonAgregarServiciosGrid" CssClass="btn btn-danger btn-md " runat="server" Text="Agregar" Width="121px" OnClick="ButtonAgregarServiciosGrid_Click1" ValidationGroup="agregar" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DescuentoTextBox" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>

            </div>

            <!---------------------detalle de servicios------------------------>
            <div class="text-center">

                <div>
                    <label for="Codigo">Codigo</label>&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp; &nbsp&nbsp&nbsp;&nbsp; &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <label for="Servicios">Servicio</label>&nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label for="Precio">Precio</label>
                </div>
            </div>

            <div class="text-center">

                <asp:TextBox ID="CodTextBox" runat="server" Height="33px" Width="39px" Wrap="False"></asp:TextBox>
                <asp:ImageButton ID="ImageButtonSearch"  runat="server" Height="34px" ImageUrl="~/Content/Img/search_ .ico" CssClass="BorderTextBox" Width="23px" ImageAlign="Top" OnClick="ImageButtonSearch_Click" CausesValidation="true"  />
                <asp:TextBox ID="ServTextBox" runat="server" Height="33px" Width="170px" Wrap="False" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="PrecioTextBox" runat="server" Height="33px" Width="70px" Wrap="False" Enabled="False"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="CodTextBox" ErrorMessage="֎" Font-Bold="True" Font-Italic="True" ForeColor="Red" ValidationGroup="agregar"></asp:RequiredFieldValidator>

            </div>
            <br />
            <!--tabla del detalle-->
            <div class="text-center gridviewDetalle">

                <asp:GridView ID="GridViewDetalle" CssClass="text-center" runat="server" CellPadding="0" ClientIDMode="Static" ForeColor="#333333" Width="400px" ShowFooter="True" Height="100px" HorizontalAlign="Center" PageIndex="2" PageSize="2" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" Font-Bold="False" />
                    <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderColor="Black" BorderWidth="2px" HorizontalAlign="Justify" VerticalAlign="Top" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderStyle="Solid" Font-Italic="True" Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" BorderColor="Black" BorderWidth="2px" />
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderStyle="None" BorderWidth="2px" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" BorderStyle="Solid" BorderWidth="3px" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" BorderStyle="Solid" BorderWidth="3px" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>

            </div>
            <br />

            <!--------sub total---->
            <div class="text-center">

                <div>
                    <label for="sub">Sub-Total</label>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label for="Total">Total</label>&nbsp&nbsp;&nbsp; &nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <label for="Recibido">Recibido&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                    &nbsp;<label for="Devuelta">Devuelta</label>
                </div>
            </div>

            <div class="text-center">

                <asp:TextBox ID="SubTextBox" runat="server" Height="33px" Width="95px" TextMode="Number"></asp:TextBox>
                <asp:TextBox ID="TotalTextBox" runat="server" Height="33px" Width="95px" Wrap="False"></asp:TextBox>
                <asp:TextBox ID="RecibidoTextBox" runat="server" Height="33px" Width="95px" Wrap="False"></asp:TextBox>
                <asp:TextBox ID="DevueltaTextBox" runat="server" Height="33px" Width="98px" Wrap="False"></asp:TextBox>


            </div>
            <br />
            <!--botones ---->
            <div class="text-center">

                <asp:Button ID="Nuevo" CssClass="btn btn-danger btn-md " runat="server" Text="Nuevo" Width="125px" OnClick="Nuevo_Click" />&nbsp&nbsp
                    <asp:Button ID="guardar" CssClass="btn btn-danger btn-md " runat="server" Text="Guardar" ValidationGroup="guardar" OnClick="guardar_Click" Width="125px" />&nbsp;&nbsp&nbsp
                    <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-md " runat="server" Text="Eliminar" Width="125px" OnClick="Eliminar_Click" />
            </div>


        </div>

    </div>
    <br />
    <br />

</asp:Content>
