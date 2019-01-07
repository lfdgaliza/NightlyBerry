
using NightlyBerry.Common.Repository;
using NightlyBerry.LinuxTree.Domain.Core.Repositories;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories
{
    public class DistroRepository : RepositoryBase<Distro>, IDistroRepository
    {
        public DistroRepository(BasicDbContext context) : base(context)
        {
        }
    }
}
