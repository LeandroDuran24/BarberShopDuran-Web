<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BarberShop.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesion</title>


    <!---------------------------------------------Bootstrap-------------------------------------------------------->
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/bootstrap.min.js" />

    <!--------------------------------------------Tema-------------------------------------------------------------->
    <link rel="stylesheet" href="/Content/bootstrapTheme.min.css" />
    <!-------------------------------------------Style-------------------------------------------------------------->
    <link rel="stylesheet" href="/Content/Style/Style.css" />
    <!---------------------------------------------Script--------------------------------------------------------->


</head>
<body background="/Content/Img/barbershop-inspired-hairstyles-for-men-1108769-TwoByOne.jpg">
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="col-lg-12 col-md-6  col-sm-8 col-xs-12">
                <header>
                    <h1 class="text-center Header-Login">Iniciar Sesion</h1>
                </header>

                <!-----------------contenido----------->

                <!--email-->
                <div class="text-center">
                    <div class="Label-LogIn">
                        <label for="emailLable">Email</label>
                    </div>
                </div>
                <div class="text-center">
                    <asp:TextBox ID="EmailTextBox" runat="server" Width="300px" Height="33px" MaxLength="15" placeholder="Enter Email"></asp:TextBox>&nbsp
                </div>



                <!--clave-->

                <div class="text-center">
                    <div class="Label-LogIn ">
                        <label for="PassWord">Password</label>
                    </div>
                </div>

                <div class="text-center">
                    <asp:TextBox Type="password" ID="PassTextBox1" runat="server" Width="300px" Height="33px" MaxLength="10" placeholder="Enter Password"></asp:TextBox>&nbsp
                        <br />
                    <br />
                </div>


                <!--Boton-->
                <div class="text-center">
                    <asp:Button ID="LoginButton" CssClass="btn btn-danger btn-md " runat="server" Text="LogIn" Width="96px" OnClick="LoginButton_Click" />&nbsp&nbsp
                  
               
                </div>

            </div>
        </div>
    </form>
</body>
</html>
