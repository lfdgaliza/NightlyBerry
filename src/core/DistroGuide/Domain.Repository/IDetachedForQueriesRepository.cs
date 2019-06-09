using DistroGuide.Domain.Model.Entities.Distros;
using System.Collections.Generic;

namespace DistroGuide.Domain.Repository
{
    public interface ISingletonRepository
    {
        List<Distro> GetAllDistros();
    }
}
