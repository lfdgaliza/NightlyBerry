using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Entities.Distros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Packages
{
    public class Package : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public Guid PackageTypeId { get; set; }
        public PackageType PackageType { get; set; }

        public HashSet<PackageDistro> PackageDistroList { get; set; }
    }
}