using Aurora.Engine.Data.Models;

namespace Aurora.Engine.Data.Extensions
{
    public static class ElementModelExtensions
    {
        /// <summary>
        /// A shorthand to add a property to the list of properties of the element model.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public static ElementModel AddProperty(this ElementModel model, string name, object value)
        {
            model.Properties.Add(name, value);
            return model;
        }
    }
}
