using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class CategoryMatch
    {
        public int TYCategoryID { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public string name { get; set; }
        public string subname { get; set; }
        public string parentId { get; set; }
        public string id { get; set; }

    }
}