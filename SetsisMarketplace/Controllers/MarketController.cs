using GittiGidiyor;
using GittiGidiyor.Sale;
using MarketplaceWebServiceOrders;
using Microsoft.Ajax.Utilities;
using MWSClientCsRuntime;
using Newtonsoft.Json;
using SetsisMarketplace.Class;
using SetsisMarketplace.Models;
using SetsisMarketplace.Models.BaseModel;
using SetsisMarketplace.Models.Login;
using SetsisMarketplace.Models.Trendyol;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using MarketplaceWebServiceOrders.Model;


namespace SetsisMarketplace.Controllers
{
    [_SessionControl]
    public class MarketController : Controller
    {
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        public enum httpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum authenticationType
        {
            Basic,
            NTLM
        }

        public enum autheticationTechnique
        {
            RollYourOwn,
            NetworkCredential
        }

        class RestClient
        {
            public string endPoint { get; set; }
            public httpVerb httpMethod { get; set; }
            public authenticationType authType { get; set; }
            public autheticationTechnique authTech { get; set; }
            public string userName { get; set; }
            public string userPassword { get; set; }


            public RestClient()
            {
                endPoint = string.Empty;
                httpMethod = httpVerb.GET;
            }

            public string makeRequest()
            {
                string strResponseValue = string.Empty;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                request.Method = httpMethod.ToString();

                String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
                request.Headers.Add("Authorization", authType.ToString() + " " + authHeaer);

                HttpWebResponse response = null;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                }
                finally
                {

                    if (response != null)
                    {
                        ((IDisposable)response).Dispose();
                    }

                }

                return strResponseValue;
            }

        }

        public ActionResult Index()
        {
            DataService db = new DataService();
            ViewBag.TotalOrders = db.ReturnScalerData("SELECT Count(*) FROM MarketplaceProduct");
            ViewBag.TotalPrice = db.ReturnScalerData("SELECT SUM(Cast(price as numeric(18,2))) FROM MarketplaceProduct");
            ViewBag.TotalProduct = db.ReturnScalerData("SELECT SUM(Cast(quantity as int)) FROM MarketplaceProduct");
            return View();
        }



        MarketplaceModel ty = new MarketplaceModel();

        string strResponse;

        public static Item items = new Item();


        public void APIPost(string endPoint, List<TYTEST> tyst, int catId)
        {
            ADDRoot root = new ADDRoot();

            foreach (var item in tyst)
            {
                Item data = new Item();
                Image img = new Image();
                data.barcode = "6555268978550";
                data.description = item.UrunAdi;
                data.title = item.UrunKodu;
                data.cargoCompanyId = 10;
                data.listPrice = 9999;
                data.salePrice = 9999;
                data.currencyType = "TRY";
                data.quantity = 1;
                data.stockCode = item.UrunKodu;
                data.categoryId = catId;
                data.brandId = 1791;
                data.productMainId = "1234BT";
                data.vatRate = 18;
                data.dimensionalWeight = 1;
                //data.gender = "Erkek";
                img.url = "https://cdn.webrazzi.com/uploads/2019/08/trendyol-632_hd.png";

                Attributes attribute1 = new Attributes();
                attribute1.attributeId = 338;
                attribute1.attributeValueId = 6981;

                Attributes attribute2 = new Attributes();
                attribute2.attributeId = 565;
                attribute2.attributeValueId = 3212;

                data.images.Add(img);
                data.attributes.Add(attribute1);
                data.attributes.Add(attribute2);
                root.items.Add(data);


                break;
            }
            Uri myUri = new Uri(endPoint);

            var httpWebRequest = WebRequest.Create(myUri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("SmwndHyUngYgqFkiGYFf" + ":" + "DetgCDKPGJgUEFycNwne"));


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(root);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public void APICon(string endPoint, string userName, string userPassword)
        {
            RestClient rest = new RestClient();
            rest.authType = authenticationType.Basic;
            rest.endPoint = endPoint;
            rest.userName = userName;
            rest.userPassword = userPassword;
            strResponse = string.Empty;
            strResponse = rest.makeRequest();
        }

        public void SaveOrders()
        {
            /*TEST: NEBIM VERITABANI ICIN YAZILACAK VERILER*/

            DataService2 db2 = new DataService2();
            DataService db = new DataService();

            //Şirket Bilgilerini Alma
            string user = HttpContext.User.Identity.Name.ToString();
            List<CompanyInfo> companyInfos = db.GetCompanyInfos(user);
            string companyName = companyInfos.Select(x => x.CompanyName).FirstOrDefault();
            string CompanyCode = companyInfos.Select(x => x.CompanyCode).FirstOrDefault();
            string officeCode = companyInfos.Select(x => x.OfficeCode).FirstOrDefault();
            string WarehouseCode = companyInfos.Select(x => x.WarehouseCode).FirstOrDefault();

            //Postal Bilgileri
            string CityCode = (string)db2.ReturnScalerData("select cdCityDesc.CityCode from cdDistrictDesc inner join cdDistrict on cdDistrictDesc.DistrictCode =cdDistrict.DistrictCode inner join cdCityDesc on cdCityDesc.CityCode = cdDistrict.CityCode where cdCityDesc.CityDescription LIKE '%" + ty.city.Trim().ToUpper() + "%' and cdDistrictDesc.DistrictDescription LIKE '%" + ty.district.Trim().ToUpper() + "%'");
            string DistrictCode = (string)db2.ReturnScalerData("select cdDistrictDesc.DistrictCode from cdDistrictDesc inner join cdDistrict on cdDistrictDesc.DistrictCode = cdDistrict.DistrictCode inner join cdCityDesc on cdCityDesc.CityCode = cdDistrict.CityCode where cdCityDesc.CityDescription LIKE '%" + ty.city.Trim().ToUpper() + "%' and cdDistrictDesc.DistrictDescription LIKE '%" + ty.district.Trim().ToUpper() + "%'");

            if (CityCode == null)
            {
                if (ty.city.Contains("*"))
                {
                    CityCode = "0";
                    DistrictCode = " 0";
                    ty.city = "Sipariş bilgisi gizli, tekrar deneyiniz.";
                }
                else
                {
                    //AddDistrict
                    CityCode = (string)db2.ReturnScalerData("select cdCityDesc.CityCode from cdDistrictDesc inner join cdDistrict on cdDistrictDesc.DistrictCode =cdDistrict.DistrictCode inner join cdCityDesc on cdCityDesc.CityCode = cdDistrict.CityCode where cdCityDesc.CityDescription LIKE '%" + ty.city.Trim().ToUpper() + "%'");
                    DistrictCode = (string)db2.ReturnScalerData("select top 1 cdDistrictDesc.DistrictCode from cdDistrictDesc inner join cdDistrict on cdDistrictDesc.DistrictCode =cdDistrict.DistrictCode inner join cdCityDesc on cdCityDesc.CityCode = cdDistrict.CityCode where cdCityDesc.CityDescription LIKE '%" + ty.city.Trim().ToUpper() + "%' order by cdDistrictDesc.DistrictCode DESC");
                    string newDistrictCode = DistrictCode.Substring(DistrictCode.Length - 2);
                    int newDC = Convert.ToInt16(newDistrictCode) + 1;
                }
           

            }
            else
            {
                //refNumber alma
                db2.AddParameter("@CompanyCode", CompanyCode, DbType.Int32);
                db2.AddParameter("@ProcessCode", "R", DbType.String);
                db2.AddParameter("@ProcessFlowCode", 2, DbType.Int32);
                string refNumber = (string)db2.ReturnScalerData("Setsissp_LastRefNumProcess", CommandType.StoredProcedure);

                //CurrAccCode alma
                db2.AddParameter("@CompanyCode", CompanyCode, DbType.String);
                db2.AddParameter("@CurrAccTypeCode", 4, DbType.Int16);
                db2.AddParameter("@OfficeCode", officeCode, DbType.String);
                db2.AddParameter("@StoreCode", "", DbType.String);
                string currAccCode = (string)db2.ReturnScalerData("sp_LastCodeCurrAcc", CommandType.StoredProcedure);


                //Nebimde bu müşteri var mı?
                bool customerControl = db2.ReturnBoolData("SELECT*FROM cdCurrAcc WHERE FirstName='" + ty.customerFirstName.ToUpper() + "' AND LastName='" + ty.customerLastName.ToUpper() + "'");
                // bool phoneControl = db2.ReturnBoolData("SELECT*FROM prCurrAccCommunication where CommAddress='" + ty.phone + "'");
                if (customerControl == true)
                { }

                else
                {
                    //cdCurrAcc
                    db2.AddParameter("@CurrAccCode", currAccCode, DbType.String);
                    db2.AddParameter("@CurrAccTypeCode", 4, DbType.Int16);
                    db2.AddParameter("@FirstName", ty.customerFirstName.ToUpper(), DbType.String);
                    db2.AddParameter("@LastName", ty.customerLastName.ToUpper(), DbType.String);
                    db2.AddParameter("@IdentityNum", ty.identityNumber, DbType.String);
                    db2.AddParameter("@TaxNumber", ty.taxNumber ?? "", DbType.String);
                    db2.AddParameter("@CurrencyCode", "TRY", DbType.String);
                    db2.AddParameter("@CompanyCode", Convert.ToDecimal(CompanyCode), DbType.Decimal);//TEST
                    db2.AddParameter("@OfficeCode", officeCode, DbType.String);//TEST
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    db2.ReturnScalerData("SetsisInsertCdCurrAcc", CommandType.StoredProcedure);

                    //cdCurrAccDesc
                    db2.AddParameter("@CurrAccCode", currAccCode, DbType.String);
                    db2.AddParameter("@CurrAccTypeCode", 4, DbType.Int16);
                    db2.AddParameter("@LangCode", "TR", DbType.String);
                    db2.AddParameter("@CurrAccDescription", ty.customerFirstName.ToUpper() + " " + ty.customerLastName.ToUpper(), DbType.String);
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    db2.ReturnScalerData("SetsisMergeCdCurrAccDesc", CommandType.StoredProcedure);


                    //prCurrAccCommunication
                    if (string.IsNullOrEmpty(ty.phone))
                    {
                        db2.AddParameter("@CurrAccCode", currAccCode, DbType.String);
                        db2.AddParameter("@CommunicationTypeCode", "1", DbType.String);//kontrol
                        db2.AddParameter("@CommAddress", ty.phone ?? "", DbType.String);
                        db2.AddParameter("@CreatedUserName", user ?? "", DbType.String);
                        db2.ReturnScalerData("SetsisInsertPrCurrAccCommunication", CommandType.StoredProcedure);
                    }

                    //Adres Uzunluk Kontrolü
                    if (ty.address1.Length > 200)
                    {
                        //HATA KODU 701: Adres çok uzun, sistem yöneticinizle görüşünüz.
                    }
                    else
                    { }

                    //prCurrAccPostalAddress
                    db2.AddParameter("@CurrAccCode", currAccCode, DbType.String);
                    db2.AddParameter("@CurraccTypeCode", "4", DbType.String);
                    db2.AddParameter("@Address", ty.address1, DbType.String);
                    db2.AddParameter("@CityCode", CityCode, DbType.String);
                    db2.AddParameter("@DistrictCode", DistrictCode, DbType.String);
                    db2.AddParameter("@TaxNumber", ty.taxNumber ?? "", DbType.String);
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    Guid postalID = (Guid)db2.ReturnScalerData("SetsisInsertprCurrAccPostalAddress", CommandType.StoredProcedure);


                    //trOrderHeader
                    db2.AddParameter("@OrderTypeCode", "1", DbType.String);
                    db2.AddParameter("@ProcessCode", "R", DbType.String);
                    db2.AddParameter("@OrderNumber", refNumber, DbType.String);//kontrol
                    db2.AddParameter("@DocumentNumber", "", DbType.String);
                    db2.AddParameter("@PaymentTerm", 0, DbType.Int16);
                    db2.AddParameter("@Description", ty.orderNumber, DbType.String);
                    db2.AddParameter("@InternalDescription", "", DbType.String);
                    db2.AddParameter("@CurrAccTypeCode", 4, DbType.Int16);
                    db2.AddParameter("@CurrAccCode", currAccCode, DbType.String);
                    db2.AddParameter("@ShipmentMethodCode", "", DbType.String);
                    db2.AddParameter("@ShippingPostalAddressID", postalID, DbType.Guid);
                    db2.AddParameter("@BillingPostalAddressID", postalID, DbType.Guid);
                    db2.AddParameter("@RoundsmanCode", "", DbType.String);
                    db2.AddParameter("@DeliveryCompanyCode", "", DbType.String);
                    db2.AddParameter("@TaxTypeCode", 0, DbType.Int16);
                    db2.AddParameter("@DOVCode", "", DbType.String);
                    db2.AddParameter("@TaxExemptionCode", 0, DbType.Int16);
                    db2.AddParameter("@CompanyCode", Convert.ToInt16(CompanyCode), DbType.Int32);//CompanyCode numeric
                    db2.AddParameter("@OfficeCode", officeCode, DbType.String);
                    db2.AddParameter("@StoreTypeCode", 5, DbType.Int32);
                    db2.AddParameter("@StoreCode", "", DbType.String);
                    db2.AddParameter("@POSTerminalID", 0, DbType.Int32);
                    db2.AddParameter("@WarehouseCode", WarehouseCode, DbType.String);
                    db2.AddParameter("@ToWarehouseCode", "1-2-1", DbType.String);//?
                    db2.AddParameter("@OrdererCompanyCode", 1, DbType.Int32);//?
                    db2.AddParameter("@OrdererOfficeCode", "M", DbType.String);//?
                    db2.AddParameter("@OrdererStoreCode", "", DbType.String);//?
                    db2.AddParameter("@GLTypeCode", "", DbType.String);
                    db2.AddParameter("@DocCurrencyCode", "TRY", DbType.String);
                    db2.AddParameter("@LocalCurrencyCode", "TRY", DbType.String);
                    db2.AddParameter("@ExchangeRate", 0, DbType.Double);
                    db2.AddParameter("@TDisRate1", 0, DbType.Double);
                    db2.AddParameter("@TDisRate2", 0, DbType.Double);
                    db2.AddParameter("@TDisRate2", 0, DbType.Double);
                    db2.AddParameter("@TDisRate3", 0, DbType.Double);
                    db2.AddParameter("@TDisRate4", 0, DbType.Double);
                    db2.AddParameter("@TDisRate5", 0, DbType.Double);
                    db2.AddParameter("@DiscountReasonCode", 0, DbType.Int16);
                    db2.AddParameter("@SurplusOrderQtyToleranceRate", 0, DbType.Double);
                    db2.AddParameter("@ImportFileNumber", "", DbType.String);
                    db2.AddParameter("@ExportFileNumber", "", DbType.String);
                    db2.AddParameter("@IncotermCode1", "", DbType.String);
                    db2.AddParameter("@IncotermCode2", "", DbType.String);
                    db2.AddParameter("@LettersOfCreditNumber", "", DbType.String);
                    db2.AddParameter("@PaymentMethodCode", "", DbType.String);
                    db2.AddParameter("@IsInclutedVat", 0, DbType.Byte);
                    db2.AddParameter("@IsCreditSale", 0, DbType.Byte);
                    db2.AddParameter("@IsCreditableConfirmed", 1, DbType.Byte);
                    db2.AddParameter("@IsCompleted", 0, DbType.Byte);
                    db2.AddParameter("@IsPrinted", 0, DbType.Byte);
                    db2.AddParameter("@IsLocked", 0, DbType.Byte);
                    db2.AddParameter("@IsClosed", 0, DbType.Byte);
                    db2.AddParameter("@ApplicationCode", "Order", DbType.String);//?
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    Guid trOrderHeaderID = (Guid)db2.ReturnScalerData("Setsis_sp_CreateOrderHeader", CommandType.StoredProcedure);


                    //trOrderLine
                    db2.AddParameter("@ItemTypeCode", 1, DbType.Int16);
                    db2.AddParameter("@ItemCode", "039002-129841", DbType.String);//ty.sku
                    db2.AddParameter("@ColorCode", "K99", DbType.String);//ty.productColor
                    db2.AddParameter("@ItemDim1Code", "42", DbType.String);//variant
                    db2.AddParameter("@ItemDim2Code", "", DbType.String);
                    db2.AddParameter("@ItemDim3Code", "", DbType.String);
                    db2.AddParameter("@Qty1", ty.quantity, DbType.Decimal);
                    db2.AddParameter("@Qty2", 0, DbType.Decimal);
                    db2.AddParameter("@CancelQty1", 0, DbType.Decimal);
                    db2.AddParameter("@CancelQty2", 0, DbType.Decimal);
                    db2.AddParameter("@OrderCancelReasonCode", "", DbType.String);
                    db2.AddParameter("@SalespersonCode", "", DbType.String);
                    db2.AddParameter("@PaymentPlanCode", "", DbType.String);
                    db2.AddParameter("@LineDescription", "", DbType.String);
                    db2.AddParameter("@UsedBarcode", ty.barcode, DbType.String);
                    db2.AddParameter("@CostCenterCode", "", DbType.String);
                    db2.AddParameter("@VatCode", "%" + ty.vatBaseAmount, DbType.String);
                    db2.AddParameter("@VatRate", 0, DbType.Int16);
                    db2.AddParameter("@PCTCode", "%0", DbType.String);
                    db2.AddParameter("@PCTRate", 0, DbType.Int16);
                    db2.AddParameter("@LDisRate1", "0", DbType.Decimal);
                    db2.AddParameter("@LDisRate2", "0", DbType.Decimal);
                    db2.AddParameter("@LDisRate3", "0", DbType.Decimal);
                    db2.AddParameter("@LDisRate4", "0", DbType.Decimal);
                    db2.AddParameter("@LDisRate5", "0", DbType.Decimal);
                    db2.AddParameter("@DocCurrencyCode", "", DbType.String);
                    db2.AddParameter("@PriceCurrencyCode", "", DbType.String);
                    db2.AddParameter("@PriceExchangeRate", "0", DbType.Decimal);
                    db2.AddParameter("@Price", ty.price, DbType.Decimal);
                    db2.AddParameter("@BaseProcessCode", "", DbType.String);
                    db2.AddParameter("@BaseOrderNumber", "", DbType.String);
                    db2.AddParameter("@BaseCustomerTypeCode", 0, DbType.Int16);
                    db2.AddParameter("@BaseCustomerCode", "0", DbType.String);
                    db2.AddParameter("@BaseStoreCode", "", DbType.String);
                    db2.AddParameter("@OrderHeaderID", trOrderHeaderID, DbType.Guid);
                    db2.AddParameter("@OrderLineSumID", 0, DbType.Int16);
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    db2.AddParameter("@LastUpdatedUserName", user, DbType.String);
                    Guid trOrderLineID = (Guid)db2.ReturnScalerData("Setsis_sp_CreateOrderLine", CommandType.StoredProcedure);

                    decimal vat = Math.Ceiling(decimal.Parse((Convert.ToDouble(ty.vatBaseAmount) * 0.1f).ToString()) * 100) / 100;

                    //trOrderLineCurrency
                    db2.AddParameter("@OrderLineID", trOrderLineID, DbType.Guid);
                    db2.AddParameter("@CurrencyCode", "TRY", DbType.String);
                    db2.AddParameter("@ExchangeRate", 1, DbType.Decimal);
                    db2.AddParameter("@RelationCurrencyCode", "TRY", DbType.String);
                    db2.AddParameter("@PriceVI", Convert.ToDouble(ty.totalPrice), DbType.Double);
                    db2.AddParameter("@AmountVI", Convert.ToDouble(ty.totalPrice) * Convert.ToDouble(ty.quantity), DbType.Double);
                    db2.AddParameter("@Price", Convert.ToDecimal(Convert.ToDecimal(ty.price) / vat), DbType.Decimal);
                    db2.AddParameter("@Amount", Convert.ToDecimal(Convert.ToDecimal(ty.price) / vat) * Convert.ToDecimal(ty.quantity), DbType.Decimal);
                    db2.AddParameter("@LDiscount1", ty.discount ?? "0", DbType.Decimal);
                    db2.AddParameter("@LDiscountVI1", 0, DbType.Decimal);
                    db2.AddParameter("@TaxBase", Convert.ToDecimal(ty.totalPrice) / vat, DbType.Decimal);
                    db2.AddParameter("@Vat", Convert.ToDecimal(ty.totalPrice) / vat, DbType.Decimal);
                    db2.AddParameter("@NetAmount", Convert.ToDouble(ty.totalPrice) * Convert.ToDouble(ty.quantity), DbType.Double);
                    db2.AddParameter("@CreatedUserName", user, DbType.String);
                    db2.ReturnScalerData("Setsis_sp_MergeOrderLineCurrency", CommandType.StoredProcedure);
                }
            }
    }

        public ActionResult HBOrders()
        {
            DataService db = new DataService();

            APICon("https://oms-external.hepsiburada.com/orders/merchantid/f4e26b22-3149-43aa-8a90-b83b78f5f1f5", "dsmteknoloji_dev", "!OoLHLzPsKaDgz");
            string a = strResponse.Substring(0, strResponse.Length - 1);
            if (a.Length<100)
            {
                return View("Norder");
            }
            var js = JsonConvert.DeserializeObject<List<HBModel>>(a);

            foreach (var item in js)
            {
                foreach (var item2 in item.items)
                {
                    db.AddParameter("@orderNumber", item2.orderNumber, DbType.String);
                    MarketplaceModel model = db.GetTYOrder();
                    if (model != null)
                    {
                        //Birşey Yapma
                    }
                    else
                    {
                        ty = new MarketplaceModel();
                        ty.orderNumber = item2.orderNumber;
                        ty.address1 = item.shippingAddressDetail;
                        ty.cargoProviderName = item.cargoCompany;
                        ty.cargoTrackingLink = string.Empty;
                        ty.city = item.shippingCity;
                        ty.customerEmail = item.email;
                        ty.customerFirstName = item.recipientName;
                        ty.customerLastName = item.companyName;
                        ty.district = item.shippingTown;
                        ty.identityNumber = item.identityNo;
                        ty.orderDate = item.orderDate.ToString();
                        ty.phone = item.phoneNumber;
                        ty.postalCode = item.shippingCountryCode;
                        ty.price = item.totalPrice.amount.ToString();
                        ty.totalPrice = item.totalPrice.amount.ToString();
                        ty.quantity = item2.quantity.ToString();
                        ty.shipmentPackageStatus = item.status;
                        ty.sku = item2.merchantSku.ToString();
                        ty.amount = item.totalPrice.amount.ToString();
                        ty.store = "Hepsiburada";
                        ty.taxNumber = item.taxNumber;
                        ty.productName = item2.productName;
                        ty.productId = item2.listingId.ToString();
                        ty.barcode = item.barcode;
                        ty.vatBaseAmount = item.items.Select(x=>x.vat).FirstOrDefault().ToString();
                        SaveOrders();

                    }
                }
            }
            return View(js);
        }

        public SelectList getSelectList(CategoryRoot catroot)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var row in catroot.categories)
            {
                //list.Add(new SelectListItem()
                //{
                //    Text = row.name.ToString(),
                //    Value = row.id.ToString()
                //});

                foreach (var row2 in row.subCategories)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row.name.ToString() + ">" + row2.name.ToString(),
                        Value = row2.id.ToString()
                    });

                    foreach (var row3 in row2.subCategories)
                    {
                        list.Add(new SelectListItem()
                        {
                            Text = row.name.ToString() + ">" + row2.name.ToString() + ">" + row3.name.ToString(),
                            Value = row3.id.ToString()
                        });

                        foreach (var row4 in row3.subCategories)
                        {
                            list.Add(new SelectListItem()
                            {
                                Text = row.name.ToString() + ">" + row2.name.ToString() + ">" + row3.name.ToString() + ">" + row4.name.ToString(),
                                Value = row4.id.ToString()
                            });

                            foreach (var row5 in row4.subCategories)
                            {
                                list.Add(new SelectListItem()
                                {
                                    Text = row.name.ToString() + ">" + row2.name.ToString() + ">" + row3.name.ToString() + ">" + row4.name.ToString() + ">" + row5.name.ToString(),
                                    Value = row4.id.ToString()
                                });
                            }
                        }
                    }
                }
            }
            return new SelectList(list, "Value", "Text");

        }

        public ActionResult TYAddProduct(int? id, string name, string cat)
        {
            DataService2 db = new DataService2();
            //List<TYTEST> tyst = db.TYGetStockCards();
            //APIPost("https://api.trendyol.com/sapigw/suppliers/106272/v2/products", tyst);

            CategoryRoot catroot = new CategoryRoot();
            APICon("https://api.trendyol.com/sapigw/product-categories", string.Empty, string.Empty);
            catroot = JsonConvert.DeserializeObject<CategoryRoot>(strResponse);
            List<CategoryRoot> pr = new List<CategoryRoot> { catroot };
            TYMultiClass tym = new TYMultiClass();
            List<HierarchyModel> hm = db.GetHirarchy();
            tym.Hierarchies = hm;
            tym.Categories = pr;

            ViewBag.CatList = getSelectList(catroot);

            if (id != null)
            {
                HierarchyModel hierarchy = new HierarchyModel();
                CategoryMatch match = new CategoryMatch();

                name = name.Replace("&gt;", ">");
                name = name.Replace("&amp;", "&");
                cat = cat.Trim();
                char[] ch = { '>' };
                string[] subs = name.Split(ch);
                string[] cats = cat.Split(ch);
                //match.id = catroot.categories.Select(x => x.name).ToString();
                match.ProductCategory = cats[0];
                match.ProductSubCategory = cats[1];
                match.parentId = id.ToString();
                match.name = subs[0].ToString();
                match.subname = subs[1].ToString();
                // match.subname = catroot.categories.Select(x => x.name).ToString();
                db.AddParameter("@ProductCategory", match.ProductCategory ?? string.Empty);
                db.AddParameter("@ProductSubCategory", match.ProductSubCategory ?? string.Empty);
                db.AddParameter("@parentId", match.parentId.ToString());
                db.AddParameter("@name", match.name.ToString());
                db.AddParameter("@subname", match.subname.ToString());
                db.DataCommit("INSERT INTO TYCategories (ProductCategory,ProductSubCategory,name,subname,parentId)"
                    +
                    "VALUES (@ProductCategory,@ProductSubCategory,@name,@subname,@parentId)", CommandType.Text);
            }

            return View(tym);
        }

        Root rt;
        public ActionResult TYOrders()
        {
            DataService db = new DataService();
            DataService2 db2 = new DataService2();

            APICon("https://api.trendyol.com/sapigw/suppliers/106272/orders?orderByDirection=DESC", "SmwndHyUngYgqFkiGYFf", "DetgCDKPGJgUEFycNwne");
            rt = JsonConvert.DeserializeObject<Root>(strResponse);
            List<Root> pr = new List<Root> { rt };

            foreach (var item in pr)
            {
                foreach (var item2 in item.Content)
                {
                    //db.AddParameter("@orderNumber", item2.orderNumber, DbType.String);
                    //MarketplaceModel model = db.GetTYOrder();

                    if (false)
                    {
                        //Birşey Yapma
                    }
                    else
                    {
                        //Trendyol tablosuna yazılan veriler
                        ty = new MarketplaceModel();
                        ty.orderNumber = item2.orderNumber.ToString();
                        ty.cargoProviderName = item2.cargoProviderName;
                        ty.cargoTrackingLink = item2.cargoTrackingNumber.ToString();
                        ty.cargoTrackingNumber = item2.cargoTrackingNumber.ToString();
                        ty.customerEmail = item2.customerEmail;
                        ty.totalPrice = item2.totalPrice.ToString();
                        ty.price = item2.lines.Select(x => x.price).FirstOrDefault().ToString();
                        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(item2.orderDate);
                        ty.orderDate = dateTimeOffset.ToString();
                        ty.shipmentPackageStatus = item2.shipmentPackageStatus;
                        ty.customerFirstName = item2.customerFirstName;
                        ty.customerLastName = item2.customerLastName;
                        ty.address1 = item2.shipmentAddress.address1;
                        ty.address2 = item2.shipmentAddress.address2;
                        ty.city = item2.shipmentAddress.city;
                        ty.productName = item2.lines.Select(x => x.productName).FirstOrDefault().ToString();
                        ty.productSize = item2.lines.Select(x => x.productSize).FirstOrDefault().ToString();
                        ty.quantity = item2.lines.Select(x => x.quantity).FirstOrDefault().ToString();
                        ty.amount = item2.lines.Select(x => x.amount).FirstOrDefault().ToString();
                        ty.barcode = item2.lines.Select(x => x.barcode).FirstOrDefault();
                        //ty.productColor = item2.Lines.Select(x => x.productColor).FirstOrDefault();
                        ty.productId = item2.lines.Select(x => x.merchantId).FirstOrDefault().ToString();
                        ty.district = item2.shipmentAddress.district;
                        ty.postalCode = item2.shipmentAddress.postalCode;
                        //ty.cargoTrackingLink = item2.cargoTrackingLink.ToString();
                        //ty.sku = item2.SKU.ToString();
                        ty.identityNumber = item2.tcIdentityNumber;
                        ty.taxNumber = item2.taxNumber ?? "";
                        ty.vatBaseAmount = item2.lines.Select(x => x.vatBaseAmount).FirstOrDefault().ToString();
                        ty.store = "Trendyol";

                        SaveOrders();
                    }
                }
            }
        
            return View(pr);
        }


        [HttpGet]
        public ActionResult GGOrders()
        {
            DataService db = new DataService();
            AuthConfig config = new AuthConfig();
            config.ApiKey = "NkR79sz5KRqzq7UjPt6a9QWPqX9Uf22z";
            config.SecretKey = "Mjn7NTZTn2N2mVRX";
            config.RoleName = "kargoobizden";
            config.RolePass = "U3msqJDpcn5vjV5CwjPh6WW3yJChBn72";
            ConfigurationManager.setAuthParameters(config);

            SaleService saleService = ServiceProvider.getSaleService();
            saleServiceResponse response = saleService.getSales(true, "S", string.Empty, "A", "A", 1, 50, "tr");
            saleType[] sale = response.sales;
            List<saleType> ls = sale.OfType<saleType>().ToList();


            if (response != null && response.ackCode.ToString().Equals("success"))
            {
                if (response.sales != null)
                {
                    foreach (var sales in ls)
                    {
                        db.AddParameter("@orderNumber", sales.saleCode);
                        MarketplaceModel model = db.GetTYOrder();

                        if (model == null)
                        {
                            ty = new MarketplaceModel();

                            ty.quantity = sales.amount.ToString();
                            ty.address1 = sales.buyerInfo.address;
                            ty.city = sales.buyerInfo.city;
                            ty.district = sales.buyerInfo.district;
                            ty.customerEmail = sales.buyerInfo.email;
                            ty.phone = sales.buyerInfo.phone;
                            ty.customerFirstName = sales.buyerInfo.name;
                            ty.customerLastName = sales.buyerInfo.surname;
                            ty.postalCode = sales.buyerInfo.zipCode;
                            ty.orderDate = sales.endDate;
                            ty.price = sales.price;
                            ty.productId = sales.productId.ToString();
                            ty.productName = sales.productTitle;
                            ty.shipmentPackageStatus = sales.status;
                            ty.imageUrl = sales.thumbImageLink;
                            ty.orderNumber = sales.saleCode;
                            ty.cargoTrackingNumber = sales.cargoCode;
                            ty.store = "Gittigidiyor";

                            db.AddParameter("@quantity", ty.quantity.ToString());
                            db.AddParameter("@address1", ty.address1);
                            db.AddParameter("@city", ty.city ?? string.Empty);
                            db.AddParameter("@district", ty.district ?? string.Empty);
                            db.AddParameter("@customerEmail", ty.customerEmail ?? string.Empty);
                            db.AddParameter("@phone", ty.phone.ToString());
                            db.AddParameter("@customerFirstName", ty.customerFirstName.ToString());
                            db.AddParameter("@customerLastName", ty.customerLastName.ToString());
                            db.AddParameter("@postalCode", ty.postalCode ?? string.Empty);
                            db.AddParameter("@orderDate", ty.orderDate.ToString());
                            db.AddParameter("@price", ty.price.ToString());
                            db.AddParameter("@productId", ty.productId.ToString() ?? string.Empty);
                            db.AddParameter("@productName", ty.productName.ToString());
                            db.AddParameter("@shipmentPackageStatus", ty.shipmentPackageStatus.ToString());
                            db.AddParameter("@imageUrl", ty.imageUrl.ToString());
                            db.AddParameter("@orderNumber", ty.orderNumber.ToString());
                            db.AddParameter("@cargoTrackingNumber", ty.cargoTrackingNumber.ToString() ?? string.Empty);
                            db.AddParameter("@store", ty.store ?? string.Empty);

                            db.DataCommit("INSERT INTO MarketplaceProduct (quantity,address1,city,district,customerEmail,phone,customerFirstName,customerLastName,postalCode,orderDate,price,productId,productName,shipmentPackageStatus,imageUrl,orderNumber,cargoTrackingNumber,store) "
                                +
                                "VALUES (@quantity,@address1,@city,@district,@customerEmail,@phone,@customerFirstName,@customerLastName,@postalCode,@orderDate,@price,@productId,@productName,@shipmentPackageStatus,@imageUrl,@orderNumber,@cargoTrackingNumber,@store)", CommandType.Text);

                        }

                    }
                }
            }
            return View(ls);

        }


        public ActionResult AmzOrders()
        {
            
            const string marketplaceId = "A33AVAJ2PDY3EV";

            Uri uri = new Uri("https://mws-eu.amazonservices.com/Orders/2013-09-01");
            // Developer AWS access key
            string accessKey = "replaceWithAccessKey";

            // Developer AWS secret key
            string secretKey = "replaceWithSecretKey";

            // The client application name
            string appName = "CSharpSampleCode";

            // The client application version
            string appVersion = "1.0";

            // The endpoint for region service and version (see developer guide)
            // ex: https://mws.amazonservices.com
            string serviceURL = uri.ToString();

            // Create a configuration object
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrdersClient client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            MarketplaceWebServiceOrdersSample sample = new MarketplaceWebServiceOrdersSample(client);


            try
            {
                IMWSResponse response = null;
                // response = sample.InvokeGetOrder();
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
                if (rhmd != null)
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


            return View();
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument SoapOrderDetail(string id)
        {
            XmlDocument soapEnvelopeDocument2 = new XmlDocument();
            soapEnvelopeDocument2.LoadXml(
            @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <sch:OrderDetailRequest>
                         <auth>
                            <appKey>7e78d9e8-0bc9-484a-95d0-894e26f51be3</appKey>
                            <appSecret>x5LVwafip42EcPhW</appSecret>
                         </auth>
                         <orderRequest>
                            <id>" + id.ToString() + "</id> </orderRequest> </sch:OrderDetailRequest> </soapenv:Body> </soapenv:Envelope>");
            return soapEnvelopeDocument2;
        }

        private static XmlDocument SoapOrderList()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(
            @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:sch=""http://www.n11.com/ws/schemas"">
                   <soapenv:Header/>
                   <soapenv:Body>
                      <sch:OrderListRequest>
                         <auth>
                           <appKey>7e78d9e8-0bc9-484a-95d0-894e26f51be3</appKey>
                            <appSecret>x5LVwafip42EcPhW</appSecret>
                         </auth>
                         <searchData>
                            <productId></productId>
                            <status>New</status>
                            <buyerName></buyerName>
                            <orderNumber></orderNumber>
                            <productSellerCode></productSellerCode>
                            <recipient></recipient>
                            <sameDayDelivery></sameDayDelivery>
                            <period>
                               <startDate></startDate>
                               <endDate></endDate>
                            </period>
                            <sortForUpdateDate></sortForUpdateDate>
                         </searchData>
                         <pagingData>
                            <currentPage>0</currentPage>
                            <pageSize>100</pageSize>
                         </pagingData>
                      </sch:OrderListRequest>
                   </soapenv:Body>
                </soapenv:Envelope>
         ");

            return soapEnvelopeDocument;
        }
        List<OrderList> od;
        List<MarketplaceModel> mp;
        List<OrderDetail> pr;

        public ActionResult N11Orders()
        {
            try
            {
                DataService db = new DataService();
                var _url = "https://api.n11.com/ws/OrderService.wsdl";
                var _action = "http://www.n11.com/ws/schemas/OrderServicePort/OrderDetailRequest";
                XmlDocument soapEnvelopeXml = SoapOrderList();

                HttpWebRequest webRequest = CreateWebRequest(_url, _action);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                // begin async call to web request.
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

                // suspend this thread until call is complete. You might want to
                // do something usefull here like update your UI.
                asyncResult.AsyncWaitHandle.WaitOne();

                // get the response from the completed web request.
                string soapResult;
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();

                    }
                    int firstStringPosition = soapResult.IndexOf("<orderList>");
                    int secondStringPosition = soapResult.IndexOf("</orderList>");

                    if (firstStringPosition == -1)
                    {
                        return View("Norder");
                    }
                    else
                    {
                        string stringBetweenTwoStrings = soapResult.Substring(firstStringPosition, secondStringPosition - firstStringPosition + 12);

                        OrderList ReturnedEmployee;
                        XmlSerializer MyDeserializer = new XmlSerializer(typeof(OrderList));
                        ty = new MarketplaceModel();


                        StringReader SR = new StringReader(stringBetweenTwoStrings);
                        XmlReader XR = new XmlTextReader(SR);
                        od = new List<OrderList>();
                        mp = new List<MarketplaceModel> { ty };
                        if (MyDeserializer.CanDeserialize(XR))
                        {
                            ReturnedEmployee = (OrderList)MyDeserializer.Deserialize(XR);
                            od.Add(ReturnedEmployee);
                        }
                        foreach (var item in od)
                        {
                            foreach (var item2 in item.Order)
                            {
                                var _orderDetailURL = "https://api.n11.com/ws/OrderService.wsdl";
                                var _orderDetailAction = "http://www.n11.com/ws/schemas/OrderServicePort/DetailedOrderListRequest";
                                XmlDocument soapEnvelopeXmlOrderDetail = SoapOrderDetail(item2.Id);

                                HttpWebRequest webRequestOrderDetail = CreateWebRequest(_orderDetailURL, _orderDetailAction);
                                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXmlOrderDetail, webRequestOrderDetail);

                                // begin async call to web request.
                                IAsyncResult asyncResultOrderDetail = webRequestOrderDetail.BeginGetResponse(null, null);

                                // suspend this thread until call is complete. You might want to
                                // do something usefull here like update your UI.
                                asyncResultOrderDetail.AsyncWaitHandle.WaitOne();

                                // get the response from the completed web request.
                                string soapResult2;
                                using (WebResponse webResponse2 = webRequestOrderDetail.EndGetResponse(asyncResultOrderDetail))
                                {
                                    using (StreamReader rdOrderDetail = new StreamReader(webResponse2.GetResponseStream()))
                                    {
                                        soapResult2 = rdOrderDetail.ReadToEnd();
                                    }

                                    int firstStringPositionOrderDetail = soapResult2.IndexOf("<orderDetail>");
                                    int secondStringPositionOrderDetail = soapResult2.IndexOf("</orderDetail>");
                                    string stringBetweenTwoStringsOrderDetail = soapResult2.Substring(firstStringPositionOrderDetail, secondStringPositionOrderDetail - firstStringPositionOrderDetail + 14);

                                    OrderDetail ReturnedEmployeeOrderDetail;
                                    XmlSerializer MyDeserializerOrderDetail = new XmlSerializer(typeof(OrderDetail));
                                    ty = new MarketplaceModel();


                                    StringReader SROrderDetail = new StringReader(stringBetweenTwoStringsOrderDetail);
                                    XmlReader XROrderDetail = new XmlTextReader(SROrderDetail);
                                    pr = new List<OrderDetail>();
                                    mp = new List<MarketplaceModel> { ty };

                                    if (MyDeserializerOrderDetail.CanDeserialize(XROrderDetail))
                                    {
                                        ReturnedEmployeeOrderDetail = (OrderDetail)MyDeserializerOrderDetail.Deserialize(XROrderDetail);
                                        pr.Add(ReturnedEmployeeOrderDetail);
                                    }

                                    foreach (var item3 in pr)
                                    {
                                        db.AddParameter("@orderNumber", item2.OrderNumber, DbType.String);
                                        MarketplaceModel model = db.GetTYOrder();

                                        if (model != null)
                                        {
                                            //Birşey Yapma
                                        }
                                        else
                                        {
                                            ty.orderNumber = item3.OrderNumber.ToString();
                                            ty.productId = item3.ItemList.Item.ProductId.ToString();
                                            ty.address1 = item3.ShippingAddress.Address.ToString();
                                            ty.productName = item3.ItemList.Item.ProductName.ToString();
                                            ty.sku = item3.ItemList.Item.ProductSellerCode.ToString();
                                            ty.shipmentPackageStatus = item3.ItemList.Item.ShipmentInfo.CampaignNumberStatus.ToString();
                                            ty.phone = item3.ShippingAddress.Gsm.ToString();
                                            ty.customerFirstName = item3.Buyer.FullName.ToString();
                                            ty.quantity = item3.ItemList.Item.Quantity.ToString();
                                            ty.totalPrice = item3.ItemList.Item.Price.ToString();
                                            ty.city = item3.ShippingAddress.City.ToString();
                                            ty.district = item3.ShippingAddress.District.ToString();
                                            ty.customerEmail = item3.Buyer.Email.ToString();
                                            ty.orderDate = item3.CreateDate.ToString();
                                            ty.price = item3.BillingTemplate.OriginalPrice.ToString();
                                            ty.cargoProviderName = item3.ItemList.Item.ShipmentInfo.ShipmentCompany.Name.ToString();
                                            ty.amount = item3.BillingTemplate.DueAmount.ToString();
                                            ty.store = "n11";
                                            db.AddParameter("@orderNumber", ty.orderNumber.ToString());
                                            db.AddParameter("@productName", ty.productName);
                                            db.AddParameter("@cargoProviderName", ty.cargoProviderName ?? string.Empty);
                                            db.AddParameter("@customerEmail", ty.customerEmail ?? string.Empty);
                                            db.AddParameter("@totalPrice", ty.totalPrice ?? string.Empty);
                                            db.AddParameter("@orderDate", ty.orderDate.ToString());
                                            db.AddParameter("@shipmentPackageStatus", ty.shipmentPackageStatus.ToString());
                                            db.AddParameter("@customerFirstName", ty.customerFirstName.ToString());
                                            db.AddParameter("@address1", ty.address1 ?? string.Empty);
                                            db.AddParameter("@city", ty.city.ToString());
                                            db.AddParameter("@quantity", ty.quantity.ToString());
                                            db.AddParameter("@amount", ty.amount.ToString() ?? string.Empty);
                                            db.AddParameter("@productId", ty.productId.ToString());
                                            db.AddParameter("@district", ty.district.ToString());
                                            db.AddParameter("@sku", ty.sku.ToString());
                                            db.AddParameter("@price", ty.price.ToString());
                                            db.AddParameter("@store", ty.store.ToString() ?? string.Empty);


                                            db.DataCommit("INSERT INTO MarketplaceProduct (orderNumber,productName,cargoProviderName,customerEmail,totalPrice,orderDate,shipmentPackageStatus,customerFirstName,address1,city,quantity,amount,productId,district,sku,price,store) "
                                                +
                                                "VALUES (@orderNumber,@productName,@cargoProviderName,@customerEmail,@totalPrice,@orderDate,@shipmentPackageStatus,@customerFirstName,@address1,@city,@quantity,@amount,@productId,@district,@sku,@price,@store)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return View("Error");

            }
            return View(pr);
        }



        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Norder()
        {
            return View();
        }
    }
}






