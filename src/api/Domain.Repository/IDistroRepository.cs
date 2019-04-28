using System;
using System.Collections.Generic;
using DistroGuide.Domain.Repository.Entities;
using DistroGuide.Infra.Repository;

namespace DistroGuide.Domain.Repository
{
    public interface IDistroRepository : IRepository<DistroEntity>
    {
        ICollection<DistroEntity> GetAll();
    }
}
