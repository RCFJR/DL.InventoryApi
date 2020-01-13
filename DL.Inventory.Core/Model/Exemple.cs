using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Inventory.Core.Model
{
    public class Exemple
    {
        [_MapperTO("ExempleID")]
        public int ExempleID { get; set; }

        [_MapperTO("ExempleName")]
        public string ExempleName { get; set; }

        [_MapperTO("ExempleDescript")]
        public string ExempleDescript { get; set; }

        [_MapperTO("ExempleInsertDate")]
        public string ExempleInsertDate { get; set; }
    }
}
