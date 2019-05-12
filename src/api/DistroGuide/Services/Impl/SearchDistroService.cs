using System.Collections.Generic;
using System.Linq;
using DistroGuide.Repository;
using DistroGuide.VO;

namespace DistroGuide.Services.Impl
{
    public class SearchDistroService : ISearchDistroService
    {
        private readonly IQueryDistroRepository queryDistroRepository;
        public SearchDistroService(IQueryDistroRepository queryDistroRepository)
        {
            this.queryDistroRepository = queryDistroRepository;
        }
        public List<DistroSearchItemVO> GetDistrosByTerm(string term)
        {
            term = term.Trim();
            return this.queryDistroRepository.GetDistrosByName(term, 5)
                .OrderBy(b => b.N.Length)
                .ToList();
        }
    }
}