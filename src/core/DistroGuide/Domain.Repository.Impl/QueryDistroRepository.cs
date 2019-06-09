using DistroGuide.Domain.Model.Entities.Distros;
using DistroGuide.Domain.Repository.Impl.Context;
using System.Linq;

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
            return this.context.Set<Distro>()
                .Select(s => new Distro
                {
                    Id = s.Id,
                    BasedOnId = s.BasedOnId,
                    Name = s.Name
                });
        }
    }
}
