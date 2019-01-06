using System.Collections.Generic;

using NightlyBerry.LinuxTree.Domain.Output;

namespace NightlyBerry.LinuxTree.Domain.Contracts.Services
{
    public interface ITreeService
    {
        List<TreeDTO> GenerateTree();
    }
}
