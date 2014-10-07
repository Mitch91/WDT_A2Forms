using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDTAss2Forms
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productID = Request.QueryString["productID"];

            //database code here. find the id and remove from db.


            //confirm success

            if (productID != null)
            {
               status.Text = "Successfully removed product ID: " + productID; 

            }
            else {


                status.Text = "Unable to remove productID!"; 

 
            
            
            }

        }
    }
}