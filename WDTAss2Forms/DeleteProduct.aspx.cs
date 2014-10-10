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
    public partial class DeleteProduct : System.Web.UI.Page
    {
        private Boolean loaded = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            String productId = Request.QueryString["productID"];

            if (!loaded)
            {
                loaded = true;
                //confirm success
                if (DatabaseSystem.GetInstance().DeleteProduct(productId))
                {
                    status.Text = "Product Successfully deleted!";
                }
                else
                {
                    status.Text = "Unable to remove product!";

                }
            }
        }

        protected void Reset(object sender, EventArgs e)
        {
            loaded = false;
        }
    }
}