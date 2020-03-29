using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Inventory.Core.Model
{
    public class Log
    {
        [_MapperTO("ID_LOG")]
        public int id_log { get; set; }

        [_MapperTO("MSG")]
        public string msg { get; set; }

        [_MapperTO("DATE")]
        public string date { get; set; }
    }
}
