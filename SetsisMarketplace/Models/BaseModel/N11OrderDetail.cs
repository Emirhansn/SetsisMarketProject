using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


namespace SetsisMarketplace.Models.BaseModel
{

	[XmlRoot(ElementName = "billingAddress")]
	public class BillingAddress
	{
		[XmlElement(ElementName = "address")]
		public string Address { get; set; }
		[XmlElement(ElementName = "city")]
		public string City { get; set; }
		[XmlElement(ElementName = "district")]
		public string District { get; set; }
		[XmlElement(ElementName = "fullName")]
		public string FullName { get; set; }
		[XmlElement(ElementName = "gsm")]
		public string Gsm { get; set; }
		[XmlElement(ElementName = "neighborhood")]
		public string Neighborhood { get; set; }
		[XmlElement(ElementName = "tcId")]
		public string TcId { get; set; }
	}

	[XmlRoot(ElementName = "billingTemplate")]
	public class BillingTemplate
	{
		[XmlElement(ElementName = "dueAmount")]
		public string DueAmount { get; set; }
		[XmlElement(ElementName = "installmentChargeWithVat")]
		public string InstallmentChargeWithVat { get; set; }
		[XmlElement(ElementName = "originalPrice")]
		public string OriginalPrice { get; set; }
		[XmlElement(ElementName = "sellerInvoiceAmount")]
		public string SellerInvoiceAmount { get; set; }
		[XmlElement(ElementName = "totalMallDiscountPrice")]
		public string TotalMallDiscountPrice { get; set; }
		[XmlElement(ElementName = "totalSellerDiscount")]
		public string TotalSellerDiscount { get; set; }
		[XmlElement(ElementName = "totalServiceItemOriginalPrice")]
		public string TotalServiceItemOriginalPrice { get; set; }
	}

	[XmlRoot(ElementName = "buyer")]
	public class Buyer
	{
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "fullName")]
		public string FullName { get; set; }
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "taxId")]
		public string TaxId { get; set; }
		[XmlElement(ElementName = "taxOffice")]
		public string TaxOffice { get; set; }
		[XmlElement(ElementName = "tcId")]
		public string TcId { get; set; }
	}

	[XmlRoot(ElementName = "shipmentCompany")]
	public class ShipmentCompany
	{
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "name")]
		public string Name { get; set; }
		[XmlElement(ElementName = "shortName")]
		public string ShortName { get; set; }
	}

	[XmlRoot(ElementName = "shipmentInfo")]
	public class ShipmentInfo
	{
		[XmlElement(ElementName = "campaignNumber")]
		public string CampaignNumber { get; set; }
		[XmlElement(ElementName = "campaignNumberStatus")]
		public string CampaignNumberStatus { get; set; }

		[XmlElement(ElementName = "shipmentCode")]
		public string ShipmentCode { get; set; }
		[XmlElement(ElementName = "shipmentCompany")]
		public ShipmentCompany ShipmentCompany { get; set; }
		[XmlElement(ElementName = "shipmentMethod")]
		public string ShipmentMethod { get; set; }
		[XmlElement(ElementName = "trackingNumber")]
		public string TrackingNumber { get; set; }
	}

	[XmlRoot(ElementName = "item")]
	public class ItemDetail
	{
		[XmlElement(ElementName = "approvedDate")]
		public string ApprovedDate { get; set; }
		[XmlElement(ElementName = "attributes")]
		public string Attributes { get; set; }
		[XmlElement(ElementName = "commission")]
		public string Commission { get; set; }
		[XmlElement(ElementName = "customTextOptionValues")]
		public string CustomTextOptionValues { get; set; }
		[XmlElement(ElementName = "deliveryFeeType")]
		public string DeliveryFeeType { get; set; }
		[XmlElement(ElementName = "dueAmount")]
		public string DueAmount { get; set; }
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "installmentChargeWithVAT")]
		public string InstallmentChargeWithVAT { get; set; }
		[XmlElement(ElementName = "mallDiscount")]
		public string MallDiscount { get; set; }
		[XmlElement(ElementName = "price")]
		public string Price { get; set; }
		[XmlElement(ElementName = "productId")]
		public string ProductId { get; set; }
		[XmlElement(ElementName = "productName")]
		public string ProductName { get; set; }
		[XmlElement(ElementName = "productSellerCode")]
		public string ProductSellerCode { get; set; }
		[XmlElement(ElementName = "quantity")]
		public string Quantity { get; set; }
		[XmlElement(ElementName = "sellerCouponDiscount")]
		public string SellerCouponDiscount { get; set; }
		[XmlElement(ElementName = "sellerDiscount")]
		public string SellerDiscount { get; set; }
		[XmlElement(ElementName = "sellerInvoiceAmount")]
		public string SellerInvoiceAmount { get; set; }
		[XmlElement(ElementName = "shipmenCompanyCampaignNumber")]
		public string ShipmenCompanyCampaignNumber { get; set; }
		[XmlElement(ElementName = "shipmentInfo")]
		public ShipmentInfo ShipmentInfo { get; set; }
		[XmlElement(ElementName = "shippingDate")]
		public string ShippingDate { get; set; }
		[XmlElement(ElementName = "sppApproved")]
		public string SppApproved { get; set; }
		[XmlElement(ElementName = "status")]
		public string Status { get; set; }
		[XmlElement(ElementName = "totalMallDiscountPrice")]
		public string TotalMallDiscountPrice { get; set; }
		[XmlElement(ElementName = "updatedDate")]
		public string UpdatedDate { get; set; }
		[XmlElement(ElementName = "version")]
		public string Version { get; set; }
	}

	[XmlRoot(ElementName = "itemList")]
	public class ItemList
	{
		[XmlElement(ElementName = "item")]
		public ItemDetail Item { get; set; }
	}

	[XmlRoot(ElementName = "shippingAddress")]
	public class ShippingAddress
	{
		[XmlElement(ElementName = "address")]
		public string Address { get; set; }
		[XmlElement(ElementName = "city")]
		public string City { get; set; }
		[XmlElement(ElementName = "district")]
		public string District { get; set; }
		[XmlElement(ElementName = "fullName")]
		public string FullName { get; set; }
		[XmlElement(ElementName = "gsm")]
		public string Gsm { get; set; }
		[XmlElement(ElementName = "neighborhood")]
		public string Neighborhood { get; set; }
		[XmlElement(ElementName = "tcId")]
		public string TcId { get; set; }
	}

	[XmlRoot(ElementName = "orderDetail")]
	public class OrderDetail
	{
		[XmlElement(ElementName = "citizenshipId")]
		public string CitizenshipId { get; set; }
		[XmlElement(ElementName = "createDate")]
		public string CreateDate { get; set; }
		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
		[XmlElement(ElementName = "orderNumber")]
		public string OrderNumber { get; set; }
		[XmlElement(ElementName = "paymentType")]
		public string PaymentType { get; set; }
		[XmlElement(ElementName = "status")]
		public string Status { get; set; }
		[XmlElement(ElementName = "billingAddress")]
		public BillingAddress BillingAddress { get; set; }
		[XmlElement(ElementName = "billingTemplate")]
		public BillingTemplate BillingTemplate { get; set; }
		[XmlElement(ElementName = "buyer")]
		public Buyer Buyer { get; set; }
		[XmlElement(ElementName = "invoiceType")]
		public string InvoiceType { get; set; }
		[XmlElement(ElementName = "itemList")]
		public ItemList ItemList { get; set; }
		[XmlElement(ElementName = "serviceItemList")]
		public string ServiceItemList { get; set; }
		[XmlElement(ElementName = "shippingAddress")]
		public ShippingAddress ShippingAddress { get; set; }

	}
}
