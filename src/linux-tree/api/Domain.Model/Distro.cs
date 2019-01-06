using System.Collections.Generic;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class Distro : ModelBase
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Article { get; set; }

        public ICollection<DistroRelationship> ChildDistroRelationshipList { get; set; }
        public ICollection<DistroRelationship> ParentDistroRelationshipList { get; set; }
        public ICollection<DistroVersion> Versions { get; set; }
    }
}
