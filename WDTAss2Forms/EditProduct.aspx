<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WDTAss2Forms.EditProduct" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<!--#include file="Head.asp"-->

    

<body>
    <form id="Edit_Product" runat="server">

    <!-- NAV BAR -->
    <!--#include file="NavBar.asp"-->
    
        <asp:Panel ID="Edit_Panel" runat="server">

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
	                            ErrorMessage="Title cannot be Empty"></asp:RequiredFieldValidator>

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
