using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DataAccess
{
    public class ClientsDAL : BOBase
    {
        Clients obj = new Clients();
        #region Enums
        public enum eLoadSp
        {
            DeleteByIdClients,
            GetAllClients,
            GetByIdClients,
            InsertClients,
            UpdateClients,
            GetAllState,
            GetByStateIdCity
        };
        #endregion
        #region Constructors
        public ClientsDAL()
        { }
        public ClientsDAL(Clients objClients)
        {
            this.obj = objClients;
        }
        #endregion
        #region method
        public string getSpName(eLoadSp enumSPType)
        {
            switch (enumSPType)
            {
                case eLoadSp.DeleteByIdClients:
                    return "DeleteByIdClients";
                case eLoadSp.GetAllClients:
                    return "GetAllClients";
                case eLoadSp.GetByIdClients:
                    return "GetByIdClients";
                case eLoadSp.InsertClients:
                    return "InsertClients";
                case eLoadSp.UpdateClients:
                    return "UpdateClients";
                case eLoadSp.GetAllState:
                    return "GetAllState";
                case eLoadSp.GetByStateIdCity:
                    return "GetByStateIdCity";
                default:
                    return string.Empty;
            }
        }
        #endregion
        #region method
        public SqlParameter[] getSpParam(eLoadSp enumSPType)
        {
            SqlParameter[] colsParam = new SqlParameter[] { };
            switch (enumSPType)
            {
                case eLoadSp.DeleteByIdClients:
                    colsParam = new SqlParameter[] 
		           {
		               new SqlParameter("@ClientId",obj.ClientId),
		           };
                    break;
                case eLoadSp.GetAllClients:
                    colsParam = new SqlParameter[] 
		           {
		           };
                    break;
                case eLoadSp.GetByIdClients:
                    colsParam = new SqlParameter[] 
		           {
		               new SqlParameter("@ClientId",obj.ClientId),
		           };
                    break;
                case eLoadSp.InsertClients:
                    colsParam = new SqlParameter[] 
		           {
		               new SqlParameter("@BusinessName",obj.BusinessName),
		               new SqlParameter("@FirstName",obj.FirstName),
		               new SqlParameter("@LastName",obj.LastName),
		               new SqlParameter("@Mobile",obj.Mobile),
		               new SqlParameter("@Phone",obj.Phone),
		               new SqlParameter("@FaxNo",obj.FaxNo),
		               new SqlParameter("@Email",obj.Email),
		               new SqlParameter("@ClientPassword",obj.ClientPassword),
		               new SqlParameter("@Website",obj.Website),
		               new SqlParameter("@Logo",obj.Logo),
		               new SqlParameter("@StateId",obj.StateId),
		               new SqlParameter("@CityId",obj.CityId),
		               new SqlParameter("@Area",obj.Area),
		               new SqlParameter("@Pincode",obj.Pincode),
		               new SqlParameter("@Address1",obj.Address1),
		               new SqlParameter("@Address2",obj.Address2),
		           };
                    break;
                case eLoadSp.UpdateClients:
                    colsParam = new SqlParameter[] 
		           {
		               new SqlParameter("@ClientId",obj.ClientId),
		               new SqlParameter("@BusinessName",obj.BusinessName),
		               new SqlParameter("@FirstName",obj.FirstName),
		               new SqlParameter("@LastName",obj.LastName),
		               new SqlParameter("@Mobile",obj.Mobile),
		               new SqlParameter("@Phone",obj.Phone),
		               new SqlParameter("@FaxNo",obj.FaxNo),
		               new SqlParameter("@Email",obj.Email),
		               new SqlParameter("@ClientPassword",obj.ClientPassword),
		               new SqlParameter("@Website",obj.Website),
		               new SqlParameter("@Logo",obj.Logo),
		               new SqlParameter("@StateId",obj.StateId),
		               new SqlParameter("@CityId",obj.CityId),
		               new SqlParameter("@Area",obj.Area),
		               new SqlParameter("@Pincode",obj.Pincode),
		               new SqlParameter("@Address1",obj.Address1),
		               new SqlParameter("@Address2",obj.Address2),
		           };
                    break;
                case eLoadSp.GetAllState:
                    colsParam = new SqlParameter[] 
		           {
		               
		           };
                    break;
                case eLoadSp.GetByStateIdCity:
                    colsParam = new SqlParameter[] 
		           {
		               new SqlParameter("@StateId",obj.StateId),
		           };
                    break;
                default:
                    colsParam = null;
                    break;
            }
            return colsParam;
        }
        #endregion
        #region method
        public bool load(eLoadSp enumSPType, ref DataSet ds)
        {
            return base.load(getSpName(enumSPType), getSpParam(enumSPType), ref ds);
        }
        public bool load(SqlTransaction sqlTrans, eLoadSp enumSPType, ref DataSet ds)
        {
            return base.load(sqlTrans, getSpName(enumSPType), getSpParam(enumSPType), ref ds);
        }
        public bool insert(SqlTransaction sqlTrans, eLoadSp enumSPType, out int intReturnValue)
        {
            return base.insert(getSpName(enumSPType), getSpParam(enumSPType), sqlTrans, out intReturnValue);
        }
        public bool insert(eLoadSp enumSPType, out int intReturnValue)
        {
            return base.insert(getSpName(enumSPType), getSpParam(enumSPType), out intReturnValue);
        }
        public bool update(SqlTransaction sqlTrans, eLoadSp enumSPType)
        {
            return base.Update(getSpName(enumSPType), getSpParam(enumSPType), sqlTrans);
        }
        public bool update(eLoadSp enumSPType)
        {
            return base.Update(getSpName(enumSPType), getSpParam(enumSPType));
        }
        public bool delete(SqlTransaction sqlTrans, eLoadSp enumSPType)
        {
            return base.Delete(getSpName(enumSPType), getSpParam(enumSPType), sqlTrans);
        }
        public bool delete(eLoadSp enumSPType)
        {
            return base.Delete(getSpName(enumSPType), getSpParam(enumSPType));
        }
        #endregion
    }
}