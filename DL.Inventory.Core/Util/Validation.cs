using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Validate;

namespace DL.Core.Util
{
    public class Validation
    {
        public static bool Execute<T>(T entity)
        {
            return Validate.Validate.Verify(entity);
        }
    }
}
