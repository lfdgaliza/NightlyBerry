using System.Collections.Generic;
using DistroGuide.Domain.Services.Dto;

namespace DistroGuide.Domain.Services
{
    public interface IDistroService
    {
        List<DistroSearchItemDto> GetDistrosByTerm(string term);
    }
}
