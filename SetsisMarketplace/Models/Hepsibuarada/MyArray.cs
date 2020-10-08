using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetsisMarketplace.Models.Hepsibuarada
{
    public class MyArray
    {
        public string id { get; set; }
        public string status { get; set; }
        public string customerId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime dueDate { get; set; }
        public string barcode { get; set; }
        public string packageNumber { get; set; }
        public string cargoCompany { get; set; }
        public string shippingAddressDetail { get; set; }
        public string recipientName { get; set; }
        public string shippingCountryCode { get; set; }
        public string shippingDistrict { get; set; }
        public string shippingTown { get; set; }
        public string shippingCity { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string companyName { get; set; }
        public string billingAddress { get; set; }
        public string billingCity { get; set; }
        public string billingTown { get; set; }
        public string billingDistrict { get; set; }
        public object taxOffice { get; set; }
        public string taxNumber { get; set; }
        public string identityNo { get; set; }
        public object shippingTotalPrice { get; set; }
        public object customsTotalPrice { get; set; }
        public TotalPrice totalPrice { get; set; }
        public List<HBItem> items { get; set; }
    }
}