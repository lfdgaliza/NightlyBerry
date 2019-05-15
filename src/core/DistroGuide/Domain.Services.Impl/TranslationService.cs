using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Services.Impl
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository translationRepository;

        public TranslationService(ITranslationRepository translationRepository)
        {
            this.translationRepository = translationRepository;
        }

        public Dictionary<string, string> GetModuleTranslation(string moduleName, string language)
        {
            return this.translationRepository
                .GetTranslationsByModule(moduleName, language)
                .ToDictionary(k => k.Name, v => v.Value);
        }
    }
}
