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
        public List<DistroSearchItemVO> GetAllDistrosForSearch()
        {
            return this.context.Distros
                .Select(d => new DistroSearchItemVO
                {
                    I = d.Id,
                    N = d.Name,
                    P = d.IconUrl
                })
                .ToList();
        }
    }
}