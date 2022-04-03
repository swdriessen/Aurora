
using Aurora.Engine.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Engine.Data.Extensions
{
    public static class ElementModelExtensions
    {
        /// <summary>
        /// A shorthand to add a property to the list of properties of the element model.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static void AddProperty(this ElementModel model, string name, object value)
        {
            //model.Properties.Add(new ElementPropertyModel() { Name = name, Value = value });
            model.Properties.Add(name, value);
        }
    }
}
