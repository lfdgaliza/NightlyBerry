using System;
using System.Collections.Generic;

using NightlyBerry.LinuxTree.Domain.Core.Repositories;
using NightlyBerry.LinuxTree.Domain.Core.Services;
using NightlyBerry.LinuxTree.Domain.Output;

namespace NightlyBerry.LinuxTree.Impl.Services
{
    public class TreeService : ITreeService
    {
        private readonly IDistroRepository distroRepository;

        public TreeService(IDistroRepository distroRepository)
        {
            this.distroRepository = distroRepository;
        }
        public List<TreeDTO> GenerateTree()
        {
            var distros = this.distroRepository.GetAll(false, "VariantList");
            throw new NotImplementedException();
        }
    }
}
