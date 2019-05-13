using System.Collections.Generic;
using System.Linq;
using DistroGuide.App_Domain.Repository;
using DistroGuide.App_Domain.Repository.Entities;
using DistroGuide.App_Impl.Repository.Config;

namespace DistroGuide.App_Impl.Repository
{
    public class QueryDistroRepository : IQueryDistroRepository
    {
        private readonly DistroGuideContext context;

        public QueryDistroRepository(DistroGuideContext context)
        {
            this.context = context;
        }

        public IQueryable<Distro> GetAllDistros()
        {
            return this.context.Distros;
        }
    }
}