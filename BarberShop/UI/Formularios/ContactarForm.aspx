<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ContactarForm.aspx.cs" Inherits="BarberShop.UI.Formularios.ContactarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Content/Style/Style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--<a href="../../Content/Img/Contactanos.png" target="_blank">--%>
    <img src="../../Content/Img/Contactanos.png" class="img-responsive center-block" />


    &nbsp;<div class="caption">
        <p class="text-center">Barber Shop Duran</p>
    </div>


    <!--icono de telefono con los telefonos----->
    <div class="text-center">
        <br />
        <span class="glyphicon glyphicon-earphone Iconos">
            <h4>Tel:809-290-8636/Cel:829-367-7767</h4>
        </span>
        <br />
    </div>
    <!----------- icono de mail ---->
    <div class="text-center">
        <span class="glyphicon glyphicon-envelope Iconos">
            <h4><a href="mailto:leandrorafael_24@hotmail.com?&subject=&body=">Email:Leandrorafael_24@hotmail.com</a></h4>
        </span>
    </div>

    <!-------icono de ubicacion con mapa------>
    <div class="text-center">
        <span class="glyphicon glyphicon-map-marker Iconos"></span>
        <div id="map" style="width: 1150px; height: 400px; background: gray"></div>
    </div>

    <br />

    <!------------------------script para google map-------------------->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBu-916DdpKAjTmJNIgngS6HL_kDIKU0aU&callback=myMap"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script>

    <script src="/../../Content/Script.js"></script>

</asp:Content>
