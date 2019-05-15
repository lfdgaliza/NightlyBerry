using System.Linq;
using DistroGuide.Domain.Model.Entities;
using DistroGuide.Domain.Repository.Impl.Context;

namespace DistroGuide.Domain.Repository.Impl
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly DistroGuideContext context;

        public TranslationRepository(DistroGuideContext context)
        {
            this.context = context;
        }

        public IQueryable<Translation> GetTranslationsByModule(string module, string language)
        {
            return this.context.Set<Translation>()
                .Where(t => t.Module == module)
                .Where(t => t.Language == language);
        }
    }
}
