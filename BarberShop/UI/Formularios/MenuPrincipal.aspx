<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="BarberShop.UI.Formularios.MenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-----------------------------------------------------------img del centro-------------------------------------------------->
    <!-- Wrapper for slides -->
 <div class="align-content-md-center">
    <div id="myCarousel" class="carousel slide" data-ride="carousel" >
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <div class="carousel-inner text-center" role="listbox">
            <div class="item active" >
                <img src="../../Content/Img/Model1.png" alt="New York" width="500" height="500">

            </div>

            <div class="item ">
                <img src="../../Content/Img/Model2.png" alt="Chicago" width="500" height="500" >
            </div>

            <div class="item">
                <img src="../../Content/Img/Model3.png" alt="Los Angeles" width="500" height="500">
            </div>
        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    </div>
    <br />
</asp:Content>
