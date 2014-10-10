using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using WDTAss2Forms.App_Code;

namespace WDTAss2Forms
{
    public partial class UploadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropDown();
        }

        protected void Upload_Image_Click(object sender, EventArgs e)
        {

            String jquery;
            String message = null;

            String imageUrl = Server.MapPath("~/" + "images/product_images/" + File_Upload_Image.FileName);
            String productId = Products.SelectedValue;

           
            if (File_Upload_Image.HasFile)
            {
                try
                {
                    File_Upload_Image.SaveAs(imageUrl);
                    
                    //save image info to database here
                    if(DatabaseSystem.GetInstance().UploadImage(productId, imageUrl))
                    message = "Successfully uploaded image!";
                }
                catch (Exception)
                {
                    message = "Unable to upload image!";
                }
            }
            else
            {
                message = "Unable to upload image!";
            }

            
            jquery = @"<script>
                $(function() {
                 

               bootbox.alert('" + message + @"', function() {});
                
                });
                </script>";

            Upload_Status.Controls.Add(new LiteralControl(jquery));
        }

        private void FillDropDown()
        {
            List<Product> products = DatabaseSystem.GetInstance().GetProducts();

            foreach (Product category in products)
            {
                if (Products.Items.FindByValue(category.categoryId) != null)
                    continue;

                ListItem item = new ListItem();
                item.Text = category.title;
                item.Value = category.productId;
                Products.Items.Add(item);
            }
        }
    }
}