using SetsisMarketplace.Models.Trendyol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetsisMarketplace.Models.Trendyol
{
    public class TYMultiClass
    {
        public IEnumerable<CategoryRoot> Categories { get; set; }
        public IEnumerable<HierarchyModel> Hierarchies { get; set; }

     
    }
}