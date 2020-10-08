using SetsisMarketplace.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Trendyol
{
    public class Item
    {
        public string barcode { get; set; }
        public string title { get; set; }
        public string productMainId { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public int quantity { get; set; }
        public string stockCode { get; set; }
        public int dimensionalWeight { get; set; }
        public string description { get; set; }
        public string currencyType { get; set; }
        public double listPrice { get; set; }
        public double salePrice { get; set; }
        public int vatRate { get; set; }
        public int cargoCompanyId { get; set; }
        public string gender { get; set; }
        public List<Image> images { get; set; }
        public List<Attributes> attributes { get; set; }
        public Item()
        {
            images = new List<Image>();
            attributes = new List<Attributes>();

        }
    }
}