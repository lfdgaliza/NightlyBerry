using Microsoft.EntityFrameworkCore;

using NightlyBerry.Common.Repository;
using NightlyBerry.LinuxTree.Domain.Contracts.Repositories;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories
{
    public class DistroRepository : RepositoryBase<Distro>, IDistroRepository
    {
        public DistroRepository(DbContext context) : base(context)
        {
        }
    }
}
