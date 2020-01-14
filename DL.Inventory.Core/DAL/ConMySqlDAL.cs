using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using DL.Inventory.Core.Model;
using DL.Inventory.Core.Common;

namespace DL.Inventory.Core.DAL
{
    public class ConMySqlDAL<T> : BaseDAL<T> where T : new()
    {
        static ConMySqlDAL<T> _instanceObj;

        public static ConMySqlDAL<T> Instance
        {
            get
            {
                if (_instanceObj == null)
                    _instanceObj = new ConMySqlDAL<T>();
                return _instanceObj;
            }
        }

        public override IDbConnection GetConnection()
        {
            string conn = GetConnectionString();
            MySqlConnection connObj = new MySqlConnection(conn);
            return connObj;
        }

        public IList<T> ExecuteSQL(string sql)
        {
            MySqlCommand command;
            IList<T> retornoObj = null;

            var connObj = GetConnection();

            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();

                command = new MySqlCommand(sql, (MySqlConnection)connObj);

                var retornoBanco = command.ExecuteReader();

                var retornoBancoMapeado = MapaDAL<T>.MapReader(retornoBanco);

                retornoObj = retornoBancoMapeado;
            }
            catch
            {

            }
            finally
            {
                if ((connObj.State != ConnectionState.Broken) || (connObj.State != ConnectionState.Closed))
                    connObj.Close();
            }
            return retornoObj;
        }
    }
}
