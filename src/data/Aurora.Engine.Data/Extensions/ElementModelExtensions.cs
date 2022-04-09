
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

        /// <summary>
        /// Gets a new instance of the <see cref="EnhancementProperties"/> to interact with the element properties without the need to know property keys.
        /// </summary>
        /// <param name="elementModel">The element model from which you want to read and write the properties.</param>
        /// <returns>A new instance of the enhancement properties.</returns>
        public static EnhancementProperties GetEnhancementProperties(this ElementModel elementModel)
        {
            return new EnhancementProperties(elementModel.Properties);
        }
    }
}
