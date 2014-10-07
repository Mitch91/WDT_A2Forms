<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataManagement.aspx.cs" Inherits="WDTAss2Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Whiz-bang! Admin</title>


    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap-theme.min.css" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <script src="scripts/bootbox.min.js"></script>

    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.2/js/jquery.dataTables.js"></script>


</head>
<body>

    <!-- NAV BAR -->
    <div class="navbar navbar-default navbar-static-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#/home">Whiz-bang! Admin</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-left">
                    <li><a href="DataManagement.aspx">Select Category</a></li>
                    <li><a href="UploadImage.aspx">Upload image</a></li>

                </ul>

            </div>
            <!--/.nav-collapse -->
        </div>
    </div>


    <form id="Form_Data" runat="server">


        <!--  static panel for dropdown box and logo -->
        <asp:Panel ID="Data_Manage" HorizontalAlign="Center" runat="server">

            <h1>
                <img src="images/whizbang.png" style="width: 20%; height: 20%" alt="Whiz-bang - A whiz-bang of wonders!" />
            </h1>


            <asp:DropDownList ID="Categories" runat="server">
    
            </asp:DropDownList>
            <!--
            <asp:Button ID="Generate" runat="server" OnClick="Generate_Click" Text="Get categories" />
            -->

            <div class="container">
                <div class="row">
                    <div class="col-lg-12">

                        <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Submit" />

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">

                        <asp:Button ID="Add_Product" runat="server" Text="Add product" OnClick="Add_Product_Click" />

                    </div>
                    <div class="col-md-6">

                        <asp:Button ID="Delete_Category" runat="server" Text="Delete category" OnClick="Delete_Category_Click" />

                    </div>
                </div>

            </div>


        </asp:Panel>



        <!-- dynamic viewport/panel for list of products-->
        <asp:Panel ID="Viewport_Data" HorizontalAlign="Center" runat="server"></asp:Panel>



    </form>



</body>
</html>
