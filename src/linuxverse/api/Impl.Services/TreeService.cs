using System;
using System.Collections.Generic;
using System.Linq;

using NightlyBerry.LinuxTree.Domain.Core.Repositories;
using NightlyBerry.LinuxTree.Domain.Core.Services;
using NightlyBerry.LinuxTree.Domain.Model;
using NightlyBerry.LinuxTree.Domain.Output;

namespace NightlyBerry.LinuxTree.Impl.Services
{
    public class TreeService : ITreeService
    {
        private readonly IDistroRepository distrRepository;

        public TreeService(IDistroRepository distroRepository)
        {
            this.distrRepository = distroRepository;
        }
        public List<TreeDTO> GenerateTree()
        {
            var releases = this.distrRepository.GetAll();

            var roots = releases
                .Where(r => !r.ParentList.Any())
                .Select(s => new TreeDTO
                {
                    Name = s.Name,
                    Id = s.Id,
                    Children = GetChildren(s.Id, releases)
                })
                .ToList();

            return roots;
        }

        private List<TreeDTO> GetChildren(Guid id, ICollection<Distro> releases)
        {
            return releases
                .Where(w => w.ParentList.Select(p => p.BasedOnId).Contains(id))
                .Select(s => new TreeDTO
                {
                    Name = s.Name,
                    Id = s.Id,
                    Children = GetChildren(s.Id, releases)
                })
                .ToList();
        }
    }
}
