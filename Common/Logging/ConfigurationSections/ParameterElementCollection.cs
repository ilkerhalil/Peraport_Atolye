using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class ParameterElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ParameterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParameterElement)element).Name;
        }
    }
}