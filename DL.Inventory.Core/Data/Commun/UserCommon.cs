using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Core.Data
{
    public class UserCommon : UserBase
    {
        #region Singleton

        private static UserCommon _instance = null;

        public UserCommon()
        {
        }

        public static UserCommon GetInstance()
        {
            if (_instance == null)
                _instance = new UserCommon();

            return _instance;
        }
        #endregion
    }
}
