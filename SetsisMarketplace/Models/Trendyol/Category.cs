using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SubCategory> subCategories { get; set; }
    }
}