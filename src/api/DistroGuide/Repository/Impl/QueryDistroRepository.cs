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
        public List<DistroSearchItemVO> SearchByTerm(string term)
        {
            return this.context.Distros
                .Where(d => d.Name.Contains(term))
                .Select(d => new DistroSearchItemVO
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImgPath = d.IconUrl
                })
                .ToList();
        }
    }
}