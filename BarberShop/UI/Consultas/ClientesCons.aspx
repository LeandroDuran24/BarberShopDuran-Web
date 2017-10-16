<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ClientesCons.aspx.cs" Inherits="BarberShop.UI.Consultas.ClientesCons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 class=" text-center">Consulta Clientes <span class="glyphicon glyphicon-user"></span></h1>

    <div class="container-fluid">
        <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">

            <!--comboBox-->
            <div class="text-center">
                <label for="Busqueda:">Busqueda</label>

                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="110px" Height="22px">
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>Todos</asp:ListItem>
                </asp:DropDownList>
                &nbsp


                    <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>
                <asp:Button ID="ButtonBuscar" CssClass="btn btn-danger" runat="server" Text="Filtrar" OnClick="ButtonBuscar_Click"  />

            </div>

            <!--fecha-->
            <div class="text-center">
                <p>
                    <label for="Desde:">Desde </label>
                    &nbsp;<asp:TextBox ID="desdeFecha" runat="server" Width="120px"></asp:TextBox>
                    <label for="hasta">Hasta</label>
                    <asp:TextBox ID="hastaFecha" runat="server" Width="120px"></asp:TextBox>
                    

                    <asp:Button ID="ButtonImprimir" runat="server" Text="Imprimir" CssClass="btn btn-danger"/>
                    

                </p>

            </div>

            <div class="text-center align-content-center">
                <div style="overflow: auto; width: 1100px; height: 315px;">



                    <asp:GridView ID="GridView1" runat="server" CellPadding="0" ClientIDMode="Static" ForeColor="#333333" Width="1100px" ShowFooter="True" CaptionAlign="Left" Height="100px" HorizontalAlign="Center" PageIndex="2" PageSize="2">
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
                    </asp:GridView>



                </div>
            </div>
        </div>
    </div>



</asp:Content>
