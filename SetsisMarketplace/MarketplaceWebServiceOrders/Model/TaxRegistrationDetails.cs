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
 * Tax Registration Details
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class TaxRegistrationDetails : AbstractMwsObject
    {

        private string _taxRegistrationType;
        private string _taxRegistrationId;
        private TaxRegistrationAuthority _taxRegistrationAuthority;

        /// <summary>
        /// Gets and sets the TaxRegistrationType property.
        /// </summary>
        public string TaxRegistrationType
        {
            get { return this._taxRegistrationType; }
            set { this._taxRegistrationType = value; }
        }

        /// <summary>
        /// Sets the TaxRegistrationType property.
        /// </summary>
        /// <param name="taxRegistrationType">TaxRegistrationType property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationDetails WithTaxRegistrationType(string taxRegistrationType)
        {
            this._taxRegistrationType = taxRegistrationType;
            return this;
        }

        /// <summary>
        /// Checks if TaxRegistrationType property is set.
        /// </summary>
        /// <returns>true if TaxRegistrationType property is set.</returns>
        public bool IsSetTaxRegistrationType()
        {
            return this._taxRegistrationType != null;
        }

        /// <summary>
        /// Gets and sets the TaxRegistrationId property.
        /// </summary>
        public string TaxRegistrationId
        {
            get { return this._taxRegistrationId; }
            set { this._taxRegistrationId = value; }
        }

        /// <summary>
        /// Sets the TaxRegistrationId property.
        /// </summary>
        /// <param name="taxRegistrationId">TaxRegistrationId property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationDetails WithTaxRegistrationId(string taxRegistrationId)
        {
            this._taxRegistrationId = taxRegistrationId;
            return this;
        }

        /// <summary>
        /// Checks if TaxRegistrationId property is set.
        /// </summary>
        /// <returns>true if TaxRegistrationId property is set.</returns>
        public bool IsSetTaxRegistrationId()
        {
            return this._taxRegistrationId != null;
        }

        /// <summary>
        /// Gets and sets the TaxRegistrationAuthority property.
        /// </summary>
        public TaxRegistrationAuthority TaxRegistrationAuthority
        {
            get { return this._taxRegistrationAuthority; }
            set { this._taxRegistrationAuthority = value; }
        }

        /// <summary>
        /// Sets the TaxRegistrationAuthority property.
        /// </summary>
        /// <param name="taxRegistrationAuthority">TaxRegistrationAuthority property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationDetails WithTaxRegistrationAuthority(TaxRegistrationAuthority taxRegistrationAuthority)
        {
            this._taxRegistrationAuthority = taxRegistrationAuthority;
            return this;
        }

        /// <summary>
        /// Checks if TaxRegistrationAuthority property is set.
        /// </summary>
        /// <returns>true if TaxRegistrationAuthority property is set.</returns>
        public bool IsSetTaxRegistrationAuthority()
        {
            return this._taxRegistrationAuthority != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _taxRegistrationType = reader.Read<string>("taxRegistrationType");
            _taxRegistrationId = reader.Read<string>("taxRegistrationId");
            _taxRegistrationAuthority = reader.Read<TaxRegistrationAuthority>("taxRegistrationAuthority");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("taxRegistrationType", _taxRegistrationType);
            writer.Write("taxRegistrationId", _taxRegistrationId);
            writer.Write("taxRegistrationAuthority", _taxRegistrationAuthority);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "TaxRegistrationDetails", this);
        }


        public TaxRegistrationDetails() : base()
        {
        }
    }
}
