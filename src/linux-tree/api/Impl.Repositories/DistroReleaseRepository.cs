using Microsoft.EntityFrameworkCore;

using NightlyBerry.Common.Repository;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories
{
    public class DistroReleaseRepository : RepositoryBase<DistroRelease>, DistroReleaseRepository
    {
        public DistroReleaseRepository(DbContext context) : base(context)
        {
        }
    }
}
