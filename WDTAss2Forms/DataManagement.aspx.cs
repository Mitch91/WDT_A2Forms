using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;


namespace WDTAss2Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropDown();
        }

        // add categories dropdown list from database

        private void FillDropDown()
        {


            //Categories.Items.Clear();

            //database code here

            const int rowsC = 3;
            const int columnsC = 2;

            //test data replace with database data
            string[,] testCat = new string[rowsC, columnsC] { 
            {"4", "Enchanted items"},
            {"2", "Potions"},
            {"3", "Books"}
            };

            for (int i = 0; i < testCat.GetLength(0); i++)
            {
                if (Categories.Items.FindByValue(testCat[i, 0]) == null)
                {
                    ListItem category = new ListItem();
                    category.Text = testCat[i, 1];
                    category.Value = testCat[i, 0];
                    Categories.Items.Add(category);
                }
                
            }



        }


        protected void Submit_Click(object sender, EventArgs e)
        {

            Viewport_Data.Controls.Clear();

            /*string connStr = "Data Source=potoroo.cs.rmit.edu.au;" +
            "Initial Catalog=s3369678_wdt;" +
            "User id=s3369678_wdt;" +
            "Password=;";

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("testP", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@test1","TawsdasdasdY");

            cmd.Parameters.AddWithValue("@test2", "WEEE342342WEEE");

            cmd.Parameters.AddWithValue("@test3", "WOOOO324O");
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close(); 
            */


           //get category id

            string selectedCatID;


            if (Categories.SelectedIndex > -1)
            {


                selectedCatID = Categories.SelectedItem.Value;
            }
            else
            {
                String  error = @"<script>
                $(function() {
               
                        bootbox.alert('Error, selected index is < 0 !', function() {});});</script>";


                Viewport_Data.Controls.Add(new LiteralControl(error));

               // Response.End();

            }


            //get all the rows with the selected category ID from SQL...


            //convert the SQL rows into 2d array(or c# equivalent of associative array) where [numRows, numColumns for each row - 2. - 1 for the last column(which are font awesome icons) 
            //and - 1 for the imageURL, which is used twice. So instead of 9 columns we use 7 columns for the loop below 

            const int rows = 3;
            const int columns = 7;

            //test data, replace with real data from SQL server. 
            string[,] testData = new string[rows, columns] { 
            {"9", "5", "Sheep stick", "This thing turns you into a sheep.", "This thing turns you into a sheep for 30 seconds.", "images/whizbang.png", "3000.00"},
            {"2", "4", "Potato helm", "Potato helm put on head.", "This will protext u from cabbage bombs.", "images/product_images/006.jpg", "23.00"},
            {"1", "8", "Cabbage bomb", "Use this to throw at things.", "Throw this hard so it flies high.", "images/whabang.png", "733.00"}
            };



            //Jquery script, method chaining is used. Bootbox is a 3rd party bootstrap + jqeury library
            String jquery = @"<script>
                $(function() {

                    var table = $('#table_id').DataTable();

                    $('#table_id').on('click', 'i.delete', function(e) {
                        var id = $(this).closest('tr').data('product_id');

                 window.location.href = 'DeleteProduct.aspx/?productID=' + id;             
           
                    }).on('click', 'i.edit', function(e) {
                        bootbox.alert('edit', function() {});
                    })
                });
                </script>";

            //construct the table in parts and combine them


            //construct table head. @ is used to allow concatenation of string with newline
            String tableHead = @"<table id='table_id' class='table table-condensed table-bordered table-striped table-hover'>
                <thead>
                    <tr>
                        <th>Image</th>
                        <th>Product ID</th>
                        <th>Category ID</th>
                        <th>Title</th>
                        <th>Short Description</th>
                        <th>Long Description</th>
                        <th>ImageURL</th>
                        <th>Price</th>
                        <th width='50'>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>";


            //construct table body(rows)
            String tableBody = "";

            //i is row number. constructing the rows using loop
            for (int i = 0; i < testData.GetLength(0); i++)
            {


                string productID = testData[i, 0];
                string catID = testData[i, 1];
                string title = testData[i, 2];
                string shortDesc = testData[i, 3];
                string longDesc = testData[i, 4];
                string imageURL = testData[i, 5];
                string price = testData[i, 6];

                tableBody = tableBody + @"
                  <tr id='" + productID + "' data-product_id='" + productID + @"'>
                <td width='100px'><img src='" + imageURL + @"' style='width: 100px; height: 100px' /></td>
                     <td>" + productID + @"</td>
                     <td>" + catID + @"</td>
                     <td>" + title + @"</td>
                     <td>" + shortDesc + @"</td>
                     <td>" + longDesc + @"</td>
                     <td>" + imageURL + @"</td>
                     <td>" + price + @"</td>
                     <td><span style='cursor:pointer'><i class='fa fa-remove delete'></i></br><i class='fa fa-pencil-square-o edit'></i></span></td>
                  </tr>";
                        }



            //construct table foot
            String tableFoot = "</tbody></table>";


            //combine all table parts
            String table = tableHead + tableBody + tableFoot;

            //Combine Jquery and the table to render on the browser
            String html = jquery + table;

            //add to the dynamic panel
            Viewport_Data.Controls.Add(new LiteralControl(html));


        }



        protected void Add_Product_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void Delete_Category_Click(object sender, EventArgs e)
        {
            Viewport_Data.Controls.Clear();


            if (Categories.SelectedIndex > -1)
            {
           

                //database code here

                String jquery = @"<script>
                $(function() {
               
                        bootbox.alert('Successfully removed category ID : " + Categories.SelectedItem.Value + " !', function() {});});</script>";


                Viewport_Data.Controls.Add(new LiteralControl(jquery));
            }
            else {


                String jquery = @"<script>
                $(function() {
               
                        bootbox.alert('Error, selected index is < 0 !', function() {});});</script>";


                Viewport_Data.Controls.Add(new LiteralControl(jquery));
            
            }
            

        }


        //used to set the category selected from the listitem
        protected void Generate_Click(object sender, EventArgs e)
        {
            //FillDropDown();
        }

 
    }
}