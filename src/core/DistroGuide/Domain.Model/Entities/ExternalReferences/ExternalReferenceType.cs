using CrossCutting.Infra.Entities;
using DistroGuide.Domain.Model.Entities.Resources;
using System;
using System.Collections.Generic;

namespace DistroGuide.Domain.Model.Entities.ExternalReferences
{
    public class ExternalReferenceType : BaseEntity
    {
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public HashSet<ExternalReference> ExternalReferenceList { get; set; }
    }
}
