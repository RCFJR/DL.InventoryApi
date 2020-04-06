using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DL.Core;
using DL.Core.Data;
using DL.Core.Model;
using DL.Core.Util;

namespace DL.Api.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            var _users = UserCommon.GetInstance().Get(new User() { });
            return _users;
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Get(User user)
        {
            try
            {
                if(user.id_user > 0)
                {
                    var _user = UserCommon.GetInstance().Get(new User() { id_user = user.id_user }).FirstOrDefault() ;
                    var response = Request.CreateResponse<User>(System.Net.HttpStatusCode.OK, _user);
                    return response;
                }
                else
                {
                    var _users = UserCommon.GetInstance().Get(new User() { });
                    var response = Request.CreateResponse<IList<User>>(System.Net.HttpStatusCode.OK, _users);
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
        public HttpResponseMessage Create(User user)
        {
            try
            {
                if(Validation.Execute(user))
                {
                    string _newPassword = Password.Create();
                    user.password = Cripto.GetHash(_newPassword);
                    user.change_password = 1;

                    UserCommon.GetInstance().Create(user);
                    string body = EmailTemplate.NewUser(user.username, _newPassword);
                    Email email = new Email() { recipient = user.email, subject = "Cadastro no sistema", body = body };
                    Mail.Send(email);
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Usuário cadastrado, uma senha de acesso foi enviada por e-mail");
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.OK, "Preencha todas as informações.");
                    return response;
                }
            }
            catch
            {
                var response = Request.CreateResponse<String>(System.Net.HttpStatusCode.InternalServerError, "error");
                return response;
            }

        }

        public void Update(User user)
        {
            UserCommon.GetInstance().Update(user);
        }
        
        public void Delete(User user)
        {
            UserCommon.GetInstance().Delete(user);
        }

        public void Unlock(User user)
        {
            var _user = UserCommon.GetInstance().Get(user).FirstOrDefault();
            _user.blocked = "NAO";
            _user.attempts = 0;
            UserCommon.GetInstance().Update(_user);
        }
    }
}
