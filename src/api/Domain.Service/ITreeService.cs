using System;
using System.Collections.Generic;
using DistroGuide.Domain.Dto;
using DistroGuide.Infra.Service;

namespace DistroGuide.Domain.Service
{
    public interface ITreeService : IService
    {
        List<TreeDto> GenerateTree();
    }
}
