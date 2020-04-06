using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DL.Core;
using DL.Core.Data;
using DL.Core.Model;

namespace DL.Api.Controllers
{
    public class DeviceController : ApiController
    {
        // GET: api/User
        public IEnumerable<Device> Get()
        {
            var _devices = DeviceCommon.GetInstance().Get(new Device() { });
            return _devices;
        }

        // GET: api/User/5
        public IEnumerable<Device> Get(int id)
        {
            var _devices = DeviceCommon.GetInstance().Get(new Device() { id_device = id });
            return _devices;
        }

        public void Create(Device device)
        {
            DeviceCommon.GetInstance().Create(device);
        }

        public void Update(Device device)
        {
            DeviceCommon.GetInstance().Update(device);
        }

        public void Delete(Device device)
        {
            DeviceCommon.GetInstance().Delete(device);
        }
    }
}
