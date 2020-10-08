using SetsisMarketplace.Class;
using SetsisMarketplace.Models.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetsisMarketplace.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult SetUsers()
        {

            DataService2 db = new DataService2();
            List<SelectListItem> companyNames = new List<SelectListItem>();
            listCompanyModel listCompany = new listCompanyModel();

            List<CompanyModel> states = db.GetCompany().ToList();
            states.ForEach(x =>
            {
                companyNames.Add(new SelectListItem { Text = x.CompanyName, Value = x.CompanyCode.ToString() });
            });
            listCompany.CompanyNames = companyNames;

            return View(listCompany);
        }

        [HttpPost]
        public ActionResult GetOffices(string CompanyCode)
        {
            DataService2 db = new DataService2();

            List<SelectListItem> OfficeCodes = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(CompanyCode))
            {
                List<OfficeModel> offices = db.GetOffice(CompanyCode).ToList();
                offices.ForEach(x =>
                {
                    OfficeCodes.Add(new SelectListItem { Text = x.OfficeCode.ToString(), Value = x.CompanyCode.ToString() });
                });
            }
            return Json(OfficeCodes, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetWarehouses(string OfficeCode)
        {
            DataService2 db = new DataService2();

            List<SelectListItem> WarehouseCodes = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(OfficeCode))
            {
                List<WarehouseModel> wares = db.GetWarehouse(OfficeCode).ToList();
                wares.ForEach(x =>
                {
                    WarehouseCodes.Add(new SelectListItem { Text = x.WarehouseCode.ToString(), Value = x.OfficeCode.ToString() });
                });
            }
            return Json(WarehouseCodes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(string CompanyName, string CompanyCode, string OfficeCode, string WarehouseCode, string username, string password, string NameSurname)
        {
            DataService2 db = new DataService2();

            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();

            db.DataCommit("UPDATE Users SET Username='" + usrname + "', password='" + password + "', Name='" + NameSurname + "' , Surname='" + NameSurname + "' WHERE UserID='" + userid + "'");

            db.DataCommit("UPDATE SetCompany SET CompanyName='" + CompanyName + "', CompanyCode='" + CompanyCode + "',OfficeCode='" + OfficeCode + "', WarehouseCode='" + WarehouseCode + "' WHERE UserID='" + userid + "'");


            //db.AddParameter("@CompanyName",CompanyName,DbType.String);
            //db.AddParameter("@OfficeCode", CompanyName, DbType.String);
            //db.AddParameter("@WarehouseCode", CompanyName, DbType.String);


            return View();
        }


        public ActionResult SetAPI()
        {
            DataService db = new DataService();
            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();
    
            return View();
        }

        [HttpPost]
        public ActionResult HBAPI(string username, string password, string merchantID)
        {
            DataService db = new DataService();
            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();
            if (db.ReturnScalerData("select*from API_HB where UserID=" + userid, CommandType.Text) != null)
            {
                db.DataCommit("UPDATE API_HB SET username='" + username + "', password='" + password + "', merchantID='" + merchantID + "' WHERE UserID='" + userid + "'");
            }

            else
            {
                db.AddParameter("@username", username.ToString());
                db.AddParameter("@password", password.ToString());
                db.AddParameter("@merchantID", merchantID.ToString());
                db.AddParameter("@UserID", userid.ToString());

                db.DataCommit("INSERT INTO API_HB (username,password,merchantID,UserID) VALUES (@username,@password,@merchantID,@UserID)", CommandType.Text);
            }
            return View();
        }



        [HttpPost]
        public ActionResult TYAPI(string APIKey, string APISecret, string SupplierID)
        {
            DataService db = new DataService();
            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();
            if (db.ReturnScalerData("select*from API_TY where UserID=" + userid, CommandType.Text) != null)
            {
                db.DataCommit("UPDATE API_TY SET APIKey='" + APIKey + "', APISecret='" + APISecret + "', SupplierID='" + SupplierID + "' WHERE UserID='" + userid + "'");
            }

            else
            {
                db.AddParameter("@APIKey", APIKey.ToString());
                db.AddParameter("@APISecret", APISecret.ToString());
                db.AddParameter("@SupplierID", SupplierID.ToString());
                db.AddParameter("@UserID", userid.ToString());

                db.DataCommit("INSERT INTO API_TY (APIKey,APISecret,SupplierID,UserID) VALUES (@APIKey,@APISecret,@SupplierID,@UserID)", CommandType.Text);
            }
            return View();
        }


        [HttpPost]
        public ActionResult GGAPI(string APIKey, string SecretKey, string RoleName, string RolePass)
        {
            DataService db = new DataService();
            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();
            if (db.ReturnScalerData("select*from API_GG where UserID=" + userid) != null)
            {
                db.DataCommit("UPDATE API_GG SET APIKey='" + APIKey + "', SecretKey='" + SecretKey + "', RoleName='" + RoleName +"' ,RolePass='"+RolePass+"' WHERE UserID='" + userid + "'", CommandType.Text);
            }

            else
            {
                db.AddParameter("@APIKey", APIKey.ToString());
                db.AddParameter("@SecretKey", SecretKey.ToString());
                db.AddParameter("@RoleName", RoleName.ToString());
                db.AddParameter("@RolePass", RolePass.ToString());
                db.AddParameter("@UserID", userid.ToString());

                db.DataCommit("INSERT INTO API_GG (APIKey,SecretKey,RoleName,RolePass,userID) VALUES (@APIKey,@SecretKey,@RoleName,@RolePass,@userID)", CommandType.Text);
            }
            return View();
        }


        [HttpPost]
        public ActionResult N11API(string APIKey)
        {
            DataService db = new DataService();
            string usrname = HttpContext.User.Identity.Name.ToString();
            string userid = db.ReturnScalerData("SELECT UserID FROM Users WHERE Username='" + usrname + "'").ToString();
            if (db.ReturnScalerData("select*from API_N11 where UserID=" + userid) != null)
            {
                db.DataCommit("UPDATE API_N11 SET APIKey='" + APIKey +"' WHERE UserID='" + userid + "'");
            }

            else
            {
                db.AddParameter("@APIKey", APIKey.ToString());
                db.AddParameter("@UserID", userid.ToString());

                db.DataCommit("INSERT INTO API_N11 (APIKey,UserID) VALUES (@APIKey,@userID)", CommandType.Text);
            }
            return View();
        }



    }
}