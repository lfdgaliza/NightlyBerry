using System;
using System.Collections.Generic;
using System.Linq;
using DistroGuide.Domain.Dto;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Repository.Entities;

namespace DistroGuide.Domain.Service.Impl
{
    public class TreeService : ITreeService
    {
        private readonly IDistroRepository distrRepository;

        public TreeService(IDistroRepository distroRepository)
        {
            this.distrRepository = distroRepository;
        }
        public List<TreeDto> GenerateTree()
        {
            var releases = this.distrRepository.GetAll();

            var roots = releases
                .Where(r => !r.ParentList.Any())
                .Select(s => new TreeDto
                {
                    Name = s.Name,
                    Id = s.Id,
                    Children = GetChildren(s.Id, releases)
                })
                .ToList();

            return roots;
        }

        private List<TreeDto> GetChildren(Guid id, ICollection<DistroEntity> releases)
        {
            return releases
                .Where(w => w.ParentList.Select(p => p.BasedOnId).Contains(id))
                .Select(s => new TreeDto
                {
                    Name = s.Name,
                    Id = s.Id,
                    Children = GetChildren(s.Id, releases)
                })
                .ToList();
        }
    }
}
