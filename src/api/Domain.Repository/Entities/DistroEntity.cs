using System;
using System.Collections.Generic;
using DistroGuide.Infra.Repository;

namespace DistroGuide.Domain.Repository.Entities
{
    public class DistroEntity : EntityBase
    {
        public string Name { get; set; }

        public ICollection<DistroDerivationEntity> ChildList { get; set; }
        public ICollection<DistroDerivationEntity> ParentList { get; set; }
    }
}
