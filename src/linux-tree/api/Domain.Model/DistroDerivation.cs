using System;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroDerivation : ModelBase
    {
        public Guid ReleaseId { get; set; }
        public Distro Distro { get; set; }

        public Guid BasedOnId { get; set; }
        public Distro Parent { get; set; }
    }
}
