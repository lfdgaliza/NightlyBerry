
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public ICollection<Distro> GetAll()
        {
            var query = from distro in EntitySet
                        select distro;

            query = query.Include(p => p.ParentList);
            query = query.Include(p => p.ChildList);

            return query.ToList();
        }
    }
}
