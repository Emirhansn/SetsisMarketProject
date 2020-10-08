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
 * Tax Registration Authority
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class TaxRegistrationAuthority : AbstractMwsObject
    {

        private string _country;
        private string _state;
        private string _district;
        private string _province;
        private string _city;
        private string _warehouseId;

        /// <summary>
        /// Gets and sets the Country property.
        /// </summary>
        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }

        /// <summary>
        /// Sets the Country property.
        /// </summary>
        /// <param name="country">Country property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithCountry(string country)
        {
            this._country = country;
            return this;
        }

        /// <summary>
        /// Checks if Country property is set.
        /// </summary>
        /// <returns>true if Country property is set.</returns>
        public bool IsSetCountry()
        {
            return this._country != null;
        }

        /// <summary>
        /// Gets and sets the State property.
        /// </summary>
        public string State
        {
            get { return this._state; }
            set { this._state = value; }
        }

        /// <summary>
        /// Sets the State property.
        /// </summary>
        /// <param name="state">State property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithState(string state)
        {
            this._state = state;
            return this;
        }

        /// <summary>
        /// Checks if State property is set.
        /// </summary>
        /// <returns>true if State property is set.</returns>
        public bool IsSetState()
        {
            return this._state != null;
        }

        /// <summary>
        /// Gets and sets the District property.
        /// </summary>
        public string District
        {
            get { return this._district; }
            set { this._district = value; }
        }

        /// <summary>
        /// Sets the District property.
        /// </summary>
        /// <param name="district">District property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithDistrict(string district)
        {
            this._district = district;
            return this;
        }

        /// <summary>
        /// Checks if District property is set.
        /// </summary>
        /// <returns>true if District property is set.</returns>
        public bool IsSetDistrict()
        {
            return this._district != null;
        }

        /// <summary>
        /// Gets and sets the Province property.
        /// </summary>
        public string Province
        {
            get { return this._province; }
            set { this._province = value; }
        }

        /// <summary>
        /// Sets the Province property.
        /// </summary>
        /// <param name="province">Province property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithProvince(string province)
        {
            this._province = province;
            return this;
        }

        /// <summary>
        /// Checks if Province property is set.
        /// </summary>
        /// <returns>true if Province property is set.</returns>
        public bool IsSetProvince()
        {
            return this._province != null;
        }

        /// <summary>
        /// Gets and sets the City property.
        /// </summary>
        public string City
        {
            get { return this._city; }
            set { this._city = value; }
        }

        /// <summary>
        /// Sets the City property.
        /// </summary>
        /// <param name="city">City property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithCity(string city)
        {
            this._city = city;
            return this;
        }

        /// <summary>
        /// Checks if City property is set.
        /// </summary>
        /// <returns>true if City property is set.</returns>
        public bool IsSetCity()
        {
            return this._city != null;
        }

        /// <summary>
        /// Gets and sets the WarehouseId property.
        /// </summary>
        public string WarehouseId
        {
            get { return this._warehouseId; }
            set { this._warehouseId = value; }
        }

        /// <summary>
        /// Sets the WarehouseId property.
        /// </summary>
        /// <param name="warehouseId">WarehouseId property.</param>
        /// <returns>this instance.</returns>
        public TaxRegistrationAuthority WithWarehouseId(string warehouseId)
        {
            this._warehouseId = warehouseId;
            return this;
        }

        /// <summary>
        /// Checks if WarehouseId property is set.
        /// </summary>
        /// <returns>true if WarehouseId property is set.</returns>
        public bool IsSetWarehouseId()
        {
            return this._warehouseId != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _country = reader.Read<string>("country");
            _state = reader.Read<string>("state");
            _district = reader.Read<string>("district");
            _province = reader.Read<string>("province");
            _city = reader.Read<string>("city");
            _warehouseId = reader.Read<string>("warehouseId");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("country", _country);
            writer.Write("state", _state);
            writer.Write("district", _district);
            writer.Write("province", _province);
            writer.Write("city", _city);
            writer.Write("warehouseId", _warehouseId);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "TaxRegistrationAuthority", this);
        }


        public TaxRegistrationAuthority() : base()
        {
        }
    }
}
