using System;
using System.ComponentModel;
using System.Configuration;

namespace Common.Logging.ConfigurationSections
{
    public class ParameterElement : ConfigurationElement
    {
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
        [ConfigurationProperty(name: "value", IsRequired = true)]
        public string Value
        {
            get
            {
                return (string) this["value"];

            }
            set
            {
                this["value"] = value;
            }
        }

    }
}