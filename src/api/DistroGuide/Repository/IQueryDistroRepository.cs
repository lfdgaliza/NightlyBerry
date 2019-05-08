using System.Collections.Generic;
using DistroGuide.VO;

namespace DistroGuide.Repository
{
    public interface IQueryDistroRepository
    {
        List<DistroSearchItemVO> SearchByTerm(string term);
    }
}