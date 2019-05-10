using System.Collections.Generic;
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
        public List<DistroSearchItemVO> GetAllDistrosForSearch()
        {
            return this.queryDistroRepository.GetAllDistrosForSearch();
        }
    }
}