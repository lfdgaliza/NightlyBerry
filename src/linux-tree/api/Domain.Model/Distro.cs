
using System.Collections.Generic;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class Distro : ModelBase
    {
        public string Name { get; set; }

        public ICollection<DistroVariant> VariantList { get; set; }
    }
}
