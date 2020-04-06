using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using DL.Core.Model;

namespace DL.Core.DAL
{
    public class ConSqlServerDAL<T> : BaseDAL<T> where T : new()
    {
        static ConSqlServerDAL<T> _instanceObj;

        public static ConSqlServerDAL<T> Instance
        {
            get
            {
                if (_instanceObj == null)
                    _instanceObj = new ConSqlServerDAL<T>();
                return _instanceObj;
            }
        }

        public override IDbConnection GetConnection()
        {
            string conn = GetConnectionString();
            SqlConnection connObj = new SqlConnection(conn);
            return connObj;
        }

        public IList<T> ExecuteSQL(string sql)
        {
            SqlCommand command;
            IList<T> retornoObj = null;

            var connObj = GetConnection();

            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();

                command = new SqlCommand(sql, (SqlConnection)connObj);

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

        public DataSet ExecuteSQL2(string query)
        {
            DataSet ds = new DataSet();
            SqlDataReader retornoBanco;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = GetConnectionString();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds);

                //foreach(Tables table in ds )
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            //var retorno;
            //IList<ExempleTO> list = new IList<ExempleTO>();
            //return new IList<ExempleTO>();
            return ds;
        }

        public IList<T> Teste2(string sql)
        {
            IList<T> retornoObj = null;
            SqlConnection sqlConnection1 = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            
            if (reader.Read())
            {
                var retornoBancoMapeado = MapaDAL<T>.MapReader(reader);

                retornoObj = retornoBancoMapeado;
            }

            sqlConnection1.Close();
            
            

            return retornoObj;
        }


    }

}
