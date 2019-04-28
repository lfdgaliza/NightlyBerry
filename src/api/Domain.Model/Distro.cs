using System;
using System.Collections.Generic;

namespace DistroGuide.Domain.Model
{
    public class Distro
    {
        public string Name { get; set; }

        public ICollection<DistroDerivation> ChildList { get; set; }
        public ICollection<DistroDerivation> ParentList { get; set; }
    }
}
