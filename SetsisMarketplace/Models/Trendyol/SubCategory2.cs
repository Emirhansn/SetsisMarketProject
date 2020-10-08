using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class SubCategory2
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public List<SubCategory3> subCategories { get; set; }
    }
}