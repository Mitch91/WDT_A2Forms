using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WDTAss2Forms
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Image_Click(object sender, EventArgs e)
        {

            string imageURL = Server.MapPath("~/" + "images/product_images/" + File_Upload_Image.FileName);



            String success = @"<script>
                $(function() {
                 

               bootbox.alert('Successfully uploaded image!', function() {});
                
                });
                </script>";

            String error = @"<script>
                $(function() {
                  

                bootbox.alert('Error uploading file!', function() {});
                
                });
                </script>";

            

            if (File_Upload_Image.HasFile)
            {
                try
                {

                    File_Upload_Image.SaveAs(imageURL);

                    //save image info to database here

                    Upload_Status.Controls.Add(new LiteralControl(success));


                }
                catch (Exception ex)
                {
                   
                    Upload_Status.Controls.Add(new LiteralControl(error));
                }
            }
            else
            {

                Upload_Status.Controls.Add(new LiteralControl(error));

            }



        }
    }

}