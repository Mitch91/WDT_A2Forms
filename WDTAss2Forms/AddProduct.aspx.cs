using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WDTAss2Forms.App_Code;

namespace WDTAss2Forms
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropDown();
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

        protected void Add_Click(object sender, EventArgs e)
        {   

            String message;
            String msgTitle;
            String categoryId = Categories.SelectedValue;
            String title = ProductTitle.Value;
            String shortDescription = ShortDesc.Value;
            String longDescription = LongDesc.Value;
            String price = Price.Value;

            
            if (DatabaseSystem.GetInstance().AddProduct(new Product(categoryId, title, shortDescription, longDescription, price)))
            {
                message = "Successfully added new product: " + title;
                msgTitle = "Product Added";
            }
            else
            {
                message = "Unable to add new product: " + title;
                msgTitle = "Unable To Add Product";
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

            Viewport_Add.Controls.Add(new LiteralControl(jquery));

        }
    }
}