using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Core.Model
{
    public class Device
    {
        [_MapperTO("ID_DEVICE")]
        public int id_device { get; set; }

        [_MapperTO("TOKEN")]
        public string token { get; set; }

        [_MapperTO("MODEL")]
        public string model { get; set; }

        [_MapperTO("MANUFACTURER")]
        public string manufacturer { get; set; }

        [_MapperTO("SYSTEM")]
        public string system { get; set; }

        [_MapperTO("VERSION")]
        public string version { get; set; }

        [_MapperTO("ACTIVE")]
        public string active { get; set; }

        [_MapperTO("USER_ID")]
        public int user_id { get; set; }
    }
}
