
using System.Collections.Generic;

using NightlyBerry.Common.Repository;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Domain.Core.Repositories
{
    public interface IDistroRepository : IRepository<Distro>
    {
        ICollection<Distro> GetAll();
    }
}
