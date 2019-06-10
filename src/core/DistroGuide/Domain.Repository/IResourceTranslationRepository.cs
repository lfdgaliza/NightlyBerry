using DistroGuide.Domain.Model.Entities.Resources;
using System.Linq;

namespace DistroGuide.Domain.Repository
{
    public interface IResourceTranslationRepository
    {
        IQueryable<ResourceTranslation> GetTranslationsByResourceGroup(string classification, string language);
    }
}
