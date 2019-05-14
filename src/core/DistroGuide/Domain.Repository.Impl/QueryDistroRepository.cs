using System.Linq;
using DistroGuide.Domain.Model.Entities;
using DistroGuide.Domain.Repository.Impl.Context;

namespace DistroGuide.Domain.Repository.Impl
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
            return this.context.Distros
                .Select(s => new Distro
                {
                    Id = s.Id,
                    BasedOnId = s.BasedOnId,
                    Name = s.Name,
                    IconUrl = s.IconUrl
                });
        }
    }
}
