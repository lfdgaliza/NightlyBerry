using System;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroVersion : ModelBase
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public bool IsOficial { get; set; }
        public DateTime VersionDate { get; set; }

        public int DistroId { get; set; }
        public Distro Distro { get; set; }
    }
}
