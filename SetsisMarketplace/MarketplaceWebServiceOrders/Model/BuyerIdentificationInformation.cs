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
 * Buyer Identification Information
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class BuyerIdentificationInformation : AbstractMwsObject
    {

        private string _buyerCitizenId;
        private string _buyerLegalName;

        /// <summary>
        /// Gets and sets the BuyerCitizenId property.
        /// </summary>
        public string BuyerCitizenId
        {
            get { return this._buyerCitizenId; }
            set { this._buyerCitizenId = value; }
        }

        /// <summary>
        /// Sets the BuyerCitizenId property.
        /// </summary>
        /// <param name="buyerCitizenId">BuyerCitizenId property.</param>
        /// <returns>this instance.</returns>
        public BuyerIdentificationInformation WithBuyerCitizenId(string buyerCitizenId)
        {
            this._buyerCitizenId = buyerCitizenId;
            return this;
        }

        /// <summary>
        /// Checks if BuyerCitizenId property is set.
        /// </summary>
        /// <returns>true if BuyerCitizenId property is set.</returns>
        public bool IsSetBuyerCitizenId()
        {
            return this._buyerCitizenId != null;
        }

        /// <summary>
        /// Gets and sets the BuyerLegalName property.
        /// </summary>
        public string BuyerLegalName
        {
            get { return this._buyerLegalName; }
            set { this._buyerLegalName = value; }
        }

        /// <summary>
        /// Sets the BuyerLegalName property.
        /// </summary>
        /// <param name="buyerLegalName">BuyerLegalName property.</param>
        /// <returns>this instance.</returns>
        public BuyerIdentificationInformation WithBuyerLegalName(string buyerLegalName)
        {
            this._buyerLegalName = buyerLegalName;
            return this;
        }

        /// <summary>
        /// Checks if BuyerLegalName property is set.
        /// </summary>
        /// <returns>true if BuyerLegalName property is set.</returns>
        public bool IsSetBuyerLegalName()
        {
            return this._buyerLegalName != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _buyerCitizenId = reader.Read<string>("BuyerCitizenId");
            _buyerLegalName = reader.Read<string>("BuyerLegalName");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("BuyerCitizenId", _buyerCitizenId);
            writer.Write("BuyerLegalName", _buyerLegalName);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "BuyerIdentificationInformation", this);
        }


        public BuyerIdentificationInformation() : base()
        {
        }
    }
}
