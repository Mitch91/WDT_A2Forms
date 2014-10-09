using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WdtA2ClassLibrary
{
    public class DatabaseSystem
    {
        /*
        private const String connStr = "Data Source=csitprddb03.rmit.internal,1433;" +
            "Integrated Security=True;" +
            "Database=WDT_A2;";
        */

        private const String connStr = "Data Source=localhost;" +
            "Integrated Security=True;" +
            "Database=WDT_A2;";

        private static DatabaseSystem database = null;

        private SqlDataAdapter dataAdapter { get; set; }

        private SqlConnection dbConnection { get; set; }

        private DataTable dataTable { get; set; }

        private SqlCommand command { get; set; }

        private SqlDataReader dataReader { get; set; }

        public DatabaseSystem()
        {
            dbConnection = new SqlConnection(connStr);
            dataAdapter = new SqlDataAdapter();

            // Don't want to define query string yet. They really should overload SqlCommand to just take an SQLConnection
            command = new SqlCommand("", dbConnection);
            command.CommandType = CommandType.StoredProcedure;
            dataTable = new DataTable();
        }

        public static DatabaseSystem GetInstance()
        {
            if (database == null)
                database = new DatabaseSystem();

            return database;
        }

        public Boolean AddProduct(Product p)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "AddProduct";
                command.Parameters.AddWithValue("@cID", p.categoryId);
                command.Parameters.AddWithValue("@title", p.title);
                command.Parameters.AddWithValue("@short", p.shortDescription);
                command.Parameters.AddWithValue("@long", p.longDescription);
                command.Parameters.AddWithValue("@price", p.price);

                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Delete the product with ID productId
        public Boolean DeleteProduct(String productId)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                if (!String.Equals(productId, null))
                {

                    command.CommandText = "DeleteProduct";
                    command.Parameters.AddWithValue("@pID", productId);

                    dbConnection.Open();
                    command.ExecuteNonQuery();
                    dbConnection.Close();

                    return true;
                }
                else 
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Delete the category with ID categoryId
        public Boolean DeleteCategory(String categoryId)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "DeleteCategory";
                command.Parameters.AddWithValue("@cID", categoryId);

                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Update the product with ID p.productId to be equal to p
        public Boolean UpdateProduct(Product p)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "UpdateProduct";
                command.Parameters.AddWithValue("@pID", p.productId);
                command.Parameters.AddWithValue("@cID", p.categoryId);
                command.Parameters.AddWithValue("@title", p.title);
                command.Parameters.AddWithValue("@short", p.shortDescription);
                command.Parameters.AddWithValue("@long", p.longDescription);
                command.Parameters.AddWithValue("@price", p.price);

                dbConnection.Open();
                command.ExecuteNonQuery();
                dbConnection.Close();
                Debug.WriteLine("\n\nSuccess!");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();

            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "GetProducts";
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                productList.Add(new Product(row["ProductID"].ToString(),
                        row["CategoryID"].ToString(),
                        row["Title"].ToString(),
                        row["ShortDescription"].ToString(),
                        row["LongDescription"].ToString(),
                        row["ImageUrl"].ToString(),
                        row["Price"].ToString()));
            }

            return productList;
        }

        // Gets all the products for the given category ID
        public List<Product> GetProductsForCategory(String categoryId)
        {
            List<Product> productList = new List<Product>();

            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "GetProductsForCategory";
                command.Parameters.Add(new SqlParameter("@cID", categoryId));
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                return null;
            }

            foreach (DataRow row in dataTable.Rows)
            {
                productList.Add(new Product(row["ProductID"].ToString(),
                        row["CategoryID"].ToString(),
                        row["Title"].ToString(),
                        row["ShortDescription"].ToString(),
                        row["LongDescription"].ToString(),
                        row["ImageUrl"].ToString(),
                        row["Price"].ToString()));
            }

            return productList;
        }

        // Returns a list of categories in the DB, used to populate dropdown
        public List<Category> GetCategories()
        {

            List<Category> categoryList = new List<Category>();

            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                command.CommandText = "GetCategories";
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    categoryList.Add(new Category(row["CategoryID"].ToString(),
                            row["Title"].ToString(),
                            row["ImageUrl"].ToString()));
                }

                return categoryList;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Product GetProductForId(String productId)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            try
            {
                if (!String.Equals(productId, null))
                {
                    command.CommandText = "GetProductForId";
                    command.Parameters.AddWithValue("@pID", productId);
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(dataTable);

                    DataRow result = dataTable.Rows[0];

                    return new Product(result["ProductID"].ToString(),
                                    result["CategoryID"].ToString(),
                                    result["Title"].ToString(),
                                    result["ShortDescription"].ToString(),
                                    result["LongDescription"].ToString(),
                                    result["Price"].ToString());
                }
                else
                {
                    
                    return null;
                }
                    

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean UploadImage(String productId, String imgUrl)
        {
            dataTable.Clear();
            command.Parameters.Clear();

            command.CommandText = "UploadImage";
            command.Parameters.AddWithValue("@pID", productId);
            command.Parameters.AddWithValue("@imgUrl", imgUrl);

            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();

            return true;
        }
    }
}

