using System.Collections.Generic;
using DL.Inventory.Core.Model;
using System.Data;
using DL.Inventory.Core.DAL;
using DbBase;

namespace DL.Inventory.Core.Data
{
    ////////////////////////////////////////////
    //////// Codigo Gerado - Vexia Sistemas ////
    ////////////////////////////////////////////
    public class UserBase
    {
        #region Constructor
        public UserBase()
        {

        }
        #endregion

        #region Methods
        public IList<User> Get()
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(new User()); 
            IList<User> response = ConMySqlDAL<User>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public IList<User> Get(User user)
        {
            string dbBase = DbBase.DbBase.GetInstance().GetAll(user);
            IList<User> response = ConMySqlDAL<User>.Instance.ExecuteSQL(dbBase);
            return response;
        }

        public void Create(User user)
        {
            string dbBase = DbBase.DbBase.GetInstance().Insert(user);
            ConMySqlDAL<User>.Instance.ExecuteSQL(dbBase);
        }

        public void Update(User user)
        {
            string dbBase = DbBase.DbBase.GetInstance().Update(user);
            ConMySqlDAL<User>.Instance.ExecuteSQL(dbBase);
        }

        public void Delete(User user)
        {
            string dbBase = DbBase.DbBase.GetInstance().Delete(user);
            ConMySqlDAL<User>.Instance.ExecuteSQL(dbBase);
        }
		
        #endregion

    }
}
            