using System;
using DistroGuide.Infra.Repository;

namespace DistroGuide.Domain.Repository.Entities
{
    public class DistroDerivationEntity : EntityBase
    {
        public Guid ReleaseId { get; set; }
        public DistroEntity Distro { get; set; }

        public Guid BasedOnId { get; set; }
        public DistroEntity Parent { get; set; }
    }
}
