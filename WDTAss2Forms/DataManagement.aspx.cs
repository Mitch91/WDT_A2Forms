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

using WdtA2ClassLibrary;

namespace WDTAss2Forms
{
    public partial class DataManagement : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropDown();
        }

        // add categories dropdown list from database

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


        protected void Submit_Click(object sender, EventArgs e)
        {

            Viewport_Data.Controls.Clear();           

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

                return;
            }


            //get all the rows with the selected category ID from SQL...


            //Jquery script, method chaining is used. Bootbox is a 3rd party bootstrap + jqeury library
            String jquery = @"<script>
                $(function() {

                    var table = $('#table_id').DataTable();

                    $('#table_id').on('click', 'i.delete', function(e) {
                        var id = $(this).closest('tr').data('product_id');
                        window.location.href = 'DeleteProduct.aspx/?productID=' + id;             
           
                    }).on('click', 'i.edit', function(e) {
                        var id = $(this).closest('tr').data('product_id');
                        window.location.href = 'EditProduct.aspx/?productID=' + id; 
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

            List<Product> products = DatabaseSystem.GetInstance().GetProductsForCategory(selectedCatID);
            foreach(Product product in products)
            {
                String imgUrl = product.imgUrl == null ? "No Image Found" : product.imgUrl;

                tableBody = tableBody + @"
                  <tr id='" + product.productId + "' data-product_id='" + product.productId + @"'>
                <td width='100px'><img src='" + product.imgUrl + @"' style='width: 100px; height: 100px' /></td>
                     <td>" + product.productId + @"</td>
                     <td>" + product.categoryId + @"</td>
                     <td>" + product.title + @"</td>
                     <td>" + product.shortDescription + @"</td>
                     <td>" + product.longDescription + @"</td>
                     <td>" + imgUrl + @"</td>
                     <td>" + product.price + @"</td>
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
            String jquery;
            Viewport_Data.Controls.Clear();


            if (Categories.SelectedIndex > -1)
            {
                String selectedCatID = Categories.SelectedItem.Value;

                if (DatabaseSystem.GetInstance().DeleteCategory(selectedCatID))
                {
                    jquery = @"<script>
                    $(function() {
               
                            bootbox.alert('Successfully removed category " + Categories.SelectedItem.Text + " !', function() {});});</script>";

                    Categories.Items.Clear();
                    FillDropDown();
                }
                else
                {
                    jquery = @"<script>
                    $(function() {
               
                            bootbox.alert('Unable to remove category " + Categories.SelectedItem.Text + " !', function() {});});</script>";
                }
            }
            else
            {
                jquery = @"<script>
                $(function() {
               
                        bootbox.alert('Error, selected index is < 0 !', function() {});});</script>";
            }

            Viewport_Data.Controls.Add(new LiteralControl(jquery));
        }
    }
}