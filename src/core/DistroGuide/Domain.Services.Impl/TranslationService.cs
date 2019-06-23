using DistroGuide.Domain.Model.Enums;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Services.Dto;
using System.Collections.Generic;
using System.Linq;

namespace DistroGuide.Domain.Services.Impl
{
    public class TranslationService : ITranslationService
    {
        private readonly IResourceTranslationRepository resourceTranslationRepository;
        private readonly IConfigurationService configurationService;

        public TranslationService(
            IResourceTranslationRepository resourceTranslationRepository,
            IConfigurationService configurationService)
        {
            this.resourceTranslationRepository = resourceTranslationRepository;
            this.configurationService = configurationService;
        }

        public TranslationBundleDto GetComponentsTranslation(string language)
        {
            var componentTranslationGroupPrefix = this.configurationService
                .GetConfiguration(ConfigurationKey.ComponentTranslationGroupPrefix);

            var translationList = this.resourceTranslationRepository
                .GetTranslationsByResourceGroupStartingWith(componentTranslationGroupPrefix, language)
                .ToList();

            var translationGroupList = translationList
                .GroupBy(r => r.Resource)
                .GroupBy(r => r.Key.ResourceGroup)
                .Select(r => new TranslationGroupDto
                {
                    Name = r.Key.Name,
                    // TODO: Implement fallback language
                    Items = r.ToDictionary(k => k.Key.Name, v => v.FirstOrDefault()?.Translation)
                })
                .ToList();

            return new TranslationBundleDto { TranslationGroupList = translationGroupList };
        }

        public Dictionary<string, string> GetModuleTranslation(string moduleName, string language)
        {
            return this.resourceTranslationRepository
                .GetTranslationsByResourceGroup(moduleName, language)
                .ToDictionary(k => k.Resource.Name, v => v.Translation);
        }
    }
}
