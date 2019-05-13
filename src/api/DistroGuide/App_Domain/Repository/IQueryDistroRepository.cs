using System.Collections.Generic;
using System.Linq;
using DistroGuide.App_Domain.Repository.Entities;

namespace DistroGuide.App_Domain.Repository
{
    public interface IQueryDistroRepository
    {
        IQueryable<Distro> GetAllDistros();
    }
}