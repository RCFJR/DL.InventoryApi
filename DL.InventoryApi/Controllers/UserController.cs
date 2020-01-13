﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DL.Inventory.Core;
using DL.Inventory.Core.Data;
using DL.Inventory.Core.Model;

namespace DL.InventoryApi.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            var _users = UserCommon.GetInstance().Get(new User() { });

            return _users;
        }

        // GET: api/User/5
        public IEnumerable<User> Get(int id)
        {
            var _users = UserCommon.GetInstance().Get(new User() { id_user = id });

            return _users;
        }

        public void Create(User user)
        {
            UserCommon.GetInstance().Create(user);
        }

        public void Update(User user)
        {
            UserCommon.GetInstance().Update(user);
        }

        public void Delete(User user)
        {
            UserCommon.GetInstance().Delete(user);
        }
    }
}
