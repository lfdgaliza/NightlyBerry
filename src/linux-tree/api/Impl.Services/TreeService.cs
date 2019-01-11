using System;
using System.Collections.Generic;
using System.Linq;

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
            var distros = this.distroRepository.GetAll(false,
                "VariantList",
                "VariantList.ReleaseList",
                "VariantList.ReleaseList.ParentList");

            var roots = distros
                .Where(d => d.VariantList.Any(v => v.ReleaseList.Any(r => !r.ParentList.Any())))
                .Select(d => new TreeDTO
                {
                    Id = d.Id,
                    Name = d.Name
                    // ,Children = GetChildren(d.Id, distros)
                });

            throw new NotImplementedException();
        }
    }
}
