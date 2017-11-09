<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="FacturasCons.aspx.cs" Inherits="BarberShop.UI.Consultas.FacturasCons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class=" text-center">Consulta Facturas <span class="glyphicon glyphicon-file"></span></h1>

    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--comboBox-->
            <div class="text-center">
                <label for="Busqueda:">Busqueda</label>

                <asp:dropdownlist id="DropDownList1" runat="server" autopostback="True" width="110px" height="22px">
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>Todos</asp:ListItem>
                </asp:dropdownlist>
                &nbsp


                    <asp:textbox id="TextBox1" runat="server" width="150px"></asp:textbox>
                <asp:button id="ButtonBuscar" cssclass="btn btn-danger" runat="server" text="Filtrar" OnClick="ButtonBuscar_Click"  />

            </div>

            <!--fecha-->
            <div class="text-center">
                <p>
                    <label for="Desde:">Desde </label>
                    &nbsp;<asp:textbox id="desdeFecha" runat="server" width="120px" textmode="Date"></asp:textbox>
                    <label for="hasta">Hasta</label>
                    <asp:textbox id="hastaFecha" runat="server" width="120px" textmode="Date"></asp:textbox>


                    <asp:button id="ButtonImprimir" runat="server" text="Imprimir" cssclass="btn btn-danger" OnClick="ButtonImprimir_Click"  />


                </p>

            </div>

            <div class="text-center align-content-center">
                <div style="overflow: auto; width: 1100px; height: 315px;">



                    <asp:gridview id="GridView1" runat="server" cellpadding="0" clientidmode="Static" forecolor="#333333" width="1100px" showfooter="True" captionalign="Left" height="100px" horizontalalign="Center" pageindex="2" pagesize="2">
                        <AlternatingRowStyle BackColor="White" Font-Bold="False" />
                        <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" BorderStyle="Solid" Font-Italic="True" Font-Size="12pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:gridview>



                </div>
            </div>
        </div>
    </div>





</asp:Content>
