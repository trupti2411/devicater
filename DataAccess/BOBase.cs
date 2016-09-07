using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using DbHelper;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;


namespace DataAccess
{
    /// <summary>
    /// Business object base class for all other classess to inherit from.
    /// </summary>
    public class BOBase
    {
        #region Class Lavel Variables

        private string strConnString;
        private SqlConnection objSqlConn;
        private SqlTransaction objSqlTran;
        private bool blnValidateRowsAffected = true;

        #endregion

        #region Properties

        public SqlConnection SqlConn
        {
            get { return objSqlConn; }
            set { objSqlConn = value; }
        }

        public bool ValidateRowsAffected
        {
            get { return blnValidateRowsAffected; }
            set { blnValidateRowsAffected = value; }
        }

        #endregion

        #region Constructors

        public BOBase()
        {

        }

        #endregion



        #region Methods

        #region Public Methods

        /// <summary>
        /// Loads the data based on selected Stored procedure and/or SQL parameters specified
        /// </summary>
        /// <param name="strSpName">SQL SP used to fetch the records</param>
        /// <param name="colParams">The parameter collection for fetching the data</param>
        /// <param name="ds">Return filled dataset</param>
        /// <returns>True if successfully executed else false</returns>

        public bool load(string strSpName, SqlParameter[] colParams, ref DataSet ds)
        {
            try
            {
                OpenDBConnection();

                if (colParams == null)
                {
                    ds = clsDbHelper.ExecuteDataset(objSqlConn, CommandType.StoredProcedure, strSpName);
                }

                else
                {
                    ds = clsDbHelper.ExecuteDataset(objSqlConn, CommandType.StoredProcedure, strSpName, colParams);
                }

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                CloseDBConnection();
            }
        }


        /// <summary>
        /// Loads the data based on selected Stored procedure and/or SQL parameters specified
        /// </summary>
        /// <param name="sqlTrans">Pass SQL Transaction object</param>
        /// <param name="strSpName">SQL SP used to fetch the records</param>
        /// <param name="colParams">The parameter collection for fetching the data</param>
        /// <param name="ds">Return filled dataset</param>
        /// <returns>True if successfully executed else false</returns>
        public bool load(SqlTransaction sqlTrans, string strSpName, SqlParameter[] colParams, ref DataSet ds)
        {
            try
            {
                if (sqlTrans == null)
                {
                    return false;
                }
                if (colParams == null)
                {
                    ds = clsDbHelper.ExecuteDataset(sqlTrans, CommandType.StoredProcedure, strSpName);
                }
                else
                {
                    ds = clsDbHelper.ExecuteDataset(sqlTrans, CommandType.StoredProcedure, strSpName, colParams);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts the data based on selected Stored procedure and/or SQL parameters specified
        /// </summary>
        /// <param name="strSpName">SQL SP used to fetch the records</param>
        /// <param name="intReturnValue">The primary key of the record inserted</param>
        /// <param name="colParams">The parameter collection for fetching the data</param>
        /// <param name="sqlTrans">The transaction object to be used</param>
        /// <returns>True if successfully executed else false</returns>
        public bool insert(string strSpName, SqlParameter[] colParams, SqlTransaction sqlTrans, out int intReturnValue)
        {
            intReturnValue = 0;
            try
            {
                if (sqlTrans == null)
                {
                    OpenDBConnection();
                    objSqlTran = objSqlConn.BeginTransaction();
                }
                else
                {
                    objSqlTran = sqlTrans;
                }
                if (colParams == null)
                {
                    intReturnValue = Convert.ToInt32(clsDbHelper.ExecuteScalar(objSqlTran, CommandType.StoredProcedure, strSpName));
                }
                else
                {
                    intReturnValue = Convert.ToInt32(clsDbHelper.ExecuteScalar(objSqlTran, CommandType.StoredProcedure, strSpName, colParams));
                }

                if (intReturnValue < 1)
                {
                    if (sqlTrans == null)
                        objSqlTran.Rollback();
                    return false;
                }
                if (sqlTrans == null)
                    objSqlTran.Commit();
                return true;
            }
            catch (System.Exception ex)
            {
                if (sqlTrans == null)
                {
                    objSqlTran.Rollback();
                    if (ex.Message.ToString().IndexOf("category_name") != -1)
                        throw new Exception("Category name already exists.");             
                }
                return false;
            }
            finally
            {
                if (sqlTrans == null)
                {
                    CloseDBConnection();
                    objSqlTran = null;
                }
            }

        }


        /// <summary>
        /// Inserts the data based on selected Stored procedure and/or SQL parameters specified
        /// </summary>
        /// <param name="strSpName">SQL SP used to fetch the records</param>
        /// <param name="colParams">The parameter collection for fetching the data</param>
        /// <param name="intReturnValue">The primary key of the record inserted</param>
        /// <returns>True if successfully executed else false</returns>
        public bool insert(string strSpName, SqlParameter[] colParams, out int intReturnValue)
        {
            return insert(strSpName, colParams, null, out intReturnValue);
        }

        public bool Update(string strSpName, SqlParameter[] colParams, SqlTransaction sqlTrans)
        {
            try
            {
                int intReturnValue;
                if (sqlTrans == null)
                {
                    OpenDBConnection();
                    objSqlTran = objSqlConn.BeginTransaction();
                }
                else
                {
                    objSqlTran = sqlTrans;
                }

                if (colParams == null)
                {
                    intReturnValue = Convert.ToInt32(clsDbHelper.ExecuteNonQuery(objSqlTran, CommandType.StoredProcedure, strSpName));
                }
                else
                {
                    intReturnValue = Convert.ToInt32(clsDbHelper.ExecuteNonQuery(objSqlTran, CommandType.StoredProcedure, strSpName, colParams));
                }

                if (this.ValidateRowsAffected == true && intReturnValue < 1)
                {
                    if (sqlTrans == null)
                        objSqlTran.Rollback();
                    return false;
                }
                if (sqlTrans == null)
                    objSqlTran.Commit();
                return true;
            }
            catch (System.Exception ex)
            {
                if (sqlTrans == null)
                    objSqlTran.Rollback();
                return false;
            }
            finally
            {
                if (sqlTrans == null)
                {
                    CloseDBConnection();
                    objSqlTran = null;
                }
            }
        }

        public bool Update(string strSpName, SqlParameter[] colParams)
        {
            return Update(strSpName, colParams, null);
        }

        public bool Delete(string strSpName, SqlParameter[] colParams)
        {
            return Update(strSpName, colParams, null);
        }

        public bool Delete(string strSpName, SqlParameter[] colParams, SqlTransaction sqlTrans)
        {
            return Update(strSpName, colParams, sqlTrans);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Opens DB connection
        /// </summary>
        private void OpenDBConnection()
        {
            try
            {
                if (objSqlConn == null)
                {
                    strConnString = ConfigurationManager.ConnectionStrings["iCaterCon"].ToString();
                    objSqlConn = new SqlConnection(strConnString);
                }
                if (objSqlConn.State != ConnectionState.Open)
                {
                    objSqlConn.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Closes the DB connection
        /// </summary>
        private void CloseDBConnection()
        {
            if (objSqlConn != null)
            {
                if (objSqlConn.State == ConnectionState.Open)
                {
                    objSqlConn.Close();
                }
                objSqlConn.Dispose();
                objSqlConn = null;
            }
        }

        #endregion

        #endregion

    }
}