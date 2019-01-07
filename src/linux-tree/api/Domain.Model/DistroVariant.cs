using System;
using System.Collections.Generic;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroVariant : ModelBase
    {
        public Guid DistroId { get; set; }
        public Distro Distro { get; set; }

        public string Name { get; set; }
        public bool IsMain { get; set; }
        public bool IsOficial { get; set; }

        public ICollection<DistroRelease> ReleaseList { get; set; }
    }
}
