using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class ADDRoot
    {
        public List<Item> items { get; set; }



        public ADDRoot()
        {
            items = new List<Item>();
        }
    }
}