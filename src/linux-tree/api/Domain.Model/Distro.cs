
using System.Collections.Generic;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class Distro : ModelBase
    {
        public string Name { get; set; }

        public ICollection<DistroDerivation> ChildList { get; set; }
        public ICollection<DistroDerivation> ParentList { get; set; }
    }
}
