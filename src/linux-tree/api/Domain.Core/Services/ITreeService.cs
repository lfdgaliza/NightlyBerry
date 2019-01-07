using System.Collections.Generic;

using NightlyBerry.Common.DependencyInjection.Marking;
using NightlyBerry.LinuxTree.Domain.Output;

namespace NightlyBerry.LinuxTree.Domain.Core.Services
{
    public interface ITreeService : IService
    {
        List<TreeDTO> GenerateTree();
    }
}
