using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.BaseModel
{
    public class Content
    {
        [Key]
        public Guid TYID { get; set; }
        public ShipmentAddress shipmentAddress { get; set; }
        public string orderNumber { get; set; }
        public double grossAmount { get; set; }
        public double totalDiscount { get; set; }
        public string taxNumber { get; set; }        
        public InvoiceAddress invoiceAddress { get; set; }
        public string customerFirstName { get; set; }
        public string customerEmail { get; set; }
        public int customerId { get; set; }
        public string customerLastName { get; set; }
        public int id { get; set; }
        public long cargoTrackingNumber { get; set; }
        public string cargoProviderName { get; set; }
        public List<Line> lines { get; set; }
        public long orderDate { get; set; }
        public string tcIdentityNumber { get; set; }
        public string currencyCode { get; set; }
        //public List<PackageHistory> packageHistories { get; set; }
        public string shipmentPackageStatus { get; set; }
        public string deliveryType { get; set; }
        public long estimatedDeliveryStartDate { get; set; }
        public long estimatedDeliveryEndDate { get; set; }
        public double totalPrice { get; set; }
    }
}