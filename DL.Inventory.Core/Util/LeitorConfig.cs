using System;
using System.Configuration;

namespace DL.Core.Common
{
    /* Classe padrão para coletar parâmetros fixos
     * dentro do arquivo Web.Config */
    public static class LeitorConfig
    {
        /* Método para encontrar parâmetros fixo */
        public static string Parametro(string pEntrada)
        {
            string retorno = string.Empty;

            if (ConfigurationManager.AppSettings[pEntrada] != null)
                retorno = ConfigurationManager.AppSettings[pEntrada];
            else
                throw new Exception("Parâmetro não encontrado no arquivo de configuração");
            return retorno;
        }
    }
}
