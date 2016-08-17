using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class LoggerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("Loggers", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(LoggerConfigurationElementCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public LoggerConfigurationElementCollection Loggers
        {
            get
            {
                return (LoggerConfigurationElementCollection)this["Loggers"];
            }
            set { this["Loggers"] = value; }
        }
    }

    //<Constructor>
    //   <Parameter name = "Source" value="Merhaba" type="System.String"/>
    //   <Parameter name = "Event" value="Merhaba" type="System.String"/>
    //   <Parameter name = "SLog" value="Merhaba" type="System.String"/>
    // </Constructor>
}
