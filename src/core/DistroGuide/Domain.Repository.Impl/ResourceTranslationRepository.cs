using DistroGuide.Domain.Model.Entities.Resources;
using DistroGuide.Domain.Repository.Impl.Context;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IQueryable<ResourceTranslation> GetTranslationsByClassification(string classification, string language)
        {
            var resourceTranslations = this.context
                .Set<ResourceTranslation>()
                .Include(i => i.Resource);

            //return
            //    from rt in resourceTranslations
            //    where rt.Resource.Category == classification
            //    && rt.Language == language
            //    select rt;

            throw new NotImplementedException();
        }
    }
}
