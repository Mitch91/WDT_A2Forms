using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WdtA2ClassLibrary
{
    public class Product
    {
        public String productId { get; private set; }

        public String categoryId { get; private set; }

        public String title { get; private set; }

        public String shortDescription { get; private set; }

        public String longDescription { get; private set; }

        public String imgUrl { get; set; }

        public String price { get; private set; }

        // If the user has added a product, it hasn't been added to the database yet and doesn't have a product Id, 
        // call this constructor
        public Product(String categoryId, String title, String shortDescription, String longDescription, String price)
        {
            this.categoryId = categoryId;
            this.title = title;
            this.shortDescription = shortDescription;
            this.longDescription = longDescription;
            this.price = price;
        }

        //Product is being read from the database and has a product Id, use this constructor.
        public Product(String productId, String categoryId, String title, String shortDescription, String longDescription, String price) :
            this(categoryId, title, shortDescription, longDescription, price)
        {
            this.productId = productId;
        }

        public Product(String productId, String categoryId, String title, String shortDescription, String longDescription, String imgUrl, String price) :
            this(productId, categoryId, title, shortDescription, longDescription, price)
        {
            this.imgUrl = imgUrl;
        }

        public override String ToString()
        {
            return String.Format("ProductId: {0}, CategoryId: {1}, Title: {2}, Short: {3}, Long: {4} ImgUrl: {5}, Price: {6}", productId, categoryId, title, shortDescription, longDescription, imgUrl, price);
        }
    }
}
