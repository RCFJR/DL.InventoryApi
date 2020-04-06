using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Core.Data
{
    public class DeviceCommon : DeviceBase
    {
        #region Singleton

        private static DeviceCommon _instance = null;

        public DeviceCommon()
        {
        }

        public static DeviceCommon GetInstance()
        {
            if (_instance == null)
                _instance = new DeviceCommon();

            return _instance;
        }
        #endregion
    }
}
