using System;
using System.ComponentModel.DataAnnotations;


namespace SetsisMarketplace.Models.BaseModel
{
    public class MarketplaceModel
    {
        [Key]
        public Guid MarketplaceID { get; set; }
        public string customerFirstName { get; set; }
        public string customerLastName { get; set; }
        public string orderNumber { get; set; }
        public string cargoProviderName { get; set; }
        public string cargoTrackingNumber { get; set; }
        public string cargoTrackingLink { get; set; }
        public string shipmentPackageStatus { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string postalCode { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public string sku { get; set; }
        public string productSize { get; set; }
        public string quantity { get; set; }
        public string amount { get; set; }
        public string totalPrice { get; set; }
        public string barcode { get; set; }
        public string productColor { get; set; }
        public string customerEmail { get; set; }
        public string orderDate { get; set; }
        public string imageUrl { get; set; }
        public string variant { get; set; }
        public string store { get; set; }
        public string price { get; set; }
        public string phone { get; set; }
        public string identityNumber { get; set; }
        public string taxNumber { get; set; }
        public string vatBaseAmount { get; set; }
        public string discount { get; set; }
    }

}
