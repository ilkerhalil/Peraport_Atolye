using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Common.Logging.ConfigurationSections;
using Common.Logging.Interfaces;

namespace Common.Logging
{
    public static class LoggerFactory
    {
        public static IEnumerable<ILogger> GetLoggers()
        {
            var loggerConfigSection = ConfigurationManager.GetSection("LoggerSection") as LoggerConfigurationSection;
            var loggerDictionary =
                loggerConfigSection.Loggers.Cast<LoggerConfigurationElement>()
                    .ToDictionary(k => k.Name, element => element.Type);
            foreach (var type in loggerDictionary)
            {
                var parameters = loggerConfigSection.Loggers.Cast<LoggerConfigurationElement>()
                    .Single(s => s.Name == type.Key)
                    .Constructor.Parameters.Cast<ParameterElement>().ToList();

                if (parameters.Any())
                {
                    var typeParameters = parameters.Select(s => Convert.ChangeType(s.Value, s.Type)).ToArray();
                    yield return Activator.CreateInstance(type.Value, typeParameters) as ILogger;
                }
                else
                {
                    yield return Activator.CreateInstance(type.Value) as ILogger;
                }

            }
        }
    }
}