using System.Collections.Generic;
using DistroGuide.VO;
using Repository.Config;
using System.Linq;

namespace DistroGuide.Repository.Impl
{
    public class QueryDistroRepository : IQueryDistroRepository
    {
        private readonly DistroGuideContext context;

        public QueryDistroRepository(DistroGuideContext context)
        {
            this.context = context;
        }

        public IQueryable<DistroSearchItemVO> GetDistrosByName(string term)
        {
            return this.context.Distros
                .Where(d => d.Name.ToLower().Contains(term.ToLower()))
                .Select(d => new DistroSearchItemVO
                {
                    I = d.Id,
                    N = d.Name,
                    P = d.IconUrl,
                    B = d.BasedOn.Name
                });
        }

        public IQueryable<DistroSearchItemVO> GetDistrosByName(string term, int maxResults)
        {
            return GetDistrosByName(term).Take(maxResults);
        }
    }
}