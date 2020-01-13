using System;
using System.Collections.Generic;
using System.IO;

namespace DL.Inventory.Core.Common
{
    public class LogFile
    {
		/*Versão 2.0
			Log alterado para (Mensagem, Linhas ou 0 por padrão)
			Atualização das Funções
		*/
		
        #region Singleton

        private static LogFile _instance = null;

        // Construtor padrão
        public LogFile(){ }

        public static LogFile GetInstance()
        {
            if (_instance == null)
                _instance = new LogFile();
            return _instance;
        }

        #endregion

        public void Log(string Mensagem, int PularLinha = 0)
        {
            string Path;

            if (Server()) Path = System.Web.HttpContext.Current.Server.MapPath("LogFile");
            else Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LogFile";
            
            Directory.CreateDirectory(Path);

            Path = Path + "\\";

            for (int i = 0; i <= PularLinha; i++)
            {
                File.AppendAllText(Path + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", Environment.NewLine);
            }

            File.AppendAllText(Path + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", DateTime.Now.ToString("HH:mm:ss") + " - " + Mensagem);
        }

        public void Log(Exception ex)
        {
            String[] exSplit = ex.StackTrace.Split(new string[] {" em "}, StringSplitOptions.RemoveEmptyEntries);
            Log(ex.Message + Environment.NewLine + "\t" + exSplit[exSplit.Length-1], 1);
        }

        public void Start()
        {
            Log("---------------------Processo Iniciado--------------------------", 2);
        }

        public void End()
        {
            Log("---------------------Processo Finalizado------------------------", 1);
        }

        private bool Server()
        {
            bool http = false;
            try
            {
                System.Web.HttpApplicationState verifyHttp = System.Web.HttpContext.Current.Application;
                if (verifyHttp != null)
                    http = true;
                else
                    http = false;
            }
            catch
            {
                http = false;
            }
            return http;
        }

    }
}
