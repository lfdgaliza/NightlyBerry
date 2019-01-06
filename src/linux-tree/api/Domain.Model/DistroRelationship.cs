using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroRelationship : ModelBase
    {
        public int DistroId { get; set; }
        public Distro Distro { get; set; }

        public int ParentDistroId { get; set; }
        public Distro ParentDistro { get; set; }
    }
}
