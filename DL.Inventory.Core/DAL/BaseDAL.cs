using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using DL.Core.Common;

namespace DL.Core.DAL
{
    public abstract class BaseDAL<T> where T : new()
    {

        // Retorna String de Conexão com Banco de Dados
        protected string GetConnectionString()
        {
            var ConnectionString = LeitorConfig.Parametro("conSQL");
            return ConnectionString;
        }

        protected string GetConnectionStringOracle()
        {
            var ConnectionString = LeitorConfig.Parametro("conOra");
            return ConnectionString;
        }

        private IDbCommand GetCommand(IDbConnection pConexao, string pComando)
        {
            IDbCommand cmdRetornoObj = null;
            cmdRetornoObj = pConexao.CreateCommand();
            cmdRetornoObj.Connection = pConexao;
            cmdRetornoObj.CommandText = pComando;
            //cmdRetornoObj.CommandType = pTipoComando;
            /*
            foreach (IDbDataParameter paramObj in pParametros)
                cmdRetornoObj.Parameters.Add(paramObj);
            */
            return cmdRetornoObj;
        }

        public abstract IDbConnection GetConnection();

        public IList<T> ExecuteReader(string pComando)
        {
            IDbCommand cmdObj = null;
            IList<T> retornoObj = null;

            var connObj = GetConnection();

            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();
                
                cmdObj = GetCommand(connObj, pComando);

                var retornoBanco = cmdObj.ExecuteReader();

                var retornoBancoMapeado = MapaDAL<T>.MapReader(retornoBanco);

                retornoObj = retornoBancoMapeado;
                

            }
            catch (Exception e)
            {
                //Logger.GetInstance().Erro(e);
            }
            finally
            {
                if ((connObj.State != ConnectionState.Broken) || (connObj.State != ConnectionState.Closed))
                    connObj.Close();
            }
            return retornoObj;
        }

        public T ExecuteReaderSingle(string pComando, CommandType pTipoComando, List<IDbDataParameter> pParametros)
        {
            T retornoObj = default(T);

            IDbCommand cmdObj = null;
            var connObj = GetConnection();
            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();

                cmdObj = GetCommand(connObj, pComando);

                var dr = cmdObj.ExecuteReader();
                if (dr.Read())
                    retornoObj = MapaDAL<T>.MapRecord(dr);

            }
            catch (Exception e)
            {
                //Logger.GetInstance().Erro(e);
            }
            finally
            {
                if ((connObj.State != ConnectionState.Broken) || (connObj.State != ConnectionState.Closed))
                    connObj.Close();
            }

            return retornoObj;
        }

        public int ExecuteNonQuery(string pComando, CommandType pTipoComando, List<IDbDataParameter> pParametros)
        {
            IDbCommand cmdObj = null;
            var connObj = GetConnection();

            int retornoObj = int.MinValue;
            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();

                cmdObj = GetCommand(connObj, pComando);

                retornoObj = cmdObj.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Logger.GetInstance().Erro(e);
            }
            finally
            {
                if ((connObj.State != ConnectionState.Broken) || (connObj.State != ConnectionState.Closed))
                    connObj.Close();
            }
            return retornoObj;
        }

        protected int ExecuteScalar(string pComando, CommandType pTipoComando, List<IDbDataParameter> pParametros)
        {
            IDbCommand cmdObj = null;
            int retornoObj = int.MinValue;
            var connObj = GetConnection();
            try
            {
                if (connObj.State != ConnectionState.Open)
                    connObj.Open();

                cmdObj = GetCommand(connObj, pComando);

                retornoObj = Convert.ToInt32(cmdObj.ExecuteScalar());
            }
            catch (Exception ex)
            {
                //Logger.GetInstance().Erro(ex);
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
