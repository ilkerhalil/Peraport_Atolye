using System;
using System.CodeDom;
using System.ComponentModel;
using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class LoggerConfigurationElement : ConfigurationElement
    {
        //<Logger name = "debug" type="Logger.DebugImpl.DebugLogger" />
        [ConfigurationProperty(name: "name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];

            }
            set { this["name"] = value; }
        }

        [ConfigurationProperty(name: "type", IsRequired = true)]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type Type
        {
            get
            {
                return (Type)this["type"];

            }
            set { this["type"] = value; }
        }

        [ConfigurationProperty(name: "Constructor")]
        public ConstructorElement Constructor
        {
            get
            {
                return (ConstructorElement)this["Constructor"];

            }
            set { this["Constructor"] = value; }
        }
    }
}