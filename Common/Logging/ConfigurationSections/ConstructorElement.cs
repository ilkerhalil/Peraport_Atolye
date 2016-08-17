using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class ConstructorElement : ConfigurationElement
    {
        [ConfigurationProperty("Parameters", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ParameterElementCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ParameterElementCollection Parameters
        {
            get
            {
                return (ParameterElementCollection)this["Parameters"];

            }
            set { this["Parameters"] = value; }
        }
    }
}