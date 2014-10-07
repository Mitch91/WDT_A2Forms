<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WDTAss2Forms.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Whiz-bang! Admin</title>

    <style>

        label {
        
         float: left;   
        
        }

    </style>


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
                    <li><a href="DataManagement.aspx">Select Category</a></li>
                    <li><a href="UploadImage.aspx">Upload image</a></li>

                </ul>

            </div>
            <!--/.nav-collapse -->
        </div>
    </div>


    <form id="Add_Product" runat="server">


        <asp:Panel ID="Add_Panel" HorizontalAlign="Center" runat="server">

            <h1>
                <img src="images/whizbang.png" style="width: 20%; height: 20%" alt="Whiz-bang - A whiz-bang of wonders!" /></h1>




            <div class="container">
                <div class="row">
                    <div class="col-lg-12">


                 
                         <asp:Panel ID="Add_Form" HorizontalAlign="Center" runat="server">

    
                        <label>Enter product ID: <input id='product_id' type='text' size='30' runat='server' /> </label><br/><br/>
                        <label>Enter category ID: <input id='category_id' type='text' size='30' runat='server' /></label><br/><br/>
                        <label>Enter title: <input id='title' type='text' size='30' runat='server' /></label><br/><br/>
                        <label> Enter short description: <input id='short_decr' type='text' size='50' runat='server' /></label><br/><br/>
                        <label>Enter long description: <input id='long_descr' type='text' size='100' runat='server' /></label><br/><br/>
                        <label> Enter price: <input id='price' type='text' size='30' runat='server' /></label><br/><br/>   

                          
                            <asp:Button ID="Submit_Add" runat="server" OnClick="Add_Click" Text="Submit" />
                  
              

                             </asp:Panel>
                  

                    </div>
                </div>


            </div>


        </asp:Panel>




        <!-- dynamic viewport/panel for list of products-->
        <asp:Panel ID="Viewport_Add" HorizontalAlign="Center" runat="server"></asp:Panel>



    </form>


</body>
</html>
