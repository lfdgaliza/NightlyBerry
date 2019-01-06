using System;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroVersionRelease : ModelBase
    {
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }

        public int VersionId { get; set; }
        public Version Version { get; set; }
    }
}
