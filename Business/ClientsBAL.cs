using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Entity;
using System.Data;
namespace Business
{
    public class ClientsBAL
    {
        ClientsDAL objClientsDAL = new ClientsDAL();
        public bool UpdateClients(Clients objClients)
        {
            int ClientsId = objClients.ClientId;
            bool result = false;
            try
            {
                objClientsDAL = new ClientsDAL(objClients);
                result = objClientsDAL.update(ClientsDAL.eLoadSp.UpdateClients);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return result;
        }
        public bool DeleteByIdClients(Clients objClients)
        {
            bool result = false;
            try
            {
                objClientsDAL = new ClientsDAL(objClients);
                result = objClientsDAL.delete(ClientsDAL.eLoadSp.DeleteByIdClients);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return result;
        }
        public int InsertClients(Clients objClients)
        {
            bool result = false;
            int Id = 0;
            try
            {
                objClientsDAL = new ClientsDAL(objClients);
                result = objClientsDAL.insert(ClientsDAL.eLoadSp.InsertClients, out Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return Id;
        }
        public DataSet GetAllClients()
        {
            DataSet ds = new DataSet();
            try
            {
                objClientsDAL = new ClientsDAL();
                objClientsDAL.load(ClientsDAL.eLoadSp.GetAllClients, ref ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return ds;
        }
        public DataSet GetByIdClients(Clients objClients)
        {
            DataSet ds = new DataSet();
            try
            {
                objClientsDAL = new ClientsDAL(objClients);
                objClientsDAL.load(ClientsDAL.eLoadSp.GetByIdClients, ref ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return ds;
        }

        public DataSet GetAllState()
        {
            DataSet ds = new DataSet();
            try
            {
                objClientsDAL = new ClientsDAL();
                objClientsDAL.load(ClientsDAL.eLoadSp.GetAllState, ref ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return ds;
        }
        public DataSet GetByStateIdCity(Clients objClients)
        {
            DataSet ds = new DataSet();
            try
            {
                objClientsDAL = new ClientsDAL(objClients);
                objClientsDAL.load(ClientsDAL.eLoadSp.GetByStateIdCity, ref ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objClientsDAL = null;
            }
            return ds;
        }
    }
}