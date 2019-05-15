using System.Linq;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Repository
{
    public interface ITranslationRepository
    {
        IQueryable<Translation> GetTranslationsByModule(string module, string language);
    }
}
