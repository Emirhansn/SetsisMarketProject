using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class SubCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public List<SubCategory2> subCategories { get; set; }
    }
}