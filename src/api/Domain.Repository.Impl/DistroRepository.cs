using System;
using System.Collections.Generic;
using DistroGuide.Domain.Repository.Entities;
using DistroGuide.Infra.Repository;
using Infra.Repository;

namespace DistroGuide.Domain.Repository.Impl
{
    public class DistroRepository : RepositoryBase<DistroEntity>, IDistroRepository
    {
        public DistroRepository(BasicDbContext context) : base(context)
        {
        }

        public ICollection<DistroEntity> GetAll()
        {
            //var query = from distro in EntitySet
            //            select distro;

            //query = query.Include(p => p.ParentList);
            //query = query.Include(p => p.ChildList);

            //return query.ToList();

            throw new NotImplementedException();
        }
    }
}
