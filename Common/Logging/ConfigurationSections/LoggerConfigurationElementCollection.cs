using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class LoggerConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LoggerConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LoggerConfigurationElement)element).Name;
        }
    }
}