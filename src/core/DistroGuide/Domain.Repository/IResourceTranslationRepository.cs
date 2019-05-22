using System.Linq;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Repository
{
    public interface IResourceTranslationRepository
    {
        IQueryable<ResourceTranslation> GetTranslationsByClassification(string classification, string language);
    }
}
