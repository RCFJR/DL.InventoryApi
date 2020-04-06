using System.Collections.Generic;
using System.Data;
using DbBase;
using DL.Core.DAL;
using DL.Core.Model;

namespace DL.Core.Data
{
    ////////////////////////////////////////////
    //////// Codigo Gerado  ////////////////////
    ////////////////////////////////////////////
    public class LogBase
    {
        #region Constructor
        public LogBase()
        {

        }
        #endregion

        #region Methods
        public IList<Log> Get()
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(new Log()); 
            IList<Log> response = ConMySqlDAL<Log>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public IList<Log> Get(Log log)
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(log);
            IList<Log> response = ConMySqlDAL<Log>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public void Create(Log log)
        {
            string dbBase = DbBase.DbBase.GetInstance().Insert(log);
            ConMySqlDAL<Log>.Instance.ExecuteSQL(dbBase);
        }

        public void Update(Log log)
        {
            string dbBase = DbBase.DbBase.GetInstance().Update(log);
            ConMySqlDAL<Log>.Instance.ExecuteSQL(dbBase);
        }

        public void Delete(Log log)
        {
            string dbBase = DbBase.DbBase.GetInstance().Delete(log);
            ConMySqlDAL<Log>.Instance.ExecuteSQL(dbBase);
        }
		
        #endregion

    }
}
            