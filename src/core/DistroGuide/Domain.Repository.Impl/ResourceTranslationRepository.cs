using DistroGuide.Domain.Model.Entities.Resources;
using DistroGuide.Domain.Repository.Impl.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DistroGuide.Domain.Repository.Impl
{
    public class ResourceTranslationRepository : IResourceTranslationRepository
    {
        private readonly DistroGuideContext context;

        public ResourceTranslationRepository(DistroGuideContext context)
        {
            this.context = context;
        }

        public IQueryable<ResourceTranslation> GetTranslationsByResourceGroup(string resourceGroup, string language)
        {
            var resourceTranslations = this.context
                .Set<ResourceTranslation>()
                .Include(i => i.Resource);

            return
                from rt in resourceTranslations
                where rt.Resource.ResourceGroup.Name == resourceGroup
                && rt.Language == language
                select rt;
        }

        public IQueryable<ResourceTranslation> GetTranslationsByResourceGroupStartingWith(string resourceGroupStartingith, string language)
        {
            var resourceTranslations = this.context.Set<ResourceTranslation>()
                .Include(r => r.Resource)
                .ThenInclude(r => r.ResourceGroup);

            return
                from resourceTranslation in resourceTranslations
                where resourceTranslation.Language == language
                select resourceTranslation;
        }
    }
}
