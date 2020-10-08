/*******************************************************************************
 * Copyright 2009-2020 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Orders Request
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */


using System;
using System.Xml;
using System.Collections.Generic;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class ListOrdersRequest : AbstractMwsObject
    {

        private string _sellerId;
        private string _mwsAuthToken;
        private DateTime? _createdAfter;
        private DateTime? _createdBefore;
        private DateTime? _lastUpdatedAfter;
        private DateTime? _lastUpdatedBefore;
        private List<string> _orderStatus;
        private List<string> _marketplaceId;
        private List<string> _fulfillmentChannel;
        private List<string> _paymentMethod;
        private string _buyerEmail;
        private string _sellerOrderId;
        private decimal? _maxResultsPerPage;
        private List<string> _tfmShipmentStatus;
        private List<string> _easyShipShipmentStatus;
        private string _actualFulfillmentSupplySourceId;
        private bool? _isISPU;
        private ListOrdersOrderItem _item;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        public string SellerId
        {
            get { return this._sellerId; }
            set { this._sellerId = value; }
        }

        /// <summary>
        /// Sets the SellerId property.
        /// </summary>
        /// <param name="sellerId">SellerId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerId(string sellerId)
        {
            this._sellerId = sellerId;
            return this;
        }

        /// <summary>
        /// Checks if SellerId property is set.
        /// </summary>
        /// <returns>true if SellerId property is set.</returns>
        public bool IsSetSellerId()
        {
            return this._sellerId != null;
        }

        /// <summary>
        /// Gets and sets the MWSAuthToken property.
        /// </summary>
        public string MWSAuthToken
        {
            get { return this._mwsAuthToken; }
            set { this._mwsAuthToken = value; }
        }

        /// <summary>
        /// Sets the MWSAuthToken property.
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMWSAuthToken(string mwsAuthToken)
        {
            this._mwsAuthToken = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if MWSAuthToken property is set.
        /// </summary>
        /// <returns>true if MWSAuthToken property is set.</returns>
        public bool IsSetMWSAuthToken()
        {
            return this._mwsAuthToken != null;
        }

        /// <summary>
        /// Gets and sets the CreatedAfter property.
        /// </summary>
        public DateTime CreatedAfter
        {
            get { return this._createdAfter.GetValueOrDefault(); }
            set { this._createdAfter = value; }
        }

        /// <summary>
        /// Sets the CreatedAfter property.
        /// </summary>
        /// <param name="createdAfter">CreatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedAfter(DateTime createdAfter)
        {
            this._createdAfter = createdAfter;
            return this;
        }

        /// <summary>
        /// Checks if CreatedAfter property is set.
        /// </summary>
        /// <returns>true if CreatedAfter property is set.</returns>
        public bool IsSetCreatedAfter()
        {
            return this._createdAfter != null;
        }

        /// <summary>
        /// Gets and sets the CreatedBefore property.
        /// </summary>
        public DateTime CreatedBefore
        {
            get { return this._createdBefore.GetValueOrDefault(); }
            set { this._createdBefore = value; }
        }

        /// <summary>
        /// Sets the CreatedBefore property.
        /// </summary>
        /// <param name="createdBefore">CreatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedBefore(DateTime createdBefore)
        {
            this._createdBefore = createdBefore;
            return this;
        }

        /// <summary>
        /// Checks if CreatedBefore property is set.
        /// </summary>
        /// <returns>true if CreatedBefore property is set.</returns>
        public bool IsSetCreatedBefore()
        {
            return this._createdBefore != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedAfter property.
        /// </summary>
        public DateTime LastUpdatedAfter
        {
            get { return this._lastUpdatedAfter.GetValueOrDefault(); }
            set { this._lastUpdatedAfter = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedAfter property.
        /// </summary>
        /// <param name="lastUpdatedAfter">LastUpdatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedAfter(DateTime lastUpdatedAfter)
        {
            this._lastUpdatedAfter = lastUpdatedAfter;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedAfter property is set.
        /// </summary>
        /// <returns>true if LastUpdatedAfter property is set.</returns>
        public bool IsSetLastUpdatedAfter()
        {
            return this._lastUpdatedAfter != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedBefore property.
        /// </summary>
        public DateTime LastUpdatedBefore
        {
            get { return this._lastUpdatedBefore.GetValueOrDefault(); }
            set { this._lastUpdatedBefore = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedBefore property.
        /// </summary>
        /// <param name="lastUpdatedBefore">LastUpdatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedBefore(DateTime lastUpdatedBefore)
        {
            this._lastUpdatedBefore = lastUpdatedBefore;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedBefore property is set.
        /// </summary>
        /// <returns>true if LastUpdatedBefore property is set.</returns>
        public bool IsSetLastUpdatedBefore()
        {
            return this._lastUpdatedBefore != null;
        }

        /// <summary>
        /// Gets and sets the OrderStatus property.
        /// </summary>
        public List<string> OrderStatus
        {
            get
            {
                if(this._orderStatus == null)
                {
                    this._orderStatus = new List<string>();
                }
                return this._orderStatus;
            }
            set { this._orderStatus = value; }
        }

        /// <summary>
        /// Sets the OrderStatus property.
        /// </summary>
        /// <param name="orderStatus">OrderStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithOrderStatus(string[] orderStatus)
        {
            this._orderStatus.AddRange(orderStatus);
            return this;
        }

        /// <summary>
        /// Checks if OrderStatus property is set.
        /// </summary>
        /// <returns>true if OrderStatus property is set.</returns>
        public bool IsSetOrderStatus()
        {
            return this.OrderStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        public List<string> MarketplaceId
        {
            get
            {
                if(this._marketplaceId == null)
                {
                    this._marketplaceId = new List<string>();
                }
                return this._marketplaceId;
            }
            set { this._marketplaceId = value; }
        }

        /// <summary>
        /// Sets the MarketplaceId property.
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMarketplaceId(string[] marketplaceId)
        {
            this._marketplaceId.AddRange(marketplaceId);
            return this;
        }

        /// <summary>
        /// Checks if MarketplaceId property is set.
        /// </summary>
        /// <returns>true if MarketplaceId property is set.</returns>
        public bool IsSetMarketplaceId()
        {
            return this.MarketplaceId.Count > 0;
        }

        /// <summary>
        /// Gets and sets the FulfillmentChannel property.
        /// </summary>
        public List<string> FulfillmentChannel
        {
            get
            {
                if(this._fulfillmentChannel == null)
                {
                    this._fulfillmentChannel = new List<string>();
                }
                return this._fulfillmentChannel;
            }
            set { this._fulfillmentChannel = value; }
        }

        /// <summary>
        /// Sets the FulfillmentChannel property.
        /// </summary>
        /// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithFulfillmentChannel(string[] fulfillmentChannel)
        {
            this._fulfillmentChannel.AddRange(fulfillmentChannel);
            return this;
        }

        /// <summary>
        /// Checks if FulfillmentChannel property is set.
        /// </summary>
        /// <returns>true if FulfillmentChannel property is set.</returns>
        public bool IsSetFulfillmentChannel()
        {
            return this.FulfillmentChannel.Count > 0;
        }

        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        public List<string> PaymentMethod
        {
            get
            {
                if(this._paymentMethod == null)
                {
                    this._paymentMethod = new List<string>();
                }
                return this._paymentMethod;
            }
            set { this._paymentMethod = value; }
        }

        /// <summary>
        /// Sets the PaymentMethod property.
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithPaymentMethod(string[] paymentMethod)
        {
            this._paymentMethod.AddRange(paymentMethod);
            return this;
        }

        /// <summary>
        /// Checks if PaymentMethod property is set.
        /// </summary>
        /// <returns>true if PaymentMethod property is set.</returns>
        public bool IsSetPaymentMethod()
        {
            return this.PaymentMethod.Count > 0;
        }

        /// <summary>
        /// Gets and sets the BuyerEmail property.
        /// </summary>
        public string BuyerEmail
        {
            get { return this._buyerEmail; }
            set { this._buyerEmail = value; }
        }

        /// <summary>
        /// Sets the BuyerEmail property.
        /// </summary>
        /// <param name="buyerEmail">BuyerEmail property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithBuyerEmail(string buyerEmail)
        {
            this._buyerEmail = buyerEmail;
            return this;
        }

        /// <summary>
        /// Checks if BuyerEmail property is set.
        /// </summary>
        /// <returns>true if BuyerEmail property is set.</returns>
        public bool IsSetBuyerEmail()
        {
            return this._buyerEmail != null;
        }

        /// <summary>
        /// Gets and sets the SellerOrderId property.
        /// </summary>
        public string SellerOrderId
        {
            get { return this._sellerOrderId; }
            set { this._sellerOrderId = value; }
        }

        /// <summary>
        /// Sets the SellerOrderId property.
        /// </summary>
        /// <param name="sellerOrderId">SellerOrderId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerOrderId(string sellerOrderId)
        {
            this._sellerOrderId = sellerOrderId;
            return this;
        }

        /// <summary>
        /// Checks if SellerOrderId property is set.
        /// </summary>
        /// <returns>true if SellerOrderId property is set.</returns>
        public bool IsSetSellerOrderId()
        {
            return this._sellerOrderId != null;
        }

        /// <summary>
        /// Gets and sets the MaxResultsPerPage property.
        /// </summary>
        public decimal MaxResultsPerPage
        {
            get { return this._maxResultsPerPage.GetValueOrDefault(); }
            set { this._maxResultsPerPage = value; }
        }

        /// <summary>
        /// Sets the MaxResultsPerPage property.
        /// </summary>
        /// <param name="maxResultsPerPage">MaxResultsPerPage property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMaxResultsPerPage(decimal maxResultsPerPage)
        {
            this._maxResultsPerPage = maxResultsPerPage;
            return this;
        }

        /// <summary>
        /// Checks if MaxResultsPerPage property is set.
        /// </summary>
        /// <returns>true if MaxResultsPerPage property is set.</returns>
        public bool IsSetMaxResultsPerPage()
        {
            return this._maxResultsPerPage != null;
        }

        /// <summary>
        /// Gets and sets the TFMShipmentStatus property.
        /// </summary>
        public List<string> TFMShipmentStatus
        {
            get
            {
                if(this._tfmShipmentStatus == null)
                {
                    this._tfmShipmentStatus = new List<string>();
                }
                return this._tfmShipmentStatus;
            }
            set { this._tfmShipmentStatus = value; }
        }

        /// <summary>
        /// Sets the TFMShipmentStatus property.
        /// </summary>
        /// <param name="tfmShipmentStatus">TFMShipmentStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithTFMShipmentStatus(string[] tfmShipmentStatus)
        {
            this._tfmShipmentStatus.AddRange(tfmShipmentStatus);
            return this;
        }

        /// <summary>
        /// Checks if TFMShipmentStatus property is set.
        /// </summary>
        /// <returns>true if TFMShipmentStatus property is set.</returns>
        public bool IsSetTFMShipmentStatus()
        {
            return this.TFMShipmentStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the EasyShipShipmentStatus property.
        /// </summary>
        public List<string> EasyShipShipmentStatus
        {
            get
            {
                if(this._easyShipShipmentStatus == null)
                {
                    this._easyShipShipmentStatus = new List<string>();
                }
                return this._easyShipShipmentStatus;
            }
            set { this._easyShipShipmentStatus = value; }
        }

        /// <summary>
        /// Sets the EasyShipShipmentStatus property.
        /// </summary>
        /// <param name="easyShipShipmentStatus">EasyShipShipmentStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithEasyShipShipmentStatus(string[] easyShipShipmentStatus)
        {
            this._easyShipShipmentStatus.AddRange(easyShipShipmentStatus);
            return this;
        }

        /// <summary>
        /// Checks if EasyShipShipmentStatus property is set.
        /// </summary>
        /// <returns>true if EasyShipShipmentStatus property is set.</returns>
        public bool IsSetEasyShipShipmentStatus()
        {
            return this.EasyShipShipmentStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the ActualFulfillmentSupplySourceId property.
        /// </summary>
        public string ActualFulfillmentSupplySourceId
        {
            get { return this._actualFulfillmentSupplySourceId; }
            set { this._actualFulfillmentSupplySourceId = value; }
        }

        /// <summary>
        /// Sets the ActualFulfillmentSupplySourceId property.
        /// </summary>
        /// <param name="actualFulfillmentSupplySourceId">ActualFulfillmentSupplySourceId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithActualFulfillmentSupplySourceId(string actualFulfillmentSupplySourceId)
        {
            this._actualFulfillmentSupplySourceId = actualFulfillmentSupplySourceId;
            return this;
        }

        /// <summary>
        /// Checks if ActualFulfillmentSupplySourceId property is set.
        /// </summary>
        /// <returns>true if ActualFulfillmentSupplySourceId property is set.</returns>
        public bool IsSetActualFulfillmentSupplySourceId()
        {
            return this._actualFulfillmentSupplySourceId != null;
        }

        /// <summary>
        /// Gets and sets the IsISPU property.
        /// </summary>
        public bool IsISPU
        {
            get { return this._isISPU.GetValueOrDefault(); }
            set { this._isISPU = value; }
        }

        /// <summary>
        /// Sets the IsISPU property.
        /// </summary>
        /// <param name="isISPU">IsISPU property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithIsISPU(bool isISPU)
        {
            this._isISPU = isISPU;
            return this;
        }

        /// <summary>
        /// Checks if IsISPU property is set.
        /// </summary>
        /// <returns>true if IsISPU property is set.</returns>
        public bool IsSetIsISPU()
        {
            return this._isISPU != null;
        }

        /// <summary>
        /// Gets and sets the Item property.
        /// </summary>
        public ListOrdersOrderItem Item
        {
            get { return this._item; }
            set { this._item = value; }
        }

        /// <summary>
        /// Sets the Item property.
        /// </summary>
        /// <param name="item">Item property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithItem(ListOrdersOrderItem item)
        {
            this._item = item;
            return this;
        }

        /// <summary>
        /// Checks if Item property is set.
        /// </summary>
        /// <returns>true if Item property is set.</returns>
        public bool IsSetItem()
        {
            return this._item != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _sellerId = reader.Read<string>("SellerId");
            _mwsAuthToken = reader.Read<string>("MWSAuthToken");
            _createdAfter = reader.Read<DateTime?>("CreatedAfter");
            _createdBefore = reader.Read<DateTime?>("CreatedBefore");
            _lastUpdatedAfter = reader.Read<DateTime?>("LastUpdatedAfter");
            _lastUpdatedBefore = reader.Read<DateTime?>("LastUpdatedBefore");
            _orderStatus = reader.ReadList<string>("OrderStatus", "Status");
            _marketplaceId = reader.ReadList<string>("MarketplaceId", "Id");
            _fulfillmentChannel = reader.ReadList<string>("FulfillmentChannel", "Channel");
            _paymentMethod = reader.ReadList<string>("PaymentMethod", "Method");
            _buyerEmail = reader.Read<string>("BuyerEmail");
            _sellerOrderId = reader.Read<string>("SellerOrderId");
            _maxResultsPerPage = reader.Read<decimal?>("MaxResultsPerPage");
            _tfmShipmentStatus = reader.ReadList<string>("TFMShipmentStatus", "Status");
            _easyShipShipmentStatus = reader.ReadList<string>("EasyShipShipmentStatus", "Status");
            _actualFulfillmentSupplySourceId = reader.Read<string>("ActualFulfillmentSupplySourceId");
            _isISPU = reader.Read<bool?>("IsISPU");
            _item = reader.Read<ListOrdersOrderItem>("Item");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("SellerId", _sellerId);
            writer.Write("MWSAuthToken", _mwsAuthToken);
            writer.Write("CreatedAfter", _createdAfter);
            writer.Write("CreatedBefore", _createdBefore);
            writer.Write("LastUpdatedAfter", _lastUpdatedAfter);
            writer.Write("LastUpdatedBefore", _lastUpdatedBefore);
            writer.WriteList("OrderStatus", "Status", _orderStatus);
            writer.WriteList("MarketplaceId", "Id", _marketplaceId);
            writer.WriteList("FulfillmentChannel", "Channel", _fulfillmentChannel);
            writer.WriteList("PaymentMethod", "Method", _paymentMethod);
            writer.Write("BuyerEmail", _buyerEmail);
            writer.Write("SellerOrderId", _sellerOrderId);
            writer.Write("MaxResultsPerPage", _maxResultsPerPage);
            writer.WriteList("TFMShipmentStatus", "Status", _tfmShipmentStatus);
            writer.WriteList("EasyShipShipmentStatus", "Status", _easyShipShipmentStatus);
            writer.Write("ActualFulfillmentSupplySourceId", _actualFulfillmentSupplySourceId);
            writer.Write("IsISPU", _isISPU);
            writer.Write("Item", _item);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrdersRequest", this);
        }

    public ListOrdersRequest (string sellerId,List<string> marketplaceId) : base() {
        this._sellerId = sellerId;
        this._marketplaceId = marketplaceId;
    }

        public ListOrdersRequest() : base()
        {
        }
    }
}
