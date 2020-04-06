using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Core.Model
{
    [AttributeUsage(AttributeTargets.Property)]
    public class _MapperTO : Attribute
    {
        public string Coluna { get; set; }

        public _MapperTO (string coluna)
        {
            this.Coluna = coluna;
        }
    }
}
