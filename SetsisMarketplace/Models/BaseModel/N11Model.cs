using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SetsisMarketplace.Models.BaseModel
{
	[XmlRoot(ElementName = "order")]
	public class Order
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
	}

	[XmlRoot(ElementName = "orderList")]
	public class OrderList
	{
		[XmlElement(ElementName = "order")]
		public List<Order> Order { get; set; }
	}
}
