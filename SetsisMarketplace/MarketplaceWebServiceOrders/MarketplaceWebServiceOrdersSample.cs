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
 * Marketplace Web Service Orders
 * API Version: 2013-09-01
 * Library Version: 2020-09-29
 * Generated: Tue Sep 29 16:48:10 UTC 2020
 */

using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;

namespace MarketplaceWebServiceOrders {

    /// <summary>
    /// Runnable sample code to demonstrate usage of the C# client.
    ///
    /// To use, import the client source as a console application,
    /// and mark this class as the startup object. Then, replace
    /// parameters below with sensible values and run.
    /// </summary>
    public class MarketplaceWebServiceOrdersSample {

        public static void Main(string[] args)
        {
            // TODO: Set the below configuration variables before attempting to run

            // Developer AWS access key
            string accessKey = "AKIAJO3IC7VKEKZOPUZQ";

            // Developer AWS secret key
            string secretKey = "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";

            // The client application name
            string appName = "CSharpSampleCode";

            // The client application version
            string appVersion = "1.0";

            // The endpoint for region service and version (see developer guide)
            // ex: https://mws.amazonservices.com
            string serviceURL = "https://mws-eu.amazonservices.com";

            // Create a configuration object
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrders client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceOrdersSample sample = new MarketplaceWebServiceOrdersSample(client);

            // Uncomment the operation you'd like to test here
            // TODO: Modify the request created in the Invoke method to be valid

            try 
            {
                IMWSResponse response = null;
                response = sample.InvokeGetOrder();
                // response = sample.InvokeGetServiceStatus();
                // response = sample.InvokeListOrderItems();
                // response = sample.InvokeListOrderItemsByNextToken();
                // response = sample.InvokeListOrders();
                // response = sample.InvokeListOrdersByNextToken();
                Console.WriteLine("Response:");
                ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
                // We recommend logging the request id and timestamp of every call.
                Console.WriteLine("RequestId: " + rhmd.RequestId);
                Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                string responseXml = response.ToXML();
                Console.WriteLine(responseXml);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("Service Exception:");
                if(rhmd != null)
                {
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                }
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StatusCode: " + ex.StatusCode);
                Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                Console.WriteLine("ErrorType: " + ex.ErrorType);
                throw ex;
            }
        }

        private readonly MarketplaceWebServiceOrders client;

        public MarketplaceWebServiceOrdersSample(MarketplaceWebServiceOrders client)
        {
            this.client = client;
        }

        public GetOrderResponse InvokeGetOrder()
        {
            // Create a request.
            GetOrderRequest request = new GetOrderRequest();
            string sellerId = "A2V07W7ITIWX5B";
            request.SellerId = sellerId;
            string mwsAuthToken = "amzn.mws.bab1c5e7-9695-b099-9770-92f7275d0a27";
            request.MWSAuthToken = mwsAuthToken;
            List<string> amazonOrderId = new List<string>();
            request.AmazonOrderId = amazonOrderId;
            return this.client.GetOrder(request);
        }

        public GetServiceStatusResponse InvokeGetServiceStatus()
        {
            // Create a request.
            GetServiceStatusRequest request = new GetServiceStatusRequest();
            string sellerId = "deneme";
            request.SellerId = sellerId;
            string mwsAuthToken = "deneme";
            request.MWSAuthToken = mwsAuthToken;
            return this.client.GetServiceStatus(request);
        }

        public ListOrderItemsResponse InvokeListOrderItems()
        {
            // Create a request.
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            string sellerId = "deneme";
            request.SellerId = sellerId;
            string mwsAuthToken = "deneme";
            request.MWSAuthToken = mwsAuthToken;
            string amazonOrderId = "deneme";
            request.AmazonOrderId = amazonOrderId;
            return this.client.ListOrderItems(request);
        }

        public ListOrderItemsByNextTokenResponse InvokeListOrderItemsByNextToken()
        {
            // Create a request.
            ListOrderItemsByNextTokenRequest request = new ListOrderItemsByNextTokenRequest();
            string sellerId = "deneme";
            request.SellerId = sellerId;
            string mwsAuthToken = "deneme";
            request.MWSAuthToken = mwsAuthToken;
            string nextToken = "deneme";
            request.NextToken = nextToken;
            return this.client.ListOrderItemsByNextToken(request);
        }

        public ListOrdersResponse InvokeListOrders()
        {
            // Create a request.
            ListOrdersRequest request = new ListOrdersRequest();
            string sellerId = "A2V07W7ITIWX5B";
            request.SellerId = sellerId;
            string mwsAuthToken = "amzn.mws.bab1c5e7-9695-b099-9770-92f7275d0a27";
            request.MWSAuthToken = mwsAuthToken;
            DateTime createdAfter = new DateTime();
            request.CreatedAfter = createdAfter;
            DateTime createdBefore = new DateTime();
            request.CreatedBefore = createdBefore;
            DateTime lastUpdatedAfter = new DateTime();
            request.LastUpdatedAfter = lastUpdatedAfter;
            DateTime lastUpdatedBefore = new DateTime();
            request.LastUpdatedBefore = lastUpdatedBefore;
            List<string> orderStatus = new List<string>();
            request.OrderStatus = orderStatus;
            List<string> marketplaceId = new List<string>();
            request.MarketplaceId = marketplaceId;
            List<string> fulfillmentChannel = new List<string>();
            request.FulfillmentChannel = fulfillmentChannel;
            List<string> paymentMethod = new List<string>();
            request.PaymentMethod = paymentMethod;
            string buyerEmail = "deneme";
            request.BuyerEmail = buyerEmail;
            string sellerOrderId = "deneme";
            request.SellerOrderId = sellerOrderId;
            decimal maxResultsPerPage = 1;
            request.MaxResultsPerPage = maxResultsPerPage;
            List<string> tfmShipmentStatus = new List<string>();
            request.TFMShipmentStatus = tfmShipmentStatus;
            List<string> easyShipShipmentStatus = new List<string>();
            request.EasyShipShipmentStatus = easyShipShipmentStatus;
            string actualFulfillmentSupplySourceId = "deneme";
            request.ActualFulfillmentSupplySourceId = actualFulfillmentSupplySourceId;
            bool isISPU = true;
            request.IsISPU = isISPU;
            ListOrdersOrderItem item = new ListOrdersOrderItem();
            request.Item = item;
            return this.client.ListOrders(request);
        }

        public ListOrdersByNextTokenResponse InvokeListOrdersByNextToken()
        {
            // Create a request.
            ListOrdersByNextTokenRequest request = new ListOrdersByNextTokenRequest();
            string sellerId = "deneme";
            request.SellerId = sellerId;
            string mwsAuthToken = "deneme";
            request.MWSAuthToken = mwsAuthToken;
            string nextToken = "deneme";
            request.NextToken = nextToken;
            return this.client.ListOrdersByNextToken(request);
        }


    }
}
