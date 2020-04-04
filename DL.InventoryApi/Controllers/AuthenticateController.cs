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
        public HttpResponseMessage Encrypt(User user)
        {
            try
            {
                string _hash = Cripto.GetHash(user.password);
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
                if(!_user.blocked.Equals("SIM"))
                {
                    string _newPassword = Password.Create();
                    _user.password = Cripto.GetHash(_newPassword);
                    _user.change_password = 1;

                    UserCommon.GetInstance().Update(_user);
                    string body = EmailTemplate.ResetPassword(_user.username, _newPassword);
                    Email email = new Email() { recipient = _user.email, subject = "Recuperação de Senha", body = body };
                    Mail.Send(email);
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Uma nova senha foi encaminhada por e-mail");
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "O usuário está bloqueado");
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
        public HttpResponseMessage Login(User user)
        {
            try
            {
                User _user = UserCommon.GetInstance().Get(new User() { email = user.email }).FirstOrDefault();
                if(_user != null)
                {
                    if(_user.password.Equals(Cripto.GetHash(user.password)))
                    {   
                        if(!_user.blocked.Equals("SIM"))
                        {
                            IncorrectAttempt(_user, true);
                            var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.OK, _user);
                            return response;
                        }
                        else
                        {
                            var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Usuário bloqueado!");
                            return response;
                        }
                    }
                    else
                    {
                        if(_user.attempts == 1)
                        {
                            IncorrectAttempt(_user, false);
                            var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Senha incorreta! O cadastro será bloqueado na próxima tentativa errada.");
                            return response;
                        }
                        else if(_user.attempts >= 2)
                        {
                            IncorrectAttempt(_user, false);
                            var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Senha incorreta! O cadastro está bloqueado.");
                            return response;
                        }
                        else
                        {
                            IncorrectAttempt(_user, false);
                            var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Senha incorreta!");
                            return response;
                        }
                    }
                }
                else
                {
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Usuário não encontrado");
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
        public HttpResponseMessage ChangePassword(User user)
        {
            try
            {
                if(!String.IsNullOrEmpty(user.password))
                {
                    if (Password.StrongPassword(user.password))
                    {
                        var _user = UserCommon.GetInstance().Get(new Inventory.Core.Model.User() { id_user = user.id_user }).FirstOrDefault();
                        _user.password = Cripto.GetHash(user.password);
                        _user.change_password = 0;
                        UserCommon.GetInstance().Update(_user);
                        var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Senha alterada");
                        return response;
                    }
                    else
                    {
                        var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Senha fraca! Use letras maiúsculas e minusculas, caracteres especiais e números.");
                        return response;
                    }
                }
                else
                {
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Nova senha não pode ser nula!");
                    return response;
                }
            }
            catch
            {
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, "error");
                return response;
            }

        }

        private void IncorrectAttempt (User user, bool reset)
        {
            if (!reset)
            {
                user.attempts = user.attempts + 1;

                if (user.attempts >= 3)
                    user.blocked = "SIM";

                UserCommon.GetInstance().Update(user);
            }
            else
            {
                user.attempts = 0;
                UserCommon.GetInstance().Update(user);
            }
        }

    }
}
