using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Inventory.Core.Model
{
    public class Email
    {
        public string recipient { get; set; }
        public string subject { get; set;  }
        public string sender { get; set; }
        public string body { get; set; }
    }
}
