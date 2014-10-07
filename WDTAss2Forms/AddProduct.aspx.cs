using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WDTAss2Forms
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {   

            string title = String.Format("{0}", Request.Form["title"]);


           //add to database here.
            

            //confirm success with bootbox or something
            String jquery = @"<script>
                $(function() {
               
                        bootbox.alert('Successfully added new product: "+ title + @"!', function() {});
          
                });
                </script>";


            Viewport_Add.Controls.Add(new LiteralControl(jquery));

        }


       
   


    }
}