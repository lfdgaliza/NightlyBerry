using DistroGuide.Domain.Model.Entities.Distros;
using System.Linq;

namespace DistroGuide.Domain.Repository
{
    public interface IQueryDistroRepository
    {
        IQueryable<Distro> GetAllDistros();
    }
}
