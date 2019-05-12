using System.Collections.Generic;
using System.Linq;
using DistroGuide.VO;

namespace DistroGuide.Repository
{
    public interface IQueryDistroRepository
    {
        IQueryable<DistroSearchItemVO> GetDistrosByName(string term);
        IQueryable<DistroSearchItemVO> GetDistrosByName(string term, int maxResults);
    }
}