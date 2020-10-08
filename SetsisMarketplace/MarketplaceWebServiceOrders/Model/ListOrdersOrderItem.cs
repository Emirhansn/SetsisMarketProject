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
 * List Orders Order Item
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class ListOrdersOrderItem : AbstractMwsObject
    {

        private string _storeChainStoreId;

        /// <summary>
        /// Gets and sets the StoreChainStoreId property.
        /// </summary>
        public string StoreChainStoreId
        {
            get { return this._storeChainStoreId; }
            set { this._storeChainStoreId = value; }
        }

        /// <summary>
        /// Sets the StoreChainStoreId property.
        /// </summary>
        /// <param name="storeChainStoreId">StoreChainStoreId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersOrderItem WithStoreChainStoreId(string storeChainStoreId)
        {
            this._storeChainStoreId = storeChainStoreId;
            return this;
        }

        /// <summary>
        /// Checks if StoreChainStoreId property is set.
        /// </summary>
        /// <returns>true if StoreChainStoreId property is set.</returns>
        public bool IsSetStoreChainStoreId()
        {
            return this._storeChainStoreId != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _storeChainStoreId = reader.Read<string>("StoreChainStoreId");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("StoreChainStoreId", _storeChainStoreId);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrdersOrderItem", this);
        }


        public ListOrdersOrderItem() : base()
        {
        }
    }
}
