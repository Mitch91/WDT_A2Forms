<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="WDTAss2Forms.DeleteProduct" %>

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
                <a class="navbar-brand" href="DataManagement.aspx">Whiz-bang! Admin</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav navbar-left">
                    <li><a href="/DataManagement.aspx">Select Category</a></li>
                    <li><a href="/UploadImage.aspx">Upload image</a></li>

                </ul>

            </div>
            <!--/.nav-collapse -->
        </div>
    </div>


    <form id="Delete_Product" runat="server">


        <asp:Panel ID="Delete_Panel" HorizontalAlign="Center" runat="server">

            <h1>
                <img runat="server" src="images/whizbang.png" style="width: 20%; height: 20%" alt="Whiz-bang - A whiz-bang of wonders!" /></h1>


                <asp:label id="status" runat="server" />


            <br />
            <asp:HyperLink ID="dataMangementLink" runat="server" NavigateUrl="~/DataManagement.aspx" OnClick="Reset">Back to Data Mangement Page</asp:HyperLink>


        </asp:Panel>




        <!-- dynamic viewport/panel for list of products-->
        <asp:Panel ID="Viewport_Delete" HorizontalAlign="Center" runat="server"></asp:Panel>



    </form>


</body>
</html>
