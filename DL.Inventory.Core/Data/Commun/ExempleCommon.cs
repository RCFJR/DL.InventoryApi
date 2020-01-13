using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Inventory.Core.Data
{
    public class ExempleCommon : ExempleBase
    {
        #region Singleton

        private static ExempleCommon _instance = null;

        public ExempleCommon()
        {
        }

        public static ExempleCommon GetInstance()
        {
            if (_instance == null)
                _instance = new ExempleCommon();

            return _instance;
        }
        #endregion
    }
}
