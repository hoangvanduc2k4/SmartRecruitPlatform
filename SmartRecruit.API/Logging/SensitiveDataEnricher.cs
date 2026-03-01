using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;

namespace SmartRecruit.Logging
{
    public class SensitiveDataEnricher : ILogEventEnricher
    {
        private readonly HashSet<string> _sensitiveProperties = new(System.StringComparer.OrdinalIgnoreCase)
        {
            "password", "token", "jwt", "phone", "email", "phonenumber", "emailaddress"
        };

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var propertiesToUpdate = new List<LogEventProperty>();

            foreach (var property in logEvent.Properties)
            {
                if (_sensitiveProperties.Contains(property.Key))
                {
                    propertiesToUpdate.Add(new LogEventProperty(property.Key, new ScalarValue("***MASKED***")));
                }
            }

            foreach (var prop in propertiesToUpdate)
            {
                logEvent.AddOrUpdateProperty(prop);
            }
        }
    }
}
