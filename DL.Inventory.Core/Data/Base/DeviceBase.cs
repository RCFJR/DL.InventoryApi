using System.Collections.Generic;
using DL.Core.Model;
using System.Data;
using DL.Core.DAL;
using DbBase;

namespace DL.Core
{
    ////////////////////////////////////////////
    //////// Codigo Gerado  ////////////////////
    ////////////////////////////////////////////
    public class DeviceBase
    {
        #region Constructor
        public DeviceBase()
        {

        }
        #endregion

        #region Methods
        public IList<Device> Get()
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(new Device()); 
            IList<Device> response = ConMySqlDAL<Device>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public IList<Device> Get(Device device)
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(device);
            IList<Device> response = ConMySqlDAL<Device>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public void Create(Device device)
        {
            string dbBase = DbBase.DbBase.GetInstance().Insert(device);
            ConMySqlDAL<Device>.Instance.ExecuteSQL(dbBase);
        }

        public void Update(Device device)
        {
            string dbBase = DbBase.DbBase.GetInstance().Update(device);
            ConMySqlDAL<Device>.Instance.ExecuteSQL(dbBase);
        }

        public void Delete(Device device)
        {
            string dbBase = DbBase.DbBase.GetInstance().Delete(device);
            ConMySqlDAL<Device>.Instance.ExecuteSQL(dbBase);
        }
		
        #endregion

    }
}
            