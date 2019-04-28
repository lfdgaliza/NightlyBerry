using System;
namespace DistroGuide.Domain.Model
{
    public class DistroDerivation
    {
        public Guid ReleaseId { get; set; }
        public Distro Distro { get; set; }

        public Guid BasedOnId { get; set; }
        public Distro Parent { get; set; }
    }
}
