using System;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroDerivation : ModelBase
    {
        public Guid ReleaseId { get; set; }
        public DistroRelease Release { get; set; }

        public Guid DerivesFromId { get; set; }
        public DistroRelease DerivesFrom { get; set; }
    }
}
