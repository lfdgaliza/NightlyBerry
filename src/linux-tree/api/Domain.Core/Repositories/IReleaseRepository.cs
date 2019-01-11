using System.Collections.Generic;

using NightlyBerry.Common.Repository;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Domain.Core.Repositories
{
    public interface IReleaseRepository : IRepository<DistroRelease>
    {
        ICollection<DistroRelease> GetAllLastReleases();
    }
}
