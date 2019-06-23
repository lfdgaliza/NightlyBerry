using DistroGuide.Domain.Model.Enums;

namespace DistroGuide.Domain.Services
{
    public interface IConfigurationService
    {
        string GetConfiguration(ConfigurationKey key);
    }
}
