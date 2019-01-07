using System;
using System.Collections.Generic;

using NightlyBerry.Common.Model;

namespace NightlyBerry.LinuxTree.Domain.Model
{
    public class DistroRelease : ModelBase
    {
        public Guid VariantId { get; set; }
        public DistroVariant Variant { get; set; }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<DistroDerivation> ParentList { get; set; }
        public ICollection<DistroDerivation> DerivationList { get; set; }
    }
}
