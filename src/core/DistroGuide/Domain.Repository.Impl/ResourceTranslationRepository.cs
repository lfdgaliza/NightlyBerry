using System.Linq;
using DistroGuide.Domain.Model.Entities;
using DistroGuide.Domain.Repository.Impl.Context;
using Microsoft.EntityFrameworkCore;

namespace DistroGuide.Domain.Repository.Impl
{
    public class ResourceTranslationRepository : IResourceTranslationRepository
    {
        private readonly DistroGuideContext context;

        public ResourceTranslationRepository(DistroGuideContext context)
        {
            this.context = context;
        }

        public IQueryable<ResourceTranslation> GetTranslationsByClassification(string classification, string language)
        {
            var resourceTranslations = this.context
                .Set<ResourceTranslation>()
                .Include(i => i.Resource);

            return
                from rt in resourceTranslations
                where rt.Resource.Classification == classification
                && rt.Language == language
                select rt;
        }
    }
}
