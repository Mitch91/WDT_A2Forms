using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WDTAss2Forms.App_Code;

namespace WDTAss2Forms
{
    public partial class EditProduct : System.Web.UI.Page
    {
        Boolean loaded = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine(loaded);
            if (!IsPostBack)
            {
                String productId = null;
                loaded = true;
                if(!String.Equals(Request.QueryString["productID"], null))
                    productId = Request.QueryString["productID"];
                
                Product product = DatabaseSystem.GetInstance().GetProductForId(productId);
                if (product == null) return;

                FillDropDown();
                

                Categories.SelectedValue = product.categoryId;
                ProductTitle.Value = product.title;
                ShortDesc.Value = product.shortDescription;
                LongDesc.Value = product.longDescription;
                Price.Value = product.price;

                
            }
        }

        private void FillDropDown()
        {

            List<Category> categoryList = DatabaseSystem.GetInstance().GetCategories();

            foreach (Category category in categoryList)
            {
                if (Categories.Items.FindByValue(category.categoryId) != null)
                    continue;

                ListItem item = new ListItem();
                item.Text = category.title;
                item.Value = category.categoryId;
                Categories.Items.Add(item);
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            String message;
            String msgTitle;
            String productId = Request.QueryString["productID"];

            Debug.WriteLine("Cat: " + Categories.SelectedValue + "\nTitle: " + ProductTitle.Value + "\nShort: " + ShortDesc.Value + "\nLong: " + LongDesc.Value + "Price: " + Price.Value);

            if(DatabaseSystem.GetInstance().UpdateProduct(new Product(
                    productId, Categories.SelectedValue,
                    ProductTitle.Value, ShortDesc.Value,
                    LongDesc.Value, Price.Value)))
            {
                message = "Successfully updated product: " + ProductTitle.Value;
                msgTitle = "Update Successful";
            }
            else
            {
                message = "Unable to update the product " + ProductTitle.Value;
                msgTitle = "Unable to Update Product";
            }

            String jquery = @"<script>
                    $(function() {
               
                            bootbox.dialog({
                                message: '" + message + @"',
                                title: '" + msgTitle + @"',
                                buttons: {
                                    main: {
                                        label: 'OK',
                                        callback: function(){
                                            window.location.href = 'DataManagement.aspx';
                                        }
                                    }
                                }
                            });
                    });
                    </script>";

            Viewport_Edit.Controls.Add(new LiteralControl(jquery));
        }
    }
}