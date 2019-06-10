using CrossCutting.Infra.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DistroGuide.Domain.Model.Entities.Resources
{
    public class ResourceGroup : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public HashSet<Resource> ResourceList { get; set; }
    }
}
