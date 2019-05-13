using System.Collections.Generic;
using DistroGuide;
using DistroGuide.App_Domain.CrossCutting.VO;

namespace DistroGuide.App_Domain.Services
{
    public interface IDistroService
    {
        List<DistroSearchItemVO> GetDistrosByTerm(string term);
    }
}