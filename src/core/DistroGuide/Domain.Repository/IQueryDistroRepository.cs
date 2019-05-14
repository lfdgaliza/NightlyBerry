using System.Linq;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Repository
{
    public interface IQueryDistroRepository
    {
        IQueryable<Distro> GetAllDistros();
    }
}
