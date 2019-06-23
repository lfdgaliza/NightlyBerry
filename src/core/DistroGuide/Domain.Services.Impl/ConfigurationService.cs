using DistroGuide.Domain.Model.Enums;
using System;

namespace DistroGuide.Domain.Services.Impl
{
    public class ConfigurationService : IConfigurationService
    {
        // TODO move to a database table
        public string GetConfiguration(ConfigurationKey key)
        {
            switch (key)
            {
                case ConfigurationKey.ComponentTranslationGroupPrefix:
                    return "C:";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
