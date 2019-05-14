using System.Collections.Generic;
using DistroGuide.Domain.Model.Entities;

namespace DistroGuide.Domain.Repository
{
    public interface ISingletonRepository
    {
        List<Distro> GetAllDistros();
    }
}
