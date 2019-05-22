using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Services.Impl
{
    public class TranslationService : ITranslationService
    {
        private readonly IResourceTranslationRepository resourceTranslationRepository;

        public TranslationService(IResourceTranslationRepository resourceTranslationRepository)
        {
            this.resourceTranslationRepository = resourceTranslationRepository;
        }

        public Dictionary<string, string> GetModuleTranslation(string moduleName, string language)
        {
            return this.resourceTranslationRepository
                .GetTranslationsByClassification(moduleName, language)
                .ToDictionary(k => k.Resource.Name, v => v.Translation);
        }
    }
}
