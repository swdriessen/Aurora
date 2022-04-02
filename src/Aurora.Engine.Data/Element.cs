using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Engine.Data
{
    public class ElementBase
    {
        public ElementBase(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public ElementProperties Properties { get; set; } = new();
    }
}
