using DistroGuide.Domain.Services.Dto;
using System.Collections.Generic;

namespace DistroGuide.Domain.Services
{
    public interface ITranslationService
    {
        Dictionary<string, string> GetModuleTranslation(string moduleName, string language);
        TranslationBundleDto GetComponentsTranslation(string language);
    }
}
