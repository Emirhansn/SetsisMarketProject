using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class SubCategory4
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public List<SubCategory5> subCategories { get; set; }
    }
}