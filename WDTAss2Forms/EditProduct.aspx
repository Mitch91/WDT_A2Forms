<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WDTAss2Forms.EditProduct" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Whiz-bang! Admin</title>

        <style type ="text/css">

            label {
        
             float: left;   
        
            }

        </style>


        <script type="text/javascript" src="//code.jquery.com/jquery-1.11.0.min.js"></script>
        <script type="text/javascript" src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>
        <!-- Latest compiled and minified CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />

        <!-- Optional theme -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap-theme.min.css" />

        <!-- Latest compiled and minified JavaScript -->
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

        <script type="text/javascript" src="scripts/bootbox.min.js"></script>

        <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />
        <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.2/js/jquery.dataTables.js"></script>


    </head>
<body>
    <form id="Edit_Product" runat="server">

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
    
        <asp:Panel ID="Edit_Panel" HorizontalAlign="Center" runat="server">

            <h1>
                <img src="images/whizbang.png" style="width: 20%; height: 20%" alt="Whiz-bang - A whiz-bang of wonders!" />
            </h1>

            <div class="container">
                <div class="row">
                    <div class="col-lg-12">                 
                        <asp:Panel ID="Edit_Form" HorizontalAlign="Center" runat="server">

                            <label>Enter category ID:</label>

                            <asp:DropDownList ID="Categories" runat="server" style="height: 22px"></asp:DropDownList>

                            <br /><br />

                            <label>Enter title:</label>
                            <input id='ProductTitle' type='text' size='30' runat='server'/>
                            <asp:RequiredFieldValidator 
	                            ID="RequireTitleFieldValidator" 
	                            runat="server" ControlToValidate="ProductTitle" 
	                            ErrorMessage="Title cannot be Empty">

                            </asp:RequiredFieldValidator>

                            <br/><br/>

                            <label> Enter short description:</label>
                            <input id='ShortDesc' type='text' size='50' runat='server' />

                            <br/><br/>

                            <label>Enter long description:</label>
                            <input id='LongDesc' type='text' size='100' runat='server' />

                            <br/><br/>

                            <label>Enter price:</label>
                            <input id='Price' type='text' size='30' runat='server' />
                            <asp:RequiredFieldValidator 
	                            ID="RequirePriceFieldValidator" 
	                            runat="server" ControlToValidate="price"
	                            ErrorMessage="Price cannot be empty">
                            </asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator 
                                ID="PriceRegexValidator" 
                                runat="server" ControlToValidate="Price" 
                                ErrorMessage="Must be a valid money value" 
                                ValidationExpression="^[0-9]*(\.[0-9]{0,2}|)$">
                            </asp:RegularExpressionValidator>

                            <br/><br/>   

                            <asp:Button ID="Submit_Edit" runat="server" OnClick="Edit_Click" Text="Submit" />

                       </asp:Panel>
                  

                    </div>
                </div>


            </div>


        </asp:Panel>

        <asp:Panel ID="Viewport_Edit" HorizontalAlign="Center" runat="server"></asp:Panel>

    </form>
</body>
</html>
