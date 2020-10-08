using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MarketplaceUI.Models;
using SetsisMarketplace.Models;
using SetsisMarketplace.Models.BaseModel;
using SetsisMarketplace.Models.Login;
using SetsisMarketplace.Models.Settings;
using SetsisMarketplace.Models.Trendyol;

namespace SetsisMarketplace.Class
{
    public class DataService2
    {
        IDbConnection db;

        IDbTransaction transaction;
        DynamicParameters param;

        public DataService2()
        {
            db = new SqlConnection("Data Source=10.20.8.5,1529;Initial Catalog=Abaci_Giyim; User Id=ugur;Password=Ugr1214;");
            param = new DynamicParameters();
        }


        #region Function

        protected void ConnState()
        {
            if (db.State == ConnectionState.Closed)
                db.Open();
        }

        public void CloseConn()
        {
            if (db.State == ConnectionState.Open)
            {
                db.Close();
            }
        }

        public void BeginTransaction()
        {
            ConnState();

            transaction = db.BeginTransaction();
        }

        private IDbTransaction IfHaveTransactionReturn()
        {
            if (transaction != null)
                return transaction;
            else
                return null;
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            transaction = null;
        }

        public void RollBackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }

        }

        #endregion Function

        #region DynamicObject
        public void AddParameter(string variable, object data)
        {
            AddParameter(variable, data, DbType.String);
        }

        public void AddParameter(string variable, object data, DbType dbType)
        {
            AddParameter(variable, data, dbType, ParameterDirection.Input);
        }

        public void AddParameter(string variable, object data, DbType dbType, ParameterDirection parameterDirection)
        {
            param.Add(variable, data, dbType, parameterDirection);
        }

        public void DataCommit(string query)
        {
            DataCommit(query, CommandType.Text);
        }

        public void DataCommit(string query, CommandType cmdType)
        {
            ConnState();

            if (param.ParameterNames.Count() > 0) DataCommitWithParam(query, cmdType);
            else DataCommiNottWithParam(query, cmdType);

            CloseConn();

            param = new DynamicParameters();
        }

        private void DataCommiNottWithParam(string query, CommandType cmdType)
        {

            db.Execute(query, commandType: cmdType, transaction: IfHaveTransactionReturn());

        }

        private void DataCommitWithParam(string query, CommandType cmdType)
        {
            db.Execute(query, param, commandType: cmdType, transaction: IfHaveTransactionReturn());
        }

        public IDataReader GetDataReader(string query)
        {
            return GetDataReader(query, CommandType.Text);
        }
  
        public IDataReader GetDataReader(string query, CommandType cmdType)
        {
            ConnState();

            IDataReader dr;

            if (param.ParameterNames.Count() > 0) dr = GetDataReaderWithParam(query, cmdType);
            else dr = GetDataReaderNotWithParam(query, cmdType);

            param = new DynamicParameters();

            return dr;
        }

        private IDataReader GetDataReaderNotWithParam(string query, CommandType cmdType)
        {
            return db.ExecuteReader(query, commandType: cmdType);
        }

        private IDataReader GetDataReaderWithParam(string query, CommandType cmdType)
        {
            return db.ExecuteReader(query, param, commandType: cmdType);
        }

        public object ReturnScalerData(string query)
        {
            return ReturnScalerData(query, CommandType.Text);
        }

        public object ReturnScalerData(string query, CommandType cmdType)
        {
            object obj;
            ConnState();

            if (param.ParameterNames.Count() > 0) obj = ReturnScalerDataWithParam(query, cmdType);
            else obj = ReturnScalerDataNotWithParam(query, cmdType);

            param = new DynamicParameters();
            CloseConn();
            return obj;
        }

        private object ReturnScalerDataNotWithParam(string query, CommandType cmdType)
        {
            return db.ExecuteScalar(query, commandType: cmdType, transaction: IfHaveTransactionReturn());
        }

        private object ReturnScalerDataWithParam(string query, CommandType cmdType)
        {
            return db.ExecuteScalar(query, param, commandType: cmdType, transaction: IfHaveTransactionReturn());
        }

        public bool ReturnBoolData(string query)
        {
            return db.ExecuteScalar<bool>(query);
        }

        public LoginModel GetLogin()
        {
            ConnState();

            return db.QueryFirstOrDefault<LoginModel>("SELECT * FROM Users", param);

        }

        public string execValue(string query)
        {
            ConnState();
            string exc = ReturnScalerData(query).ToString();
            CloseConn();
            return exc;
        }

        public List<HierarchyModel> GetHirarchy()
        {
            ConnState();

            return db.Query<HierarchyModel>("SELECT * FROM ProductHierarchy('TR')", param).ToList();
        }
     
        public List<CompanyModel> GetCompany()
        {
            ConnState();

            return db.Query<CompanyModel>("SELECT * FROM cdCompany", param).ToList();
        }
        public List<OfficeModel> GetOffice(string CompanyCode)
        {
            ConnState();

            return db.Query<OfficeModel>("SELECT * FROM cdOffice Where CompanyCode="+CompanyCode.ToString(), param).ToList();
        }
        public List<WarehouseModel> GetWarehouse(string OfficeCode)
        {
            ConnState();

            return db.Query<WarehouseModel>("SELECT * FROM cdWarehouse Where OfficeCode='" + OfficeCode.ToString()+"'", param).ToList();
        }

        public List<TYTEST> TYGetStockCards()

        {
            ConnState();

            return db.Query<TYTEST>("SELECT * FROM SetsisVwPUrun ", param).ToList();

        }
    }
}

#endregion