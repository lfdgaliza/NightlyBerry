using CrossCutting.Infra.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Resources
{
    public class Resource : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public Guid ResourceGroupId { get; set; }
        public ResourceGroup ResourceGroup { get; set; }

        public HashSet<ResourceTranslation> ResourceTranslations { get; set; }
    }
}