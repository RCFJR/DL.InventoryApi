using DL.Inventory.Core.Data;
using DL.Inventory.Core.Model;
using DL.Inventory.Core.Util;
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
        public HttpResponseMessage Verifydevice(Device device)
        {
            try
            {
                Device _device = DeviceCommon.GetInstance().Get(new Device() { token = device.token }).FirstOrDefault();
                if (_device != null)
                {
                    User _user = UserCommon.GetInstance().Get(new Inventory.Core.Model.User() { id_user = _device.user_id }).FirstOrDefault();
                    var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.OK, _user);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "usuário inexistente");
                    return response;
                }
            }
            catch
            {
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, "error");
                return response;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Encrypt(string password)
        {
            try
            {
                string _hash = Cripto.GetHash(password);
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, _hash);
                return response;
            }
            catch
            {
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, "error");
                return response;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage ResetPassword(User user)
        {
            try
            {
                User _user = UserCommon.GetInstance().Get(user).FirstOrDefault();
                string _newPassword = Password.Create();
                _user.password = Cripto.GetHash(_newPassword);

                UserCommon.GetInstance().Update(_user);
                // Envia nova senha por e-mail
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Uma nova senha foi encaminhada por e-mail");
                return response;
            }
            catch
            {
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, "error");
                return response;
            }

        }

    }
}
