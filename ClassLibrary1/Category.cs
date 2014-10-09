using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WdtA2ClassLibrary
{
    public class Category
    {
        public String categoryId { get; private set; }

        public String title { get; private set; }

        public String imgUrl { get; private set; }

        public Category(String categoryId, String title, String imgUrl)
        {
            this.categoryId = categoryId;
            this.title = title;
            this.imgUrl = imgUrl;
        }

        public override String ToString()
        {
            return String.Format("Title: {0}, CategoryId: {1}, ImgUrl: {2}", categoryId, title, imgUrl);
        }
    }
}
