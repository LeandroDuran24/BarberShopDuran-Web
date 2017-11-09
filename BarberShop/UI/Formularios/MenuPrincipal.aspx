<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="BarberShop.UI.Formularios.MenuPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-----------------------------------------------------------img del centro-------------------------------------------------->
    <!-- Wrapper for slides -->
    <div class="align-content-md-center">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="4"></li>

            </ol>


             <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>




            <div class="carousel-inner" role="listbox">
                <div class="item">
                    <img src="/../../Content/Img/Model1.png">
                </div>

                <div class="item ">
                    <img src="/../../Content/Img/Model2.png">
                </div>

                <div class="item">
                    <img src="/../../Content/Img/Model3.png">
                </div>

                <div class="item active">
                    <img src="/../../Content/Img/Model4.png">
                </div>

                <div class="item">
                    <video width="1138" height="447" controls>
                        <source src="/../../Content/Img/Model5.mp4" type="video/mp4">
                        <source src="/../../Content/Img/Model5.ogg" type="video/ogg">
                    </video>
                </div>
            </div>


           


        </div>
    </div>
    <br />
</asp:Content>
