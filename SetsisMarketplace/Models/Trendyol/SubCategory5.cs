using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SubCategory5
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
        public List<object> subCategories { get; set; }
    }
}