using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Entities.ExternalReferences;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Distros
{
    public class Distro : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public Guid? BasedOnId { get; set; }
        public Distro BasedOn { get; set; }

        public HashSet<Distro> ChildList { get; set; }
        public HashSet<ExternalReference> ExternalReferenceList { get; set; }
        public HashSet<PackageDistro> PackageDistroList { get; set; }
    }
}
