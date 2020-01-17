using DL.Inventory.Core.Data;
using DL.Inventory.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DL.InventoryApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public IEnumerable<Device> Verifydevice(string token)
        {
            return DeviceCommon.GetInstance().Get(new Device() { token = token });
        }

        [HttpPost]
        [AllowAnonymous]
        public User Authenticateuser(string token, string userkey)
        {
            if (AutheticateByFaceId(userkey))
            {
                User _user = UserCommon.GetInstance().Get(new User() { faceid = userkey }).FirstOrDefault();
                Device _device = DeviceCommon.GetInstance().Get(new Device() { token = token, active = "1", user_id = _user.id_user }).FirstOrDefault();
                if (_device != null)
                {
                    return _user;
                }
                else
                {
                    return null;
                }
            }
            else if (AutheticateByTouchId(userkey))
            {
                User _user = UserCommon.GetInstance().Get(new User() { touchid = userkey }).FirstOrDefault();
                Device _device = DeviceCommon.GetInstance().Get(new Device() { token = token, active = "1", user_id = _user.id_user }).FirstOrDefault();
                if (_device != null)
                {
                    return _user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private bool AutheticateByFaceId(string faceid)
        {
            if (UserCommon.GetInstance().Get(new User() { faceid = faceid }).FirstOrDefault() != null)
                return true;
            else
                return false;
        }

        private bool AutheticateByTouchId(string touchid)
        {
            if (UserCommon.GetInstance().Get(new User() { touchid = touchid }).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
    }
}
