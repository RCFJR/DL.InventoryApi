using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Core.Data
{
    public class LogCommon : LogBase
    {
        #region Singleton

        private static LogCommon _instance = null;

        public LogCommon()
        {
        }

        public static LogCommon GetInstance()
        {
            if (_instance == null)
                _instance = new LogCommon();

            return _instance;
        }
        #endregion
    }
}
