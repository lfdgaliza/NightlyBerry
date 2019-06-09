using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Entities.Packages;
using System;

namespace DistroGuide.Domain.Model.Entities.Distros
{
    public class PackageDistro : BaseEntity
    {
        public Guid DistroId { get; set; }
        public Distro Distro { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }

        public bool IsOficial { get; set; }
        public bool IsPrincipal { get; set; }
    }
}