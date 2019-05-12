using System.Collections.Generic;
using DistroGuide;
using DistroGuide.VO;

namespace DistroGuide.Services
{
    public interface ISearchDistroService
    {
        List<DistroSearchItemVO> GetDistrosByTerm(string term);
    }
}