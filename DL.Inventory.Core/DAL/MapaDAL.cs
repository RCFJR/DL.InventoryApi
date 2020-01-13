using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;

namespace DL.Inventory.Core.DAL
{
    public static class MapaDAL<T> where T : new()
    {
        public static List<T> MapReader(IDataReader dr)
        {
            List<T> retorno = new List<T>();

            while (dr.Read())
            {
                T linha = MapRecord(dr);
                retorno.Add(linha);
            }

            return retorno;
        }

        public static T MapRecord(IDataRecord dr)
        {
            T retornoObj = new T();
            PropertyInfo[] propriedadesObj = retornoObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, int> dicNomeColunaObj = ObterNomeColunas(dr);

            foreach (var prop in propriedadesObj)
            {

                var att = prop.GetCustomAttributes(true);

                if (att.GetLength(0) <= 0)
                    continue;

                for (int i = 0; i < att.Length; i++)
                {
                    if (att[i].GetType().Name != "_MapperTO")
                        continue;

                    string nomeColuna = Convert.ToString(att[i].GetType().GetProperty("Coluna").GetValue(att[i], null));
                    string valorString = "";

                    
                    var colunaObj = dicNomeColunaObj.SingleOrDefault(p => p.Key.ToUpper() == nomeColuna.ToUpper());
                    object valor = null;
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(colunaObj.Key))
                            if (dr[nomeColuna] != DBNull.Value)
                            {
                                if (prop.PropertyType.Name == "Byte[]")
                                {
                                    Byte[] buffer = new Byte[(dr.GetBytes(colunaObj.Value, 0, null, 0, int.MaxValue))];
                                    var bytes = dr.GetBytes(colunaObj.Value, 0, buffer, 0, buffer.Length);
                                    valor = buffer;
                                }
                                else
                                {
                                    valorString = dr[nomeColuna].ToString();
                                    valor = Convert.ChangeType(dr[nomeColuna].ToString(), prop.PropertyType);
                                }
                                prop.SetValue(retornoObj, valor, null);
                            }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("NomeColuna:" + nomeColuna + "-  Valor:" + Convert.ToString(valor), ex);
                    }
                }
            }
            return retornoObj;
        }

        private static Dictionary<string, int> ObterNomeColunas(IDataRecord record)
        {
            var retornoObj = new Dictionary<string, int>();
            for (int i = 0; i < record.FieldCount; i++)
                retornoObj.Add(record.GetName(i), i);
            return retornoObj;
        }

    }
}
