<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BarberShop.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesion</title>


    <!---------------------------------------------Bootstrap-------------------------------------------------------->
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/bootstrap.min.js" />

    <!-------------------------------------------Style-------------------------------------------------------------->
    <link rel="stylesheet" href="/Content/Style/Style.css" />
    <!--------------------------------------------------toastr----------------------------------------------------->


    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet" />
    <script src="//code.jquery.com/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js" type="text/javascript"></script>--%>

    <link href ="/Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>

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
                    <asp:TextBox ID="EmailTextBox" CssClass="BorderTextBox" runat="server" Width="300px" Height="33px" MaxLength="15" placeholder="Enter Email" AutoCompleteType="Disabled"></asp:TextBox>&nbsp
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="EmailTextBox" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>



                <!--clave-->

                <div class="text-center">
                    <div class="Label-LogIn ">
                        <label for="PassWord">Password</label>
                    </div>
                </div>

                <div class="text-center">
                    <asp:TextBox Type="password" ID="PassTextBox1" CssClass="BorderTextBox" runat="server" Width="300px" Height="33px" MaxLength="10" placeholder="Enter Password"></asp:TextBox>&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="֎" ValidationGroup="guardar" ControlToValidate="PassTextBox1" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
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
    <!----------------------------------script--------------------------------------->



</body>




</html>
