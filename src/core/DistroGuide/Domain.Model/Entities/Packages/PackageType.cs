using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Entities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Packages
{
    public class PackageType : BaseEntity
    {
        [MaxLength(100)]
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public HashSet<Package> PackageList { get; set; }
    }
}
